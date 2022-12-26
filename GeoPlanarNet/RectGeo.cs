using System.Drawing;

namespace GeoPlanarNet
{
    public static class RectGeo
    {

        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Area of the rectangle </returns>
        public static double Area(this RectangleF rect)
        {
            return rect.Width * rect.Height;
        }

        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Area of the rectangle </returns>
        public static double Area(this Rectangle rect)
        {
            return rect.Width * rect.Height;
        }

        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Area of the rectangle </returns>
        public static double Area(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            var width = rectRightBottomX - rectLeftTopX;
            var height = rectRightBottomY - rectLeftTopY;

            return width * height;
        }
    }
}
