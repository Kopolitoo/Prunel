using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Prunel
{
    /// <summary>
    /// HOLD BUTTON MODE (issue #126): a mouse button stays pressed while the cursor follows
    /// the gaze, for example to move the character of a game that walks "while the right
    /// button is held" (Back to Bed).
    ///
    /// We get here from the action choice, with the "Hold left button" or "Hold right
    /// button" action of the crown (not placed by default: one adds it in the icon
    /// configuration screen, like "Keyboard").
    ///
    ///  1. HIDING.   The black screen of the action choice goes away; we wait [WaitMs].
    ///  2. PRESS.    The active modifiers (Ctrl, Shift, Alt) are pressed, the cursor is placed
    ///               on the aimed point P, then the button is pressed.
    ///  3. HOLD.     The button stays pressed. The cursor follows the gaze exactly as in game
    ///               mode with the direct mouse (same [GameSmoothing], same [CursorDeadZone]
    ///               anti-jitter): at rest it does not move for a tiny gaze jitter, beyond
    ///               that it follows continuously. Gaze off screen: the cursor stays where it is.
    ///               A "Release" button is shown on the right edge of the screen, vertically
    ///               centered, like the "back" button of the drag and drop.
    ///  4. RELEASE.  The button and the modifiers are released, then back to movement mode.
    ///
    /// Ways out, so that the button never stays stuck:
    ///   - a short glance at the "Release" button (twice the icon size, almost immediate:
    ///     [ReleaseDelaySeconds], not [ActivationDelay]);
    ///   - the caregiver's Escape key (or "Escape" said to Dragon): App.OnEscape releases all
    ///     the buttons and keys and returns to movement mode;
    ///   - the gaze LOST (no measure) for more than [LostReleaseMs] (a blink is shorter);
    ///   - any mode change, a screen change or an error: Quit releases everything.
    /// The menu does not open during this mode (MenuAllowed stays "no"): looking below the
    /// screen just leaves the cursor where it is.
    /// </summary>
    internal sealed class HoldButtonMode : Mode
    {
        /// <summary>The phases of the mode (see the class comment).</summary>
        private enum Step
        {
            Hiding,
            Hold,
            Finished
        }

        /// <summary>Wait after hiding the black screen, in milliseconds (same value as the drag and drop).</summary>
        private const double WaitMs = 60;

        /// <summary>
        /// Gaze lost (no measure at all) for this long, in milliseconds: the button is released.
        /// Longer than a blink (about 0.1 to 0.4 s), short enough so that the button does not
        /// stay held when nobody is in front of the eyetracker any more. Starting value, to adjust after testing.
        /// </summary>
        private const double LostReleaseMs = 1000;

        /// <summary>
        /// Activation delay of the "Release" button, in seconds: almost immediate (user
        /// request after testing: a short glance must be enough to stop). Not 0: the aimer
        /// divides by the delay. With the confirmation of the aimed button, about 0.1 s in all.
        /// </summary>
        private const double ReleaseDelaySeconds = 0.05;

        /// <summary>Size of the "Release" button: twice the usual icon size (user request after testing).</summary>
        private const double ReleaseSizeFactor = 2;

        private readonly MouseSide _button;

        // The aimed point P of the action choice, where the button is pressed.
        private readonly double _px;
        private readonly double _py;

        // The "Release" button (the only button of this mode) and what decides whether it is activated.
        private readonly List<GazeButton> _buttons = new List<GazeButton>();
        private readonly ButtonAimer _aimer;

        // The gaze smoothed with [GameSmoothing], as in game mode.
        private readonly Smoother _smoothed = new Smoother(() => AppSettings.Current.GameSmoothing);
        private bool _placed;

        // True when the cursor is "on the way" behind the smoothed gaze (see GameMode.DirectMouse).
        private bool _cursorOnTheWay;

        private Step _step;
        private double _stepStartMs;

        // Time (ms) when the gaze was lost; −1 = gaze present.
        private double _lostStartMs = -1;

        public HoldButtonMode(MouseSide button, double px, double py)
        {
            _button = button;
            _px = px;
            _py = py;
            _aimer = new ButtonAimer(_buttons);
        }

        public override string Name
        {
            get { return "Hold " + (_button == MouseSide.Right ? "right" : "left") + " button"; }
        }

        public override void Enter(GazeState gaze)
        {
            _aimer.Reset();
            Manager.Layer.HideAll();
            _step = Step.Hiding;
            _stepStartMs = gaze.NowMs;
            _placed = false;
            _cursorOnTheWay = false;
            _lostStartMs = -1;
        }

        public override void Update(GazeState gaze)
        {
            switch (_step)
            {
                case Step.Hiding:
                    if (gaze.NowMs - _stepStartMs >= WaitMs)
                    {
                        Press();
                        BuildSurface();
                        _step = Step.Hold;
                    }
                    break;

                case Step.Hold:
                    UpdateHold(gaze);
                    break;
            }
        }

        public override void Quit()
        {
            // Whatever the reason we leave (Release button, Escape, gaze lost, error, screen
            // change), nothing must stay pressed.
            if (_step == Step.Hold)
            {
                MouseInjector.Release(_button);
                Modifiers.ReleaseAll();
                App.LogDetail("Hold button: released");
            }
            _step = Step.Finished;

            Manager.Layer.HideDragSurface();
            Manager.Layer.DragSurface.Children.Clear();
            _buttons.Clear();
        }

        /// <summary>2. PRESS: modifiers, cursor on P, button pressed.</summary>
        private void Press()
        {
            Modifiers.PressActive();

            int x = (int)Math.Round(_px);
            int y = (int)Math.Round(_py);
            // A "real" mouse movement on the spot first (as for the drag and drop): the
            // application knows the mouse is there before the button goes down.
            MouseInjector.PointTo(x, y);

            MouseInjector.Press(_button);
            App.LogDetail("Hold button: " + _button + " button pressed, modifiers: " + Modifiers.Description());
        }

        /// <summary>3. HOLD: the Release button, the gaze lost, the cursor following the gaze.</summary>
        private void UpdateHold(GazeState gaze)
        {
            AppSettings p = AppSettings.Current;

            // The "Release" button.
            int active = _aimer.Update(gaze, ReleaseDelaySeconds, p.ShowLabels);
            if (active >= 0)
            {
                App.LogDetail("Hold button: Release button looked at");
                Manager.ChangeMode(new MovementMode());
                return;
            }

            // Gaze lost for too long: release (the button must not stay held without anyone
            // in front of the eyetracker).
            if (!gaze.Available)
            {
                if (_lostStartMs < 0)
                {
                    _lostStartMs = gaze.NowMs;
                }
                else if (gaze.NowMs - _lostStartMs >= LostReleaseMs)
                {
                    App.Log("Hold button: gaze lost, button released");
                    Manager.ChangeMode(new MovementMode());
                }
                return;
            }
            _lostStartMs = -1;

            // Gaze off screen (below, beside, or on the part of the Release button beyond the
            // edge): the cursor stays where it is, and the smoothing starts again from the
            // cursor when the gaze comes back.
            if (!gaze.OnScreen)
            {
                _placed = false;
                return;
            }

            // On the Release button: the cursor does not go there (the game should not see
            // the character run to the right edge just because one wants to stop).
            if (_buttons.Count > 0 && _buttons[0].Contains(gaze.X, gaze.Y))
            {
                return;
            }

            if (!_placed)
            {
                // Start from the CURSOR: it slides towards the gaze instead of jumping.
                NativeMethods.POINT cursor;
                if (NativeMethods.GetCursorPos(out cursor))
                {
                    _smoothed.Place(cursor.X, cursor.Y);
                }
                else
                {
                    _smoothed.Place(gaze.X, gaze.Y);
                }
                _placed = true;
            }
            _smoothed.Follow(gaze.X, gaze.Y, gaze.NowMs);
            MoveCursor();
        }

        /// <summary>
        /// The cursor follows the smoothed gaze, with the [CursorDeadZone] anti-jitter (same
        /// logic as GameMode.DirectMouse). PointTo sends a real mouse movement (SendInput):
        /// with the button held, the application sees a drag.
        /// </summary>
        private void MoveCursor()
        {
            NativeMethods.POINT cursor;
            if (!NativeMethods.GetCursorPos(out cursor))
            {
                return;
            }

            double gapX = cursor.X - _smoothed.X;
            double gapY = cursor.Y - _smoothed.Y;
            double distance = Math.Sqrt(gapX * gapX + gapY * gapY);
            if (!_cursorOnTheWay && distance >= AppSettings.Current.CursorDeadZonePx)
            {
                _cursorOnTheWay = true;
            }
            if (!_cursorOnTheWay)
            {
                return;
            }

            MouseInjector.PointTo(_smoothed.X, _smoothed.Y);
            if (distance < 1)
            {
                _cursorOnTheWay = false; // caught up: back to rest
            }
        }

        /// <summary>
        /// The "Release" button, on the right edge of the screen, vertically centered, drawn
        /// on the drag-and-drop surface (this mode draws nothing else: the game stays visible).
        /// Symbol E71A = "stop" square of the Windows font (to check on screen).
        /// </summary>
        private void BuildSurface()
        {
            OverlayWindow layer = Manager.Layer;
            if (!layer.Ready)
            {
                return;
            }
            layer.PrepareDragSurface();
            Canvas surface = layer.DragSurface;
            double size = AppSettings.Current.IconSizePx * ReleaseSizeFactor;

            double xRelease = Manager.ScreenWidth - size / 2 - ScreenMetrics.Px(10);
            double yRelease = Manager.ScreenHeight / 2;
            GazeButton release = new GazeButton("", null, Texts.Get("hold.release"));
            // Easy to aim at, like the "back" buttons of the right edge (issue #53).
            release.ZoneFactor = 1.5;
            release.StretchToRightEdge(Manager.ScreenWidth);
            release.Place(layer, surface, xRelease, yRelease, size);
            _buttons.Add(release);

            layer.ShowDragSurface();
        }
    }
}
