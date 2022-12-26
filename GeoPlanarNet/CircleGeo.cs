using System;
using System.Drawing;
using GeoPlanarNet.Enums;

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
            GetEdgePoint(centerPoint.X, centerPoint.Y, radius, angleRad, out var x, out var y);
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
            GetEdgePoint(centerPoint.X, centerPoint.Y, radius, angleRad, out var x, out var y);
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
            GetBoundingRect(circleCenter.X, circleCenter.Y, radius, out var leftTopX, out var leftTopY, out var width, out var height);
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
            GetBoundingRect(circleCenter.X, circleCenter.Y, radius, out var leftTopX, out var leftTopY, out var width, out var height);
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

            return distanceSqr.AboutEquals(radius1 * radius1 + radius2 * radius2);
        }

        /// <summary>
        /// Check if two circles has overlapping
        /// </summary>
        /// <param name="centerPoint1"> Circle 1 center point </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="centerPoint2"> Circle 2 center point </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> Overlapping type </returns>
        public static FiguresOverlapping HasOverlapping(PointF centerPoint1, float radius1, PointF centerPoint2, float radius2)
        {
            return HasOverlapping(centerPoint1.X, centerPoint1.Y, radius1, centerPoint2.X, centerPoint2.Y, radius2);
        }

        /// <summary>
        /// Check if two circles has overlapping
        /// </summary>
        /// <param name="centerPoint1"> Circle 1 center point </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="centerPoint2"> Circle 2 center point </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> Overlapping type </returns>
        public static FiguresOverlapping HasOverlapping(Point centerPoint1, int radius1, Point centerPoint2, int radius2)
        {
            return HasOverlapping(centerPoint1.X, centerPoint1.Y, radius1, centerPoint2.X, centerPoint2.Y, radius2);
        }

        /// <summary>
        /// Check if two circles has overlapping
        /// </summary>
        /// <param name="circleCenter1X"> Circle 1 center point: X coordinate </param>
        /// <param name="circleCenter1Y"> Circle 1 center point: Y coordinate </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="circleCenter2X"> Circle 2 center point: X coordinate </param>
        /// <param name="circleCenter2Y"> Circle 2 center point: Y coordinate </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> Overlapping type </returns>
        public static FiguresOverlapping HasOverlapping(double circleCenter1X, double circleCenter1Y, double radius1, double circleCenter2X, double circleCenter2Y, double radius2)
        {
            var distance = PointGeo.DistanceTo(circleCenter1X, circleCenter1Y, circleCenter2X, circleCenter2Y);
            if (distance <= radius1 - radius2)
            {
                return FiguresOverlapping.Figure2InsideFigure1;
            }

            if (distance <= radius2 - radius1)
            {
                return FiguresOverlapping.Figure1InsideFigure2;
            }

            if (distance <= radius1 + radius2)
            {
                return FiguresOverlapping.Intersects;
            }

            if (distance.AboutEquals(radius1 + radius2))
            {
                return FiguresOverlapping.InTouch;
            }

            return FiguresOverlapping.DoNotOverlap;
        }

        /// <summary>
        /// Get shortest distance from the circle to the circle
        /// </summary>
        /// <param name="circle1Center"> Circle 1 center point </param>
        /// <param name="circle1Radius"> Circle 1 radius </param>
        /// <param name="circle2Center"> Circle 2 center point </param>
        /// <param name="circle2Radius"> Circle 2 radius </param>
        /// <returns> Distance between the circle and the circle </returns>
        public static double DistanceToCircle(PointF circle1Center, float circle1Radius, PointF circle2Center, float circle2Radius)
        {
            return DistanceToCircle(circle1Center.X, circle1Center.Y, circle1Radius, circle2Center.X, circle2Center.Y, circle2Radius);
        }

        /// <summary>
        /// Get shortest distance from the circle to the circle
        /// </summary>
        /// <param name="circle1Center"> Circle 1 center point </param>
        /// <param name="circle1Radius"> Circle 1 radius </param>
        /// <param name="circle2Center"> Circle 2 center point </param>
        /// <param name="circle2Radius"> Circle 2 radius </param>
        /// <returns> Distance between the circle and the circle </returns>
        public static double DistanceToCircle(Point circle1Center, int circle1Radius, Point circle2Center, int circle2Radius)
        {
            return DistanceToCircle(circle1Center.X, circle1Center.Y, circle1Radius, circle2Center.X, circle2Center.Y, circle2Radius);
        }

        /// <summary>
        /// Get shortest distance from the circle to the circle
        /// </summary>
        /// <param name="circle1CenterX"> Circle 1 center point: X coordinate </param>
        /// <param name="circle1CenterY"> Circle 1 center point: Y coordinate </param>
        /// <param name="radius1"> Circle 1 radius </param>
        /// <param name="circle2CenterX"> Circle 2 center point: X coordinate </param>
        /// <param name="circle2CenterY"> Circle 2 center point: Y coordinate </param>
        /// <param name="radius2"> Circle 2 radius </param>
        /// <returns> Distance between the circle and the circle </returns>
        public static double DistanceToCircle(double circle1CenterX, double circle1CenterY, double radius1, double circle2CenterX, double circle2CenterY, double radius2)
        {
            return PointGeo.DistanceTo(circle1CenterX, circle1CenterY, circle2CenterX, circle2CenterY) - (radius1 + radius2);
        }

        /// <summary>
        /// Get shortest distance from the circle to the triangle
        /// </summary>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="circleRadius"> Radius </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Distance from the circle to the triangle</returns>
        public static double DistanceToTriangle(PointF circleCenter, float circleRadius, PointF apex1, PointF apex2, PointF apex3)
        {
            return DistanceToTriangle(circleCenter.X, circleCenter.Y, circleRadius, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distance from the circle to the triangle
        /// </summary>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="circleRadius"> Radius </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Distance from the circle to the triangle </returns>
        public static double DistanceToTriangle(Point circleCenter, float circleRadius, Point apex1, Point apex2, Point apex3)
        {
            return DistanceToTriangle(circleCenter.X, circleCenter.Y, circleRadius, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distance from the circle to the triangle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Distance from the circle to the triangle </returns>
        public static double DistanceToTriangle(double circleCenterX, double circleCenterY, double radius, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            return PointGeo.DistanceToTriangle(circleCenterX, circleCenterY, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y) - radius;
        }
    }
}
