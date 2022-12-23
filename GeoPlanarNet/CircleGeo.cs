using System.Drawing;

namespace GeoPlanarNet
{
    public static class CircleGeo
    {
        /// <summary>
        /// Get the circle area
        /// </summary>
        /// <param name="radius"> Radius </param>
        /// <returns> Area </returns>
        public static double Area(double radius)
        {
            return radius * radius * Math.PI;
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="centerPoint"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <returns> Point on the circle edge </returns>
        public static PointF GetEdgePoint(PointF centerPoint, float radius, double angleRad)
        {
            GetEdgePoint(centerPoint.X, centerPoint.Y, radius, angleRad, out double x, out double y);
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="centerPoint"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <returns> Point on the circle edge </returns>
        public static Point GetEdgePoint(Point centerPoint, int radius, int angleRad)
        {
            GetEdgePoint(centerPoint.X, centerPoint.Y, radius, angleRad, out double x, out double y);
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <param name="edgePointX"> Point on the edge: X coordinate </param>
        /// <param name="edgePointY"> Point on the edge: Y coordinate </param>
        public static void GetEdgePoint(double circleCenterX, double circleCenterY, double radius, double angleRad, out double edgePointX, out double edgePointY)
        {
            edgePointX = circleCenterX + radius * Math.Cos(angleRad);
            edgePointY = circleCenterY + radius * Math.Sin(angleRad);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> Bounding rectangle </returns>
        public static RectangleF GetBoundingRect(PointF circleCenter, float radius)
        {
            GetBoundingRect(circleCenter.X, circleCenter.Y, radius, out double leftTopX, out double leftTopY, out double width, out double height);
            return new RectangleF((float)leftTopX, (float)leftTopY, (float)width, (float)height);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> Bounding rectangle </returns>
        public static Rectangle GetBoundingRect(Point circleCenter, float radius)
        {
            GetBoundingRect(circleCenter.X, circleCenter.Y, radius, out double leftTopX, out double leftTopY, out double width, out double height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="leftTopX"> Rectangle left top point: X coodinate </param>
        /// <param name="leftTopY"> Rectangle left top point: Y coodinate </param>
        /// <param name="width"> Rectangle width </param>
        /// <param name="height"> Rectangle height </param>
        public static void GetBoundingRect(double circleCenterX, double circleCenterY, double radius, out double leftTopX, out double leftTopY, out double width, out double height)
        {
            leftTopX = circleCenterX - radius;
            leftTopY = circleCenterY + radius;

            width = height = radius * 2;
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> True, if has intersection </returns>
        public static bool HasRectIntersection(PointF circleCenter, float radius, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            return HasRectIntersection(circleCenter.X, circleCenter.Y, radius, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> True, if has intersection </returns>
        public static bool HasRectIntersection(Point circleCenter, int radius, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            return HasRectIntersection(circleCenter.X, circleCenter.Y, radius, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> True, if has intersection </returns>
        public static bool HasRectIntersection(double circleCenterX, double circleCenterY, double radius, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            return PointGeo.BelongsToRect(circleCenterX, circleCenterY, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY) ||
                   LineGeo.HasCircleIntersection(rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY, circleCenterX, circleCenterY, radius) ||
                   LineGeo.HasCircleIntersection(rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY, circleCenterX, circleCenterY, radius) ||
                   LineGeo.HasCircleIntersection(rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY, circleCenterX, circleCenterY, radius) ||
                   LineGeo.HasCircleIntersection(rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY, circleCenterX, circleCenterY, radius);
        }
    }
}
