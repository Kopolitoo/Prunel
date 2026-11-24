using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prunel
{
    /// <summary>
    /// THE ROUND PHOTO of the action choice and of the magnifier (user request): the screenshot
    /// around P is still a square (Windows only takes rectangles), but only a DISC of it is
    /// shown, centered on P, with a thin gray ring around it.
    ///
    /// The disc is always centered on P, and P is always in the center of the screen:
    ///  - in the middle of the screen, the square is centered on P, so the disc is the circle
    ///    inscribed in the square (the four corners are hidden);
    ///  - near an edge of the screen, the square is shifted to stay on the screen (P is no longer
    ///    in its center). The disc stays centered on P and is simply cut flat where the photo
    ///    stops: that flat side is the edge of the real screen. A point in a corner of the screen
    ///    can thus still be reached.
    /// The enlarged image is placed so that P falls in the center of the screen; the visible part
    /// never goes beyond the disc, so it takes the same room as the old square photo.
    /// </summary>
    internal static class RoundPhoto
    {
        /// <summary>
        /// Adds the photo (disc) and its ring to the black screen.
        /// photo: the screenshot (side × side real pixels). zoom: the enlargement.
        /// pInPhotoX / pInPhotoY: where P is inside the photo, in real pixels (0..side).
        /// centerX / centerY: where P must appear, in screen pixels (center of the screen).
        /// Returns the top-left corner of the enlarged image, in screen pixels: the modes use it
        /// to convert a point of the photo back to real coordinates.
        /// group: the photo and its ring, together in one element, so that the opening animation
        /// (issue #154, OverlayWindow.AnimateChoiceOpening) can make them grow as one.
        /// </summary>
        public static Point Add(OverlayWindow layer, Canvas screen, BitmapSource photo, double side,
                                double zoom, double pInPhotoX, double pInPhotoY,
                                double centerX, double centerY, out UIElement group)
        {
            // The photo and its ring go in a canvas without size at the top-left corner of the
            // black screen: their positions stay those of the black screen.
            Canvas photoGroup = new Canvas();
            Canvas.SetLeft(photoGroup, 0);
            Canvas.SetTop(photoGroup, 0);
            screen.Children.Add(photoGroup);
            group = photoGroup;

            double enlargedSide = side * zoom;
            double left = centerX - pInPhotoX * zoom;
            double top = centerY - pInPhotoY * zoom;

            // All the sizes below are in WPF units (the overlay converts them).
            Point corner = layer.ToWpf(left, top);
            double sideWpf = layer.LengthToWpf(enlargedSide);
            double radiusWpf = sideWpf / 2;
            // Center of the disc (P), inside the image.
            Point centerInImage = new Point(layer.LengthToWpf(pInPhotoX * zoom),
                                            layer.LengthToWpf(pInPhotoY * zoom));

            Image image = new Image();
            image.Source = photo;
            image.Stretch = Stretch.Fill;
            // "Nearest neighbour": each pixel becomes a sharp square, instead of being softened
            // (blurred). One sees exactly where each real pixel falls, and text stays readable.
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.NearestNeighbor);
            image.Width = sideWpf;
            image.Height = sideWpf;
            // Only the disc is drawn. Outside the image there is nothing to draw anyway, which
            // gives the flat side near an edge of the screen.
            image.Clip = new EllipseGeometry(centerInImage, radiusWpf, radiusWpf);
            Canvas.SetLeft(image, corner.X);
            Canvas.SetTop(image, corner.Y);
            photoGroup.Children.Add(image);

            // The thin gray ring, just outside the visible part: the disc, cut by the edges of
            // the image (both grown by half the thickness, so the ring does not cover the photo).
            double stroke = ScreenMetrics.Units(2);   // units of the reference screen (ScreenMetrics.cs)
            double grow = stroke / 2;
            Point center = new Point(corner.X + centerInImage.X, corner.Y + centerInImage.Y);
            Geometry disc = new EllipseGeometry(center, radiusWpf + grow, radiusWpf + grow);
            Geometry square = new RectangleGeometry(new Rect(corner.X - grow, corner.Y - grow,
                                                             sideWpf + stroke, sideWpf + stroke));
            Path ring = new Path();
            ring.Data = new CombinedGeometry(GeometryCombineMode.Intersect, disc, square);
            ring.Stroke = Brushes.Gray;
            ring.StrokeThickness = stroke;
            photoGroup.Children.Add(ring);

            return new Point(left, top);
        }

        /// <summary>
        /// True if the point (x, y), in screen pixels, is on the visible photo: inside the disc
        /// (center centerX / centerY, radius half of the enlarged side) and inside the image
        /// (top-left corner imageCorner, side enlargedSide).
        /// </summary>
        public static bool Contains(double x, double y, double centerX, double centerY,
                                    Point imageCorner, double enlargedSide)
        {
            double radius = enlargedSide / 2;
            double dx = x - centerX;
            double dy = y - centerY;
            if (dx * dx + dy * dy > radius * radius)
            {
                return false;
            }
            return x >= imageCorner.X && x <= imageCorner.X + enlargedSide &&
                   y >= imageCorner.Y && y <= imageCorner.Y + enlargedSide;
        }
    }
}
