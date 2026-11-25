using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Prunel
{
    /// <summary>
    /// A cross drawn on a black screen: a thick black line underneath, a thin white line on top,
    /// so that it can be seen on every background. Used by the action choice (the aimed point,
    /// in place of the cursor) and by the magnifier during a drag and drop (the start point,
    /// issue #170).
    /// </summary>
    internal static class Cross
    {
        /// <summary>
        /// Draws a cross centered on (x, y), in screen pixels. halfLength4K: half the length of
        /// each branch, in 4K screen pixels (converted with ScreenMetrics.Px). thick / thin:
        /// thicknesses of the black and white lines, in units of the reference screen (see
        /// ScreenMetrics.cs).
        /// </summary>
        public static void Draw(OverlayWindow layer, Canvas screen, double x, double y,
                                double halfLength4K, double thick, double thin)
        {
            Point center = layer.ToWpf(x, y);
            double half = layer.LengthToWpf(ScreenMetrics.Px(halfLength4K));
            double thickWpf = ScreenMetrics.Units(thick);
            double thinWpf = ScreenMetrics.Units(thin);

            AddLine(screen, center.X - half, center.Y, center.X + half, center.Y, Brushes.Black, thickWpf);
            AddLine(screen, center.X, center.Y - half, center.X, center.Y + half, Brushes.Black, thickWpf);
            AddLine(screen, center.X - half, center.Y, center.X + half, center.Y, Palette.Text, thinWpf);
            AddLine(screen, center.X, center.Y - half, center.X, center.Y + half, Palette.Text, thinWpf);
        }

        private static void AddLine(Canvas screen, double x1, double y1, double x2, double y2,
                                    Brush color, double thickness)
        {
            Line stroke = new Line();
            stroke.X1 = x1;
            stroke.Y1 = y1;
            stroke.X2 = x2;
            stroke.Y2 = y2;
            stroke.Stroke = color;
            stroke.StrokeThickness = thickness;
            screen.Children.Add(stroke);
        }
    }
}
