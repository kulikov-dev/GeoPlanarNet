using GeoPlanarNet.Enums;
using System;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the circle
    /// </summary>
    public static class CircleGeo
    {
        /// <summary>
        /// Get the circle area
        /// </summary>
        /// <param name="radius"> Radius </param>
        /// <returns> Area </returns>
        public static double GetArea(double radius)
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
        public static RectangleF GetAABB(PointF circleCenter, float radius)
        {
            GetAABB(circleCenter.X, circleCenter.Y, radius, out var leftTopX, out var leftTopY, out var width, out var height);
            return new RectangleF((float)leftTopX, (float)leftTopY, (float)width, (float)height);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> Bounding rectangle </returns>
        public static Rectangle GetAABB(Point circleCenter, float radius)
        {
            GetAABB(circleCenter.X, circleCenter.Y, radius, out var leftTopX, out var leftTopY, out var width, out var height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="leftTopX"> Rectangle left top point: X coordinate </param>
        /// <param name="leftTopY"> Rectangle left top point: Y coordinate </param>
        /// <param name="width"> Rectangle width </param>
        /// <param name="height"> Rectangle height </param>
        public static void GetAABB(double circleCenterX, double circleCenterY, double radius, out double leftTopX, out double leftTopY, out double width, out double height)
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
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            return HasRectIntersection(circleCenterX, circleCenterY, radius, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        public static bool HasRectIntersection(double circleCenterX, double circleCenterY, double radius, PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            return HasRectIntersection(circleCenterX, circleCenterY, radius, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        public static bool HasRectIntersection(double circleCenterX, double circleCenterY, double radius, Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            return HasRectIntersection(circleCenterX, circleCenterY, radius, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Check if the circle has intersection with the rectangle
        /// </summary>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightTopX"> Rectangle right top: X coordinate </param>
        /// <param name="rectRightTopY"> Rectangle right top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="rectLeftBottomX"> Rectangle left bottom: X coordinate </param>
        /// <param name="rectLeftBottomY"> Rectangle left bottom: Y coordinate </param>
        public static bool HasRectIntersection(double circleCenterX, double circleCenterY, double radius, double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY)
        {
            return PointGeo.BelongsToRect(circleCenterX, circleCenterY, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY) ||
                   LineGeo.HasCircleIntersection(rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, circleCenterX, circleCenterY, radius) ||
                   LineGeo.HasCircleIntersection(rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, circleCenterX, circleCenterY, radius) ||
                   LineGeo.HasCircleIntersection(rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY, circleCenterX, circleCenterY, radius) ||
                   LineGeo.HasCircleIntersection(rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY, circleCenterX, circleCenterY, radius);
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
            var distanceSqr = PointGeo.DistanceToSqr(circleCenter1X, circleCenter1Y, circleCenter2X, circleCenter2Y);

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

        /// <summary>
        /// Has intersection between the line and the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool HasLineIntersection(PointF circleCenter, float radius, PointF linePoint1, PointF linePoint2)
        {
            return LineGeo.HasCircleIntersection(linePoint1, linePoint2, circleCenter, radius);
        }

        /// <summary>
        /// Has intersection between the line and the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool HasLineIntersection(PointF circleCenter, float radius, Point linePoint1, Point linePoint2)
        {
            return LineGeo.HasCircleIntersection(linePoint1, linePoint2, circleCenter, radius);
        }

        /// <summary>
        /// Has intersection between the line and the circle
        /// </summary>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool HasCircleIntersection(double circleCenterX, double circleCenterY, double radius, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            return LineGeo.HasCircleIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterX, circleCenterY, radius);
        }

        /// <summary>
        /// Find intersection between the line and the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool FindLineIntersection(PointF circleCenter, float radius, PointF linePoint1, PointF linePoint2, out PointF intersection1, out PointF intersection2)
        {
            return LineGeo.FindCircleIntersection(linePoint1, linePoint2, circleCenter, radius, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between line and circle
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and circle has intersection </returns>
        public static bool FindLineIntersection(Point circleCenter, int radius, Point linePoint1, Point linePoint2, out Point intersection1, out Point intersection2)
        {
            return LineGeo.FindCircleIntersection(linePoint1, linePoint2, circleCenter, radius, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between line and circle
        /// </summary>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if line and circle has intersection </returns>
        public static bool FindLineIntersection(double circleCenterX, double circleCenterY, double radius, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y,
            out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            return LineGeo.FindCircleIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterX, circleCenterY, radius,
                                                  out intersection1X, out intersection1Y, out intersection2X, out intersection2Y);
        }

        /// <summary>
        /// Get the line location relative to the circle
        /// </summary>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationLine(PointF circleCenterPoint, float circleRadius, PointF linePoint1, PointF linePoint2)
        {
            return LineGeo.GetRelativeLocationCircle(linePoint1, linePoint2, circleCenterPoint, circleRadius);
        }

        /// <summary>
        /// Get the line location relative to the circle
        /// </summary>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationLine(Point circleCenterPoint, int circleRadius, Point linePoint1, Point linePoint2)
        {
            return LineGeo.GetRelativeLocationCircle(linePoint1, linePoint2, circleCenterPoint, circleRadius);
        }

        /// <summary>
        /// Get the line location relative to the circle
        /// </summary>
        /// <param name="circleCenterPointX"> Circle center point: X Coordinate </param>
        /// <param name="circleCenterPointY"> Circle center point: Y Coordinate </param>
        /// <param name="circleCenterRadius"> Circle center radius </param>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <returns> Point location </returns>
        /// <remarks> Return 'inside' if has two intersections </remarks>
        public static PointAgainstFigureLocation GetRelativeLocationLine(double circleCenterPointX, double circleCenterPointY, double circleCenterRadius, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            return LineGeo.GetRelativeLocationCircle(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterPointX, circleCenterPointY, circleCenterRadius);
        }

        /// <summary>
        /// Get shortest distance from the line to the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Distance between the line and the circle </returns>
        public static double DistanceToLine(PointF circleCenter, float circleRadius, PointF linePoint1, PointF linePoint2)
        {
            return LineGeo.DistanceToCircle(linePoint1, linePoint2, circleCenter, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the line to the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Distance between the line and the circle </returns>
        public static double DistanceToLine(Point circleCenter, int circleRadius, Point linePoint1, Point linePoint2)
        {
            return LineGeo.DistanceToCircle(linePoint1, linePoint2, circleCenter, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the line to the circle
        /// </summary>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <returns> Distance between the line and the circle </returns>
        public static double DistanceToLine(double circleCenterX, double circleCenterY, double radius, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            return LineGeo.DistanceToCircle(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterX, circleCenterY, radius);
        }

        /// <summary>
        /// Get shortest distance from the segment to the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <returns> Distance between the segment and the circle </returns>
        public static double DistanceToSegment(PointF circleCenter, float circleRadius, PointF segmentStart, PointF segmentEnd)
        {
            return SegmentGeo.DistanceToCircle(segmentStart, segmentEnd, circleCenter, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the segment to the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <returns> Distance between the segment and the circle </returns>
        public static double DistanceToSegment(Point circleCenter, int circleRadius, Point segmentStart, Point segmentEnd)
        {
            return SegmentGeo.DistanceToCircle(segmentStart, segmentEnd, circleCenter, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the segment to the circle
        /// </summary>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="segmentStartX"> Segment, start point: coordinate X </param>
        /// <param name="segmentStartY"> Segment, start point: coordinate Y </param>
        /// <param name="segmentEndX"> Segment, end point: coordinate X </param>
        /// <param name="segmentEndY"> Segment, end point: coordinate Y </param>
        /// <returns> Distance between the segment and the circle </returns>
        public static double DistanceToSegment(double circleCenterX, double circleCenterY, double radius, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return SegmentGeo.DistanceToCircle(segmentStartX, segmentStartY, segmentEndX, segmentEndY, circleCenterX, circleCenterY, radius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(PointF circleCenter, float circleRadius, PointF point)
        {
            return point.DistanceToCircle(circleCenter, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(Point circleCenter, int circleRadius, Point point)
        {
            return point.DistanceToCircle(circleCenter, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(double circleCenterY, double radius, double pointX, double pointY, double circleCenterX)
        {
            return PointGeo.DistanceToCircle(pointX, pointY, circleCenterX, circleCenterY, radius);
        }

        /// <summary>
        /// Check if the circle contains the point
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the circle contains the point </returns>
        public static bool Contains(PointF circleCenter, float radius, PointF point)
        {
            return point.BelongsToCircle(circleCenter, radius);
        }

        /// <summary>
        /// Check if the circle contains the point
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the circle contains the point </returns>
        public static bool Contains(Point circleCenter, double radius, Point point)
        {
            return point.BelongsToCircle(circleCenter, radius);

        }

        /// <summary>
        /// Check if the circle contains the point
        /// </summary>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the circle contains the point </returns>
        public static bool Contains(double circleCenterX, double circleCenterY, double radius, double pointX, double pointY)
        {
            return PointGeo.BelongsToCircle(pointX, pointY, circleCenterX, circleCenterY, radius);
        }

        /// <summary>
        /// Check if the circle sector contains the point
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the circle sector contains the point </returns>
        public static bool Contains(PointF circleCenter, float radius, float sectorStartAngleRad, float sectorEndAngleRad, PointF point)
        {
            return point.BelongsToCircleSector(circleCenter, radius, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the circle sector contains the point
        /// </summary>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the circle sector contains the point </returns>
        public static bool Contains(Point circleCenter, int radius, int sectorStartAngleRad, int sectorEndAngleRad, Point point)
        {
            return point.BelongsToCircleSector(circleCenter, radius, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the circle sector contains the point
        /// </summary>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the circle sector contains the point </returns>
        public static bool Contains(double circleCenterX, double circleCenterY, double radius, double sectorStartAngleRad, double sectorEndAngleRad, double pointX, double pointY)
        {
            return PointGeo.BelongsToCircleSector(pointX, pointY, circleCenterX, circleCenterY, radius, sectorStartAngleRad, sectorEndAngleRad);
        }
    }
}
