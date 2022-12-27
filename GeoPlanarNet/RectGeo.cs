using System;
using System.Collections.Generic;
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
        /// Get width/height of the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetDimensions(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY, out double width, out double height)
        {
            GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            width = PointGeo.DistanceTo(rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightBottomY);
            height = PointGeo.DistanceTo(rectLeftTopX, rectRightTopY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Get point of the rectangle base on diagonal 0-2 points.
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        public static void GetPoints(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY,
            out double rectRightTopX, out double rectRightTopY, out double rectLeftBottomX, out double rectLeftBottomY)
        {
            GetCenter(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var centerPointX, out var centerPointY);

            var angle = PointGeo.GetAngle(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);

            var cos = Math.Cos(-angle);
            var sin = Math.Sin(-angle);

            var x1u = cos * (rectLeftTopX - centerPointX) - sin * (rectLeftTopY - centerPointY) + centerPointX;
            var y1u = sin * (rectLeftTopX - centerPointX) + cos * (rectLeftTopY - centerPointY) + centerPointY;
            var x3u = cos * (rectRightBottomX - centerPointX) - sin * (rectRightBottomY - centerPointY) + centerPointX;
            var y3u = sin * (rectRightBottomX - centerPointX) + cos * (rectRightBottomY - centerPointY) + centerPointY;

            cos = Math.Cos(angle);
            sin = Math.Sin(angle);

            rectRightTopX = cos * (x1u - centerPointX) - sin * (y3u - centerPointY) + centerPointX;
            rectRightTopY = sin * (x1u - centerPointX) + cos * (y3u - centerPointY) + centerPointY;
            rectLeftBottomX = cos * (x3u - centerPointX) - sin * (y1u - centerPointY) + centerPointX;
            rectLeftBottomY = sin * (x3u - centerPointX) + cos * (y1u - centerPointY) + centerPointY;
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
            centerPointX = rectLeftTopX + (rectRightBottomX - rectLeftTopX) * 0.5;
            centerPointY = rectLeftTopY + (rectRightBottomY - rectLeftTopY) * 0.5;
        }
    }
}
