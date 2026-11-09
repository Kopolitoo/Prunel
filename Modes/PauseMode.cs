using System.Collections.Generic;
using System.Windows.Controls;

namespace Prunel
{
    /// <summary>
    /// PAUSE MODE.
    ///
    /// Neither the circle nor the cursor follows the gaze: the overlay is empty, Prunel
    /// does nothing. Handy for watching a video or reading without triggering anything.
    ///
    /// Only one thing stays active: looking down, below the screen, for [MenuDelay]
    /// opens the menu bar (the ModeManager handles it).
    /// From pause, the bar only shows the "Resume" button; when activated, it returns to
    /// movement mode (see MenuMode). The caregiver's Escape key also returns to movement mode.
    ///
    /// AUTOMATIC PAUSE (step auto-pause): the ModeManager starts this mode by itself when the
    /// gaze is lost for [AutoPauseDelay] (see ModeManager.WatchAutoPause). Then a round
    /// "Resume" button is shown in the middle of the screen: looking at it for
    /// [ActivationDelay] returns to movement mode. This way, when the eyes come back anywhere
    /// on the screen (or someone passes in front of the eyetracker), nothing is clicked.
    /// The pause chosen in the menu shows no button, so as not to hinder a video.
    /// </summary>
    internal sealed class PauseMode : Mode
    {
        // The "Resume" button of the automatic pause (empty list for the menu's pause).
        private readonly List<GazeButton> _buttons = new List<GazeButton>();
        private readonly ButtonAimer _aimer;

        /// <summary>Pause chosen in the menu: no button.</summary>
        public PauseMode() : this(false)
        {
        }

        /// <summary>automatic: true when the ModeManager starts the pause by itself.</summary>
        public PauseMode(bool automatic)
        {
            Automatic = automatic;
            _aimer = new ButtonAimer(_buttons);
        }

        /// <summary>True for the automatic pause (with its "Resume" button in the middle).</summary>
        public bool Automatic { get; private set; }

        public override string Name
        {
            get { return Automatic ? "Automatic pause" : "Pause"; }
        }

        /// <summary>The menu opens from pause: it is the only way to leave it with the gaze.</summary>
        public override bool MenuAllowed
        {
            get { return true; }
        }

        /// <summary>
        /// The screen changed: this mode carries on, because the pause must not end on its own.
        /// The "Resume" button of the automatic pause is placed again for the new screen.
        /// </summary>
        public override bool AdaptToScreen()
        {
            if (Automatic)
            {
                BuildResumeButton();
            }
            return true;
        }

        public override void Enter(GazeState gaze)
        {
            Manager.Layer.HideAll();
            if (Automatic)
            {
                BuildResumeButton();
            }
        }

        public override void Update(GazeState gaze)
        {
            if (_buttons.Count == 0)
            {
                return;
            }
            AppSettings p = AppSettings.Current;
            if (_aimer.Update(gaze, p.ActivationDelay, p.ShowLabels) >= 0)
            {
                App.Log("Automatic pause: resumed with the Resume button");
                Manager.ChangeMode(new MovementMode());
            }
        }

        /// <summary>
        /// Hides the "Resume" button. Also when the menu opens from the automatic pause: the
        /// menu's own "Resume" is enough, and the button comes back (Enter) if the menu closes.
        /// </summary>
        public override void Quit()
        {
            if (Automatic)
            {
                Manager.Layer.HideDragSurface();
            }
        }

        /// <summary>
        /// Places the round "Resume" button (E768 = play) in the middle of the screen, on the
        /// drag-and-drop surface (a transparent surface that covers the overlay and is free
        /// during the pause). Same size as the menu buttons.
        /// </summary>
        private void BuildResumeButton()
        {
            _buttons.Clear();
            OverlayWindow layer = Manager.Layer;
            if (!layer.Ready)
            {
                return;
            }

            layer.PrepareDragSurface();
            Canvas surface = layer.DragSurface;

            double size = 2 * AppSettings.Current.IconSizePx;
            GazeButton resume = new GazeButton("", null, Texts.Get("menu.resume"));
            // A slightly bigger activation zone, like the other "back" buttons.
            resume.ZoneFactor = 1.3;
            resume.Place(layer, surface, Manager.ScreenWidth / 2, Manager.ScreenHeight / 2, size);
            _buttons.Add(resume);

            // The gaze is lost when the pause starts: nothing is aimed at yet. Reset (and not
            // ResetAndBlock): when the eyes come back right on the button, it can be used at
            // once, without looking away first.
            _aimer.Reset();
            layer.ShowDragSurface();
        }
    }
}
