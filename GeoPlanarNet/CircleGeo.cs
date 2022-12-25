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

        /// <summary>
        /// Check if two circles are orthogonal 
        /// </summary>
        /// <param name="centerPoint1"> Circle 1 center point </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="centerPoint2"> Circle 2 center point </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> True, if circles are orthogonal </returns>
        public static bool IsOrthogonal(PointF centerPoint1, float radius1, PointF centerPoint2, float radius2)
        {
           return IsOrthogonal(centerPoint1.X, centerPoint1.Y, radius1, centerPoint2.X, centerPoint2.Y, radius2);
        }

        /// <summary>
        /// Check if two circles are orthogonal
        /// </summary>
        /// <param name="centerPoint1"> Circle 1 center point </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="centerPoint2"> Circle 2 center point </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> True, if circles are orthogonal </returns>
        public static bool IsOrthogonal(Point centerPoint1, int radius1, Point centerPoint2, int radius2)
        {
            return IsOrthogonal(centerPoint1.X, centerPoint1.Y, radius1, centerPoint2.X, centerPoint2.Y, radius2);
        }

        /// <summary>
        /// Check if two circles are orthogonal
        /// </summary>
        /// <param name="circleCenter1X"> Circle 1 center point: X coordinate </param>
        /// <param name="circleCenter1Y"> Circle 1 center point: Y coordinate </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="circleCenter2X"> Circle 2 center point: X coordinate </param>
        /// <param name="circleCenter2Y"> Circle 2 center point: Y coordinate </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> True, if circles are orthogonal </returns>
        public static bool IsOrthogonal(double circleCenter1X, double circleCenter1Y, double radius1, double circleCenter2X, double circleCenter2Y, double radius2)
        {
            var distanceSqr = (circleCenter1X - circleCenter2X) * (circleCenter1X - circleCenter2X) +
                              (circleCenter1Y - circleCenter2Y) * (circleCenter1Y - circleCenter2Y);

            return distanceSqr == radius1 * radius1 + radius2 * radius2;
        }
    }
}
