using System;
using System.Collections.Generic;
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
        public static double GetArea(PointF rectLeftTop, PointF rectRightBottom)
        {
            return GetArea(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y);
        }

        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <returns> Area of the rectangle </returns>
        public static double GetArea(Point rectLeftTop, Point rectRightBottom)
        {
            return GetArea(rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y);
        }

        /// <summary>
        /// Get area of the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Area of the rectangle </returns>
        public static double GetArea(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
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
        /// Get points of the rectangle based on diagonal 0-2 points
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
        /// Get points of the rectangle based on diagonal 0-2 points
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
        /// Get points of the rectangle based on diagonal 0-2 points
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

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> True, if has intersection </returns>
        public static bool HasCircleIntersection(float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY, PointF circleCenter, float radius)
        {
            return HasCircleIntersection(circleCenter.X, circleCenter.Y, radius, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> True, if has intersection </returns>
        public static bool HasCircleIntersection(int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY, Point circleCenter, int radius)
        {
            return HasCircleIntersection(circleCenter.X, circleCenter.Y, radius, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <returns> True, if has intersection </returns>
        public static bool HasCircleIntersection(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY, double circleCenterX, double circleCenterY, double radius)
        {
            return CircleGeo.HasRectIntersection(circleCenterX, circleCenterY, radius, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        public static bool HasCircleIntersection(PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom, double circleCenterX, double circleCenterY, double radius)
        {
            return HasCircleIntersection(circleCenterX, circleCenterY, radius, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        public static bool HasCircleIntersection(Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom, double circleCenterX, double circleCenterY, double radius)
        {
            return HasCircleIntersection(circleCenterX, circleCenterY, radius, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        public static bool HasCircleIntersection(double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                                 double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY,
                                                 double circleCenterX, double circleCenterY, double radius)
        {
            return CircleGeo.HasRectIntersection(circleCenterX, circleCenterY, radius, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasSegmentIntersection(RectangleF rect, PointF segmentStart, PointF segmentEnd)
        {
            return SegmentGeo.HasRectIntersection(segmentStart, segmentEnd, rect);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top point </param>
        /// <param name="rectRightBottom"> Rectangle right bottom point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasSegmentIntersection(PointF rectLeftTop, PointF rectRightBottom, PointF segmentStart, PointF segmentEnd)
        {
            return SegmentGeo.HasRectIntersection(segmentStart, segmentEnd, rectLeftTop, rectRightBottom);
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasSegmentIntersection(Rectangle rect, Point segmentStart, Point segmentEnd)
        {
            return SegmentGeo.HasRectIntersection(segmentStart, segmentEnd, rect);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top point </param>
        /// <param name="rectRightBottom"> Rectangle right bottom point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasSegmentIntersection(Point rectLeftTop, Point rectRightBottom, Point segmentStart, Point segmentEnd)
        {
            return SegmentGeo.HasRectIntersection(segmentStart, segmentEnd, rectLeftTop, rectRightBottom);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top point </param>
        /// <param name="rectRightBottom"> Rectangle right bottom point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindSegmentIntersection(PointF rectLeftTop, PointF rectRightBottom, PointF segmentStart, PointF segmentEnd, out PointF intersection1, out PointF intersection2)
        {
            return SegmentGeo.FindRectIntersection(segmentStart, segmentEnd, rectLeftTop, rectRightBottom, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindSegmentIntersection(RectangleF rect, PointF segmentStart, PointF segmentEnd, out PointF intersection1, out PointF intersection2)
        {
            return SegmentGeo.FindRectIntersection(segmentStart, segmentEnd, rect, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindSegmentIntersection(Rectangle rect, Point segmentStart, Point segmentEnd, out Point intersection1, out Point intersection2)
        {
            return SegmentGeo.FindRectIntersection(segmentStart, segmentEnd, rect, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="segmentStartX"> Line point 1: X coordinate </param>
        /// <param name="segmentStartY"> Line point 1: Y coordinate </param>
        /// <param name="segmentEndX"> Line point 2: X coordinate </param>
        /// <param name="segmentEndY"> Line point 2: Y coordinate </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindSegmentIntersection(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY,
                                                out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            return SegmentGeo.FindRectIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY,
                                                   out intersection1X, out intersection1Y, out intersection2X, out intersection2Y);
        }

        /// <summary>
        /// Get the rectangle with one side equal to segment, another side equal to length
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rectangleSideLength"> Another side length </param>
        /// <returns> Rectangle </returns>
        public static IList<PointF> CreateFromSegment(PointF segmentStart, PointF segmentEnd, float rectangleSideLength)
        {
            return SegmentGeo.GetRectangle(segmentStart, segmentEnd, rectangleSideLength);
        }

        /// <summary>
        /// Get shortest distance from point to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(this PointF point, RectangleF rect)
        {
            return point.DistanceToRect(rect);
        }

        /// <summary>
        /// Get shortest distance from point to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(this Point point, Rectangle rect)
        {
            return point.DistanceToRect(rect);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(this PointF point, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            return point.DistanceToRect(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(this Point point, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            return point.DistanceToRect(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            return PointGeo.DistanceToRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(this PointF point, PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            return point.DistanceToRect(rectLeftTop, rectRightTop, rectRightBottom, rectLeftBottom);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(this Point point, Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            return point.DistanceToRect(rectLeftTop, rectRightTop, rectRightBottom, rectLeftBottom);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToPoint(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY)
        {
            return PointGeo.DistanceToRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Check if the axis-oriented rectangle contains the point
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the axis-oriented rectangle contains the point </returns>
        public static bool Contains(RectangleF rect, PointF point)
        {
            return point.BelongsToRect(rect);
        }

        /// <summary>
        /// Check if the axis-oriented rectangle contains the point
        /// </summary>
        /// <param name="rect"> Rectangle </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the axis-oriented rectangle contains the point </returns>
        public static bool Contains(Rectangle rect, Point point)
        {
            return point.BelongsToRect(rect);
        }

        /// <summary>
        /// Check if the rectangle contains the point
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the rectangle contains the point </returns>
        public static bool Contains(float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY, PointF point)
        {
            return point.BelongsToRect(rectLeftTopX,rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the rectangle contains the point
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the rectangle contains the point </returns>
        public static bool Contains(int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY, Point point)
        {
            return point.BelongsToRect(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the rectangle contains the point
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the rectangle contains the point </returns>
        public static bool Contains(double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY, double pointX, double pointY)
        {
            return PointGeo.BelongsToRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the rectangle contains the point
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the rectangle contains the point </returns>
        public static bool Contains(PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom, PointF point)
        {
            return point.BelongsToRect(rectLeftTop, rectRightTop, rectRightBottom, rectLeftBottom);
        }

        /// <summary>
        /// Check if the rectangle contains the point
        /// </summary>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the rectangle contains the point </returns>
        public static bool Contains(Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom, Point point)
        {
            return point.BelongsToRect(rectLeftTop, rectRightTop, rectRightBottom, rectLeftBottom);
        }

        /// <summary>
        /// Check if the rectangle contains the point
        /// </summary>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the rectangle contains the point </returns>
        public static bool Contains(double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                    double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY, double pointX, double pointY)
        {
            return PointGeo.BelongsToRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
        }
    }
}
