using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Prunel
{
    /// <summary>
    /// A SCREENSHOT kept in memory and handed from the magnifier to the action choice (and back),
    /// so that going from one to the other is a smooth transition (issue #154, user request):
    /// the black screen stays, no new photo is taken (a new photo needs the black screen hidden
    /// for a moment, which makes the screen flash), and the new photo starts its opening
    /// animation where the point P was shown on the screen just left.
    ///
    /// The magnifier and the action choice photograph a zone wider than what they show
    /// (Take): a square of side 4 × the photo side, centered on P. The point placed in the
    /// magnifier is always inside the magnifier's photo, so the photo of the next action choice
    /// (centered on that point) is inside the wide zone, and is simply cut out of it (Crop).
    /// If it ever is not (Contains), the next mode takes a new photo as before.
    ///
    /// Only an image of the screen, kept in memory for a few seconds: no gaze data is saved.
    /// </summary>
    internal sealed class ScreenSnapshot
    {
        /// <summary>The photographed zone: its image and its top-left corner, in screen pixels.</summary>
        private readonly BitmapSource _image;
        private readonly int _left;
        private readonly int _top;

        /// <summary>
        /// Where the point P was shown on the screen being left (screen pixels), and its
        /// enlargement there: the start of the next opening animation (OverlayWindow.AnimateChoiceOpening).
        /// </summary>
        public double FromX { get; private set; }
        public double FromY { get; private set; }
        public double FromZoom { get; private set; }

        private ScreenSnapshot(BitmapSource image, int left, int top)
        {
            _image = image;
            _left = left;
            _top = top;
            FromZoom = 1;
        }

        /// <summary>
        /// Photographs the square of side 4 × side centered on (px, py), cut by the edges of the
        /// screen (width × height). Everything Prunel draws must already be hidden.
        /// Returns null if the photo is impossible.
        /// </summary>
        public static ScreenSnapshot Take(double px, double py, int side, double width, double height)
        {
            int left = (int)Math.Max(0, Math.Floor(px - 2 * side));
            int top = (int)Math.Max(0, Math.Floor(py - 2 * side));
            int right = (int)Math.Min(width, Math.Ceiling(px + 2 * side));
            int bottom = (int)Math.Min(height, Math.Ceiling(py + 2 * side));
            if (right - left < 1 || bottom - top < 1)
            {
                return null;
            }

            BitmapSource image = ScreenCapture.Capture(left, top, right - left, bottom - top);
            return image == null ? null : new ScreenSnapshot(image, left, top);
        }

        /// <summary>True if the square (x, y, side), in screen pixels, is fully inside the snapshot.</summary>
        public bool Contains(int x, int y, int side)
        {
            return x >= _left && y >= _top &&
                   x + side <= _left + _image.PixelWidth &&
                   y + side <= _top + _image.PixelHeight;
        }

        /// <summary>The square (x, y, side), in screen pixels, cut out of the snapshot (check Contains first).</summary>
        public BitmapSource Crop(int x, int y, int side)
        {
            CroppedBitmap part = new CroppedBitmap(_image, new Int32Rect(x - _left, y - _top, side, side));
            part.Freeze();
            return part;
        }

        /// <summary>
        /// The same snapshot, to hand over to the next mode, with the place (screen pixels) and
        /// the enlargement where P is shown now: its opening animation starts from there.
        /// </summary>
        public ScreenSnapshot HandOver(double fromX, double fromY, double fromZoom)
        {
            ScreenSnapshot next = new ScreenSnapshot(_image, _left, _top);
            next.FromX = fromX;
            next.FromY = fromY;
            next.FromZoom = fromZoom;
            return next;
        }
    }
}
