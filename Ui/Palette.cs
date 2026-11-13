using System.Windows.Media;

namespace Prunel
{
    /// <summary>
    /// The bright colours of Prunel's own screens (keyboard, menu bar, action choice,
    /// magnifier, settings...), in a DAY version and a softer NIGHT version (step
    /// color-themes, setting [NightMode]).
    ///
    /// At night, a pure white or a bright green on a black screen dazzles: the night version
    /// uses a light grey instead of white and darker, less saturated greens, blues and amber.
    /// The dark backgrounds do not change (they are already dark).
    ///
    /// Each property reads [NightMode] when it is called: what is drawn AFTER a change uses
    /// the new colours (the settings page is redrawn at once; the other screens at their next
    /// opening). The brushes are created once and frozen ("Freeze": WPF draws them faster).
    ///
    /// The colour of the gaze circle is not here: it is its own setting ([CircleColor]).
    /// </summary>
    internal static class Palette
    {
        private static bool Night
        {
            get { return AppSettings.Current.NightMode; }
        }

        // ── Day colours (the colours used until now).
        private static readonly Brush DayText = Frozen(Colors.White);
        private static readonly Brush DaySettingsText = Frozen(Color.FromRgb(0xEE, 0xF1, 0xF4));
        private static readonly Brush DayGreen = Frozen(Color.FromRgb(0x00, 0xC8, 0x53));
        private static readonly Brush DayGazeGreen = Frozen(Colors.LimeGreen);
        private static readonly Brush DayAccent = Frozen(Color.FromRgb(0x6F, 0xB4, 0xFF));
        private static readonly Brush DayAmber = Frozen(Color.FromRgb(0xFF, 0xC8, 0x57));
        private static readonly Brush DaySwitch = Frozen(Color.FromRgb(0x0D, 0x6E, 0xFD));
        private static readonly Color DayOutline = Color.FromRgb(0x7F, 0xB8, 0xF0);

        // ── Night colours: same hues, darker and softer.
        private static readonly Brush NightText = Frozen(Color.FromRgb(0xB4, 0xB4, 0xB4));
        private static readonly Brush NightGreen = Frozen(Color.FromRgb(0x1E, 0x7A, 0x3E));
        private static readonly Brush NightGazeGreen = Frozen(Color.FromRgb(0x3C, 0x8C, 0x3C));
        private static readonly Brush NightAccent = Frozen(Color.FromRgb(0x4A, 0x78, 0xA8));
        private static readonly Brush NightAmber = Frozen(Color.FromRgb(0xA8, 0x86, 0x3C));
        private static readonly Brush NightSwitch = Frozen(Color.FromRgb(0x1C, 0x4A, 0x96));
        private static readonly Color NightOutline = Color.FromRgb(0x50, 0x78, 0xA0);

        /// <summary>Text and symbols (pure white by day).</summary>
        public static Brush Text
        {
            get { return Night ? NightText : DayText; }
        }

        /// <summary>Text of the settings page (a slightly blue white by day).</summary>
        public static Brush SettingsText
        {
            get { return Night ? NightText : DaySettingsText; }
        }

        /// <summary>The green of the progress rings, flashes and chosen items.</summary>
        public static Brush Green
        {
            get { return Night ? NightGreen : DayGreen; }
        }

        /// <summary>The green gaze circle of the full-screen modes (action choice, lists...).</summary>
        public static Brush GazeGreen
        {
            get { return Night ? NightGazeGreen : DayGazeGreen; }
        }

        /// <summary>The light blue of the settings page (chosen value, hover outline).</summary>
        public static Brush Accent
        {
            get { return Night ? NightAccent : DayAccent; }
        }

        /// <summary>The amber of the "+ myword" cell of the keyboard.</summary>
        public static Brush Amber
        {
            get { return Night ? NightAmber : DayAmber; }
        }

        /// <summary>The blue track of a switch that is on (settings).</summary>
        public static Brush Switch
        {
            get { return Night ? NightSwitch : DaySwitch; }
        }

        /// <summary>The colour of the hover outline of a keyboard key.</summary>
        public static Color Outline
        {
            get { return Night ? NightOutline : DayOutline; }
        }

        private static Brush Frozen(Color color)
        {
            SolidColorBrush brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }
    }
}
