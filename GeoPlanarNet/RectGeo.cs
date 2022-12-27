using System.Drawing;

namespace GeoPlanarNet
{
    public static class RectGeo
    {
        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> Area of the rectangle </returns>
        public static double Area(PointF rectLeftTop, PointF rectRightBottom)
        {
            return Area(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y);
        }

        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> Area of the rectangle </returns>
        public static double Area(Point rectLeftTop, Point rectRightBottom)
        {
            return Area(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y);
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

        /// <summary>
        /// Get the center point of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> Center point </returns>
        public static PointF GetCenter(PointF rectLeftTop, PointF rectRightBottom)
        {
            GetCenter(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out var centerPointX, out var centerPointY);
            return new PointF((int)centerPointX, (int)centerPointY);
        }

        /// <summary>
        /// Get the center point of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> Center point </returns>
        public static Point GetCenter(Point rectLeftTop, Point rectRightBottom)
        {
            GetCenter(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out var centerPointX, out var centerPointY);
            return new Point((int)centerPointX, (int)centerPointY);
        }

        /// <summary>
        /// Get the center point of the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="centerPointX"> Center point: X coordinate </param>
        /// <param name="centerPointY"> Center point: Y coordinate </param>
        public static void GetCenter(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY, out double centerPointX, out double centerPointY)
        {
            centerPointX = (rectLeftTopX + rectRightBottomX) / 2;
            centerPointY = (rectLeftTopY + rectRightBottomY) / 2;
        }
    }
}
