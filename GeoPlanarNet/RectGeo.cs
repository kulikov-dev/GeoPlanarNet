using System;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the rectangle
    /// </summary>
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
            centerPointX = rectLeftTopX + (rectRightBottomX - rectLeftTopX) * 0.5;
            centerPointY = rectLeftTopY + (rectRightBottomY - rectLeftTopY) * 0.5;
        }

        /// <summary>
        /// Get width/height of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetDimensions(PointF rectLeftTop, PointF rectRightBottom, out double width, out double height)
        {
            GetDimensions(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out width, out height);
        }

        /// <summary>
        /// Get width/height of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetDimensions(Point rectLeftTop, Point rectRightBottom, out double width, out double height)
        {
            GetDimensions(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out width, out height);
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

            GetDimensions(rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY, out width, out height);
        }

        /// <summary>
        /// Get width/height of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetDimensions(PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom, out double width, out double height)
        {
            GetDimensions(rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y, out width, out height);
        }

        /// <summary>
        /// Get width/height of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetDimensions(Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom, out double width, out double height)
        {
            GetDimensions(rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y, out width, out height);
        }

        /// <summary>
        /// Get width/height of the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetDimensions(double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY,
                                        out double width, out double height)
        {
            width = PointGeo.DistanceTo(rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY);
            height = PointGeo.DistanceTo(rectLeftTopX, rectLeftTopY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Get points of the rectangle base on diagonal 0-2 points
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        public static void GetPoints(PointF rectLeftTop, PointF rectRightBottom, out PointF rectRightTop, out PointF rectLeftBottom)
        {
            GetPoints(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            rectRightTop = new PointF((float)rectRightTopX, (float)rectRightTopY);
            rectLeftBottom = new PointF((float)rectLeftBottomX, (float)rectLeftBottomY);
        }

        /// <summary>
        /// Get points of the rectangle base on diagonal 0-2 points
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        public static void GetPoints(Point rectLeftTop, Point rectRightBottom, out Point rectRightTop, out Point rectLeftBottom)
        {
            GetPoints(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            rectRightTop = new Point((int)rectRightTopX, (int)rectRightTopY);
            rectLeftBottom = new Point((int)rectLeftBottomX, (int)rectLeftBottomY);
        }

        /// <summary>
        /// Get points of the rectangle base on diagonal 0-2 points
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

            var x1U = cos * (rectLeftTopX - centerPointX) - sin * (rectLeftTopY - centerPointY) + centerPointX;
            var y1U = sin * (rectLeftTopX - centerPointX) + cos * (rectLeftTopY - centerPointY) + centerPointY;
            var x3U = cos * (rectRightBottomX - centerPointX) - sin * (rectRightBottomY - centerPointY) + centerPointX;
            var y3U = sin * (rectRightBottomX - centerPointX) + cos * (rectRightBottomY - centerPointY) + centerPointY;

            cos = Math.Cos(angle);
            sin = Math.Sin(angle);

            rectRightTopX = cos * (x1U - centerPointX) - sin * (y3U - centerPointY) + centerPointX;
            rectRightTopY = sin * (x1U - centerPointX) + cos * (y3U - centerPointY) + centerPointY;
            rectLeftBottomX = cos * (x3U - centerPointX) - sin * (y1U - centerPointY) + centerPointX;
            rectLeftBottomY = sin * (x3U - centerPointX) + cos * (y1U - centerPointY) + centerPointY;
        }

        /// <summary>
        /// Get the AABB rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> AABB rect </returns>
        public static RectangleF GetAABB(PointF rectLeftTop, PointF rectRightBottom)
        {
            GetAABB(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new RectangleF((float)leftTopX, (float)leftTopY, (float)width, (float)height);
        }

        /// <summary>
        /// Get the AABB rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> AABB rect </returns>
        public static Rectangle GetAABB(Point rectLeftTop, Point rectRightBottom)
        {
            GetAABB(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the AABB rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="leftTopX"> AABB left top: X coordinate </param>
        /// <param name="leftTopY"> AABB left top: Y coordinate </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetAABB(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY,
                                   out double leftTopX, out double leftTopY, out double width, out double height)
        {
            GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            GetAABB(rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY, out leftTopX, out leftTopY, out width, out height);
        }

        /// <summary>
        /// Get the AABB rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> AABB rect </returns>
        public static RectangleF GetAABB(PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            GetAABB(rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new RectangleF((float)leftTopX, (float)leftTopY, (float)width, (float)height);
        }

        /// <summary>
        /// Get the AABB rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> AABB rect </returns>
        public static Rectangle GetAABB(Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            GetAABB(rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the AABB rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        /// <param name="leftTopX"> AABB left top: X coordinate </param>
        /// <param name="leftTopY"> AABB left top: Y coordinate </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetAABB(double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY,
                                        out double leftTopX, out double leftTopY, out double width, out double height)
        {
            var minX = Math.Min(rectLeftTopX, Math.Min(rectRightTopX, Math.Min(rectRightBottomX, rectLeftBottomX)));
            var minY = Math.Min(rectLeftTopY, Math.Min(rectRightTopY, Math.Min(rectRightBottomY, rectLeftBottomY)));
            var maxX = Math.Max(rectLeftTopX, Math.Max(rectRightTopX, Math.Max(rectRightBottomX, rectLeftBottomX)));
            var maxY = Math.Max(rectLeftTopY, Math.Max(rectRightTopY, Math.Max(rectRightBottomY, rectLeftBottomY)));

            leftTopX = minX;
            leftTopY = minY;
            width = maxX - minX;
            height = maxY - minY;
        }
    }
}
