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
            "gray", "white", "yellow", "green", "lightBlue", "pink"
        };

        public static readonly string[] TextKeys =
        {
            "circleColor.gray", "circleColor.white", "circleColor.yellow",
            "circleColor.green", "circleColor.lightBlue", "circleColor.pink"
        };

        private static readonly Color[] MovementColors =
        {
            Colors.DarkGray,                     // the former colour of the circle
            Colors.White,
            Color.FromRgb(0xFF, 0xD6, 0x00),     // yellow
            Color.FromRgb(0x00, 0xE6, 0x76),     // green
            Color.FromRgb(0x40, 0xC4, 0xFF),     // light blue
            Color.FromRgb(0xFF, 0x40, 0x81)      // pink
        };

        private static readonly Color[] FixedColors =
        {
            Colors.LightGray,                    // the former colour in fixed gaze
            Colors.White,
            Color.FromRgb(0xFF, 0xD6, 0x00),
            Color.FromRgb(0x00, 0xE6, 0x76),
            Color.FromRgb(0x40, 0xC4, 0xFF),
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
}
