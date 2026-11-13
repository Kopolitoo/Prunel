using System;
using System.Windows.Media;

namespace Prunel
{
    /// <summary>
    /// The colours the gaze circle can take (step color-themes, setting [CircleColor]).
    ///
    /// Each colour has three things, at the same place in the three lists below:
    ///   - its NAME in settings.json ("gray", "white"...): a word, so the file stays
    ///     readable and the order of the list can change one day without mixing them up;
    ///   - its TEXT KEY in the language files ("circleColor.gray" → "Gris");
    ///   - its two BRUSHES: one for movement mode (discreet), one for fixed gaze mode.
    ///
    /// Names are saved as words, so a new colour can be added anywhere in the list.
    ///
    /// "gray" is the circle as it always was: dark grey in movement, light grey in fixed
    /// gaze. The other colours are bright, so they stand out on most backgrounds; fixed gaze
    /// uses the same colour (it is already more opaque and thicker there).
    /// </summary>
    internal static class CircleColors
    {
        /// <summary>The default colour, and the one an unknown word in the file becomes.</summary>
        public const string DefaultName = "gray";

        public static readonly string[] Names =
        {
            "gray", "white", "yellow", "green", "lightBlue", "darkBlue", "purple", "pink"
        };

        public static readonly string[] TextKeys =
        {
            "circleColor.gray", "circleColor.white", "circleColor.yellow",
            "circleColor.green", "circleColor.lightBlue", "circleColor.darkBlue",
            "circleColor.purple", "circleColor.pink"
        };

        private static readonly Color[] MovementColors =
        {
            Colors.DarkGray,                     // the former colour of the circle
            Colors.White,
            Color.FromRgb(0xFF, 0xD6, 0x00),     // yellow
            Color.FromRgb(0x00, 0xE6, 0x76),     // green
            Color.FromRgb(0x40, 0xC4, 0xFF),     // light blue
            Color.FromRgb(0x29, 0x4B, 0xFF),     // dark blue
            Color.FromRgb(0xA0, 0x40, 0xFF),     // purple
            Color.FromRgb(0xFF, 0x40, 0x81)      // pink
        };

        private static readonly Color[] FixedColors =
        {
            Colors.LightGray,                    // the former colour in fixed gaze
            Colors.White,
            Color.FromRgb(0xFF, 0xD6, 0x00),
            Color.FromRgb(0x00, 0xE6, 0x76),
            Color.FromRgb(0x40, 0xC4, 0xFF),
            Color.FromRgb(0x29, 0x4B, 0xFF),
            Color.FromRgb(0xA0, 0x40, 0xFF),
            Color.FromRgb(0xFF, 0x40, 0x81)
        };

        // The brushes, created once and frozen ("Freeze": WPF then draws them faster).
        private static readonly SolidColorBrush[] MovementBrushes = MakeBrushes(MovementColors);
        private static readonly SolidColorBrush[] FixedBrushes = MakeBrushes(FixedColors);

        /// <summary>The place of a colour name in the list; 0 (grey) if the name is unknown.</summary>
        public static int IndexOf(string name)
        {
            int index = Array.IndexOf(Names, name ?? "");
            return index < 0 ? 0 : index;
        }

        /// <summary>The name at a place of the list (brought back within the list).</summary>
        public static string NameAt(int index)
        {
            return Names[Math.Max(0, Math.Min(Names.Length - 1, index))];
        }

        /// <summary>The brush of the circle for a colour name, in movement or fixed gaze mode.</summary>
        public static SolidColorBrush Brush(string name, bool fixedValue)
        {
            int index = IndexOf(name);
            return fixedValue ? FixedBrushes[index] : MovementBrushes[index];
        }

        private static SolidColorBrush[] MakeBrushes(Color[] colors)
        {
            SolidColorBrush[] brushes = new SolidColorBrush[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                brushes[i] = new SolidColorBrush(colors[i]);
                brushes[i].Freeze();
            }
            return brushes;
        }
    }

    /// <summary>
    /// How the gaze circle is drawn, computed from the settings ([CircleColor],
    /// [CircleThickness], [HighContrast]) in one place, so that the real circle (OverlayWindow)
    /// and its preview in the "Colours" tab (SettingsWindow) always look the same.
    ///
    /// The circle is two rings: a TOP line (the colour) and an UNDER line drawn just beneath
    /// it. Thicknesses and the offset are in units of the 4K screen at 200 % (see
    /// ScreenMetrics.Units); each window converts them to its own units.
    /// </summary>
    internal struct CircleStyle
    {
        public Brush TopBrush;
        public double TopThickness;
        public double TopOpacity;
        public Brush UnderBrush;
        public double UnderThickness;
        public double UnderOpacity;

        /// <summary>How much larger the under ring's radius is than the circle's.</summary>
        public double UnderOffset;

        // "Freeze" locks the brush: WPF then draws it faster.
        private static readonly SolidColorBrush UsualUnder = Frozen(Colors.LightGray);
        private static readonly SolidColorBrush ContrastUnder = Frozen(Colors.Black);

        /// <summary>
        /// The style of the circle. fixedValue: fixed gaze circle (more visible). damping: 1 =
        /// usual opacity, 0.5 = twice as transparent (scroll mode).
        /// </summary>
        public static CircleStyle For(AppSettings p, bool fixedValue, double damping)
        {
            // [CircleThickness]: 100 % = the usual lines, 200 % = twice as thick.
            double thickness = p.CircleThickness / 100;
            CircleStyle r = new CircleStyle();
            r.TopBrush = CircleColors.Brush(p.CircleColor, fixedValue);
            r.TopThickness = (fixedValue ? 1.5 : 1) * thickness;
            if (p.HighContrast)
            {
                // Reinforced contrast: an opaque coloured line, edged on both sides by an
                // opaque black line (the under ring, wider). It stays visible on a light
                // background as well as a dark one. WPF draws an ellipse's line INSIDE its
                // size: the under ring is therefore larger by the width of one edge, so the
                // black shows outside the coloured line as well as inside.
                double edge = 1.5 * thickness;
                r.TopOpacity = damping;
                r.UnderBrush = ContrastUnder;
                r.UnderThickness = r.TopThickness + 2 * edge;
                r.UnderOpacity = damping;
                r.UnderOffset = edge;
            }
            else
            {
                // Usual circle: discreet, half transparent, with a light line just outside.
                r.TopOpacity = (fixedValue ? 0.6 : 0.3) * damping;
                r.UnderBrush = UsualUnder;
                r.UnderThickness = (fixedValue ? 2.5 : 2) * thickness;
                r.UnderOpacity = (fixedValue ? 0.7 : 0.5) * damping;
                r.UnderOffset = 1 * thickness;
            }
            return r;
        }

        /// <summary>Thickness of the progress ring: larger with [HighContrast].</summary>
        public static double RingThickness(AppSettings p)
        {
            return p.HighContrast ? 9 : 6;
        }

        private static SolidColorBrush Frozen(Color color)
        {
            SolidColorBrush brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }
    }
}
