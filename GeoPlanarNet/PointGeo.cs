﻿using GeoPlanarNet.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the point
    /// </summary>
    public static class PointGeo
    {
        #region DistanceTo

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceTo(this PointF point1, PointF point2)
        {
            return DistanceTo(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceTo(this Point point1, Point point2)
        {
            return DistanceTo(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static double DistanceTo(double point1X, double point1Y, double point2X, double point2Y)
        {
            return Math.Sqrt(DistanceToSqr(point1X, point1Y, point2X, point2Y));
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceToSqr(this PointF point1, PointF point2)
        {
            return DistanceToSqr(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceToSqr(this Point point1, Point point2)
        {
            return DistanceToSqr(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static double DistanceToSqr(double point1X, double point1Y, double point2X, double point2Y)
        {
            var dX = point1X - point2X;
            var dY = point1Y - point2Y;

            return dX * dX + dY * dY;
        }

        /// <summary>
        /// Get shortest distance to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line first point </param>
        /// <param name="linePoint2"> Line second point </param>
        /// <returns> Distance from the point to the line </returns>
        public static double DistanceToLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            return DistanceToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Get shortest distance to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line first point </param>
        /// <param name="linePoint2"> Line second point </param>
        /// <returns> Distance from the point to the line </returns>
        public static double DistanceToLine(this Point point, Point linePoint1, Point linePoint2)
        {
            return DistanceToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Get shortest distance to the line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X">Line first point: X coordinate</param>
        /// <param name="linePoint1Y">Line first point: X coordinate</param>
        /// <param name="linePoint2X">Line second point: X coordinate</param>
        /// <param name="linePoint2Y">Line second point: X coordinate</param>
        /// <returns> Distance from the point to the line </returns>
        public static double DistanceToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            var distX = linePoint2X - linePoint1X;
            var distY = linePoint2Y - linePoint1Y;

            var koef = ((linePoint2X - linePoint1X) * (pointX - linePoint1X) + (linePoint2Y - linePoint1Y) * (pointY - linePoint1Y)) / (distX * distX + distY * distY);
            var koefX = linePoint1X + (linePoint2X - linePoint1X) * koef;
            var koefY = linePoint1Y + (linePoint2Y - linePoint1Y) * koef;

            return DistanceTo(pointX, pointY, koefX, koefY);
        }

        /// <summary>
        /// Get shortest distance from point to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToSegment(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return DistanceToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get shortest distance from point to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToSegment(this Point point, Point segmentStart, Point segmentEnd)
        {
            return DistanceToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get shortest distance from point to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Distance from the point to the segment </returns>
        public static double DistanceToSegment(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            if ((segmentStartX - segmentEndX) * (pointX - segmentEndX) + (segmentStartY - segmentEndY) * (pointY - segmentEndY) <= 0)
            {
                return DistanceTo(pointX, pointY, segmentEndX, segmentEndY);
            }

            if ((segmentEndX - segmentStartX) * (pointX - segmentStartX) + (segmentEndY - segmentStartY) * (pointY - segmentStartY) <= 0)
            {
                return DistanceTo(pointX, pointY, segmentStartX, segmentStartY);
            }

            var length = DistanceTo(segmentStartX, segmentStartY, segmentEndX, segmentEndY);

            return Math.Abs((segmentEndY - segmentStartY) * pointX - (segmentEndX - segmentStartX) * pointY + segmentEndX * segmentStartY - segmentEndY * segmentStartX) / length;
        }

        /// <summary>
        /// Get shortest distance from point to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToRect(this PointF point, RectangleF rect)
        {
            return DistanceToRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Get shortest distance from point to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToRect(this Point point, Rectangle rect)
        {
            return DistanceToRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
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
        public static double DistanceToRect(this PointF point, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            return DistanceToRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
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
        public static double DistanceToRect(this Point point, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            return DistanceToRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
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
        public static double DistanceToRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            return DistanceToRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
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
        public static double DistanceToRect(this PointF point, PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            return DistanceToRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
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
        public static double DistanceToRect(this Point point, Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            return DistanceToRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
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
        public static double DistanceToRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY);
            var distanceBC = DistanceToSegment(pointX, pointY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY);
            var distanceCD = DistanceToSegment(pointX, pointY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
            var distanceDA = DistanceToSegment(pointX, pointY, rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY);

            return Math.Min(distanceAB, Math.Min(distanceBC, Math.Min(distanceCD, distanceDA)));
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(this PointF point, PointF circleCenter, float circleRadius)
        {
            return DistanceToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(this Point point, Point circleCenter, int circleRadius)
        {
            return DistanceToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius)
        {
            return DistanceTo(pointX, pointY, circleCenterX, circleCenterY) - radius;
        }

        /// <summary>
        /// Get shortest distance from the point to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Distance from the point to the triangle</returns>
        public static double DistanceToTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return DistanceToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distance from the point to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Distance from the point to the triangle </returns>
        public static double DistanceToTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return DistanceToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distance from the point to the triangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Distance from the point to the triangle </returns>
        public static double DistanceToTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y);
            var distanceBC = DistanceToSegment(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y);
            var distanceCA = DistanceToSegment(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y);

            return Math.Min(distanceAB, Math.Min(distanceBC, distanceCA));
        }

        /// <summary>
        /// Get shortest distance from point to the Surface
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="surface"> Surface </param>
        /// <returns> Distance to the surface </returns>
        public static double DistanceToSurface(this PointF point, PointF[] surface)
        {
            var minDistance = double.MaxValue;

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];
                var currentPoint = surface[i];
                var distance = DistanceToSegment(point, prevPoint, currentPoint);
                minDistance = Math.Min(distance, minDistance);
            }

            return minDistance;
        }

        /// <summary>
        /// Get shortest distance from point to the Surface
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="surface"> Surface </param>
        /// <returns> Distance to the surface </returns>
        public static double DistanceToSurface(this Point point, Point[] surface)
        {
            var minDistance = double.MaxValue;

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];
                var currentPoint = surface[i];
                var distance = DistanceToSegment(point, prevPoint, currentPoint);
                minDistance = Math.Min(distance, minDistance);
            }

            return minDistance;
        }

        #endregion

        #region BelongsTo

        /// <summary>
        /// Check if the point belongs to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True, if the point belongs to the segment </returns>
        public static bool BelongsToSegment(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return BelongsToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Check if the point belongs to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True, if the point belongs to the segment </returns>
        public static bool BelongsToSegment(this Point point, Point segmentStart, Point segmentEnd)
        {
            return BelongsToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Check if the point belongs to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> True, if the point belongs to the segment </returns>
        public static bool BelongsToSegment(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return (DistanceTo(segmentStartX, segmentStartY, pointX, pointY) + DistanceTo(segmentEndX, segmentEndY, pointX, pointY)).AboutEquals(DistanceTo(segmentStartX, segmentStartY, segmentEndX, segmentEndY));
        }

        /// <summary>
        /// Check if the point belongs to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> True, if the point belongs to the line </returns>
        public static bool BelongsToLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            return BelongsToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Check if the point belongs to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> True, if the point belongs to the line </returns>
        public static bool BelongsToLine(this Point point, Point linePoint1, Point linePoint2)
        {
            return BelongsToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Check if the point belongs to the line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X"> Segment start point: X coordinate </param>
        /// <param name="linePoint1Y"> Segment start point: Y coordinate </param>
        /// <param name="linePoint2X"> Segment end point: X coordinate </param>
        /// <param name="linePoint2Y"> Segment end point: Y coordinate </param>
        /// <returns> True, if the point belongs to the line </returns>
        public static bool BelongsToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            LineGeo.FindSlopeKoef(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, out var slopeKoef, out var yIntersection);

            return pointY.AboutEquals(slopeKoef * pointX + yIntersection);
        }

        /// <summary>
        /// Check if the point belongs to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True, if the point belongs to the circle </returns>
        public static bool BelongsToCircle(this PointF point, PointF circleCenter, float radius)
        {
            return BelongsToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius);
        }

        /// <summary>
        /// Check if the point belongs to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True, if the point belongs to the circle </returns>
        public static bool BelongsToCircle(this Point point, Point circleCenter, double radius)
        {
            return BelongsToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius);

        }

        /// <summary>
        /// Check if the point belongs to the circle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True, if the point belongs to the circle </returns>
        public static bool BelongsToCircle(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius)
        {
            return GetRelativeLocationCircle(pointX, pointY, circleCenterX, circleCenterY, radius) != PointAgainstFigureLocation.Outside;
        }

        /// <summary>
        /// Check if the point belong to the specific circle sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> True, if the point belongs to the circle sector </returns>
        public static bool BelongsToCircleSector(this PointF point, PointF circleCenter, float radius, float sectorStartAngleRad, float sectorEndAngleRad)
        {
            return BelongsToCircleSector(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the point belong to the specific circle sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> True, if the point belongs to the circle sector </returns>
        public static bool BelongsToCircleSector(this Point point, Point circleCenter, int radius, int sectorStartAngleRad, int sectorEndAngleRad)
        {
            return BelongsToCircleSector(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the point belong to the specific circle sector
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> True, if the point belongs to the circle sector </returns>
        public static bool BelongsToCircleSector(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius, double sectorStartAngleRad, double sectorEndAngleRad)
        {
            return BelongsToCircle(pointX, pointY, circleCenterX, circleCenterY, radius) && SegmentGeo.IsBetweenAngles(pointX, pointY, circleCenterX, circleCenterY, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the point belongs to an axis-parallel ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> True, if the point belongs to the axis-parallel ellipse </returns>
        public static bool BelongsToEllipse(this PointF point, PointF ellipseCenter, float semiMajor, float semiMinor)
        {
            return BelongsToEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor);
        }

        /// <summary>
        /// Check if the point belongs to an axis-parallel ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> True, if the point belongs to the axis-parallel ellipse </returns>
        public static bool BelongsToEllipse(this Point point, Point ellipseCenter, int semiMajor, int semiMinor)
        {
            return BelongsToEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor);
        }

        /// <summary>
        /// Check if the point belongs to an axis-parallel ellipse
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> True, if the point belongs to the axis-parallel ellipse </returns>
        public static bool BelongsToEllipse(double pointX, double pointY, double ellipseCenterX, double ellipseCenterY, double semiMajor, double semiMinor)
        {
            return GetRelativeLocationEllipse(pointX, pointY, ellipseCenterX, ellipseCenterY, semiMajor, semiMinor) != PointAgainstFigureLocation.Outside;
        }

        /// <summary>
        /// Check if the point belong to the specific axis-parallel ellipse sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> True, if the point belongs to the axis-parallel ellipse sector </returns>
        public static bool BelongsToEllipseSector(PointF point, PointF ellipseCenter, float semiMajor, float semiMinor, float sectorStartAngleRad, float sectorEndAngleRad)
        {
            return BelongsToEllipseSector(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the point belong to the specific axis-parallel ellipse sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> True, if the point belongs to the axis-parallel ellipse sector </returns>
        public static bool BelongsToEllipseSector(Point point, Point ellipseCenter, int semiMajor, int semiMinor, int sectorStartAngleRad, int sectorEndAngleRad)
        {
            return BelongsToEllipseSector(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the point belong to the specific axis-parallel ellipse sector
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> True, if the point belongs to the axis-parallel ellipse sector </returns>
        public static bool BelongsToEllipseSector(double pointX, double pointY, double ellipseCenterX, double ellipseCenterY, double semiMajor, double semiMinor, double sectorStartAngleRad, double sectorEndAngleRad)
        {
            return BelongsToEllipse(pointX, pointY, ellipseCenterX, ellipseCenterY, semiMajor, semiMinor) && SegmentGeo.IsBetweenAngles(pointX, pointY, ellipseCenterX, ellipseCenterY, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the point belongs to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Triangle apex 1 </param>
        /// <param name="apex2"> Triangle apex 2 </param>
        /// <param name="apex3"> Triangle apex 3 </param>
        /// <returns> True, if the point belongs to the triangle </returns>
        public static bool BelongsToTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return BelongsToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if the point belongs to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Triangle apex 1 </param>
        /// <param name="apex2"> Triangle apex 2 </param>
        /// <param name="apex3"> Triangle apex 3 </param>
        /// <returns> True, if the point belongs to the triangle </returns>
        public static bool BelongsToTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return BelongsToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if the point belongs to the triangle
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="apex1X"> Apex 1: X Coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y Coordinate </param>
        /// <param name="apex2X"> Apex 2: X Coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y Coordinate </param>
        /// <param name="apex3X"> Apex 3: X Coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y Coordinate </param>
        /// <returns> True, if the point belongs to the triangle </returns>
        public static bool BelongsToTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            return GetRelativeLocationSimple(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y) != PointAgainstSegmentSimpleLocation.Left &&
                    GetRelativeLocationSimple(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y) != PointAgainstSegmentSimpleLocation.Left &&
                    GetRelativeLocationSimple(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y) != PointAgainstSegmentSimpleLocation.Left;
        }

        /// <summary>
        /// Check if the point belongs to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this PointF point, RectangleF rect)
        {
            return BelongsToRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Check if the point belongs to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this Point point, Rectangle rect)
        {
            return BelongsToRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this PointF point, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            return BelongsToRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this Point point, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            return BelongsToRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            return BelongsToRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this PointF point, PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            return BelongsToRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this Point point, Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            return BelongsToRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
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
        /// <returns> True, if belongs to the rectangle </returns>
        public static bool BelongsToRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY)
        {
            return GetRelativeLocationSimple(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY) != PointAgainstSegmentSimpleLocation.Left &&
                   GetRelativeLocationSimple(pointX, pointY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY) != PointAgainstSegmentSimpleLocation.Left &&
                   GetRelativeLocationSimple(pointX, pointY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY) != PointAgainstSegmentSimpleLocation.Left &&
                   GetRelativeLocationSimple(pointX, pointY, rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY) != PointAgainstSegmentSimpleLocation.Left;
        }

        /// <summary>
        /// Check if the point belongs to the surface
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="surface"> Surface </param>
        /// <returns> True, if the point belongs to the surface </returns>
        public static bool BelongsToSurface(this PointF point, IList<PointF> surface)
        {
            var pointsInAreaCount = surface.Count - 1;

            if (pointsInAreaCount < 1)
            {
                return false;
            }

            for (var i = 1; i < surface.Count; ++i)
            {
                if (DistanceToSegment(point.X, point.Y, surface[i - 1].X, surface[i - 1].Y, surface[i].X, surface[i].Y) <= GeoPlanarNet.Epsilon)
                {
                    return true;
                }
            }

            var firstIndex = 0;

            while (firstIndex < surface.Count && surface[firstIndex].Y.AboutEquals(point.Y))
            {
                firstIndex++;
            }

            if (firstIndex == surface.Count)
            {
                return false;
            }

            var indFirst = firstIndex;
            var secondIndex = (firstIndex + 1) % pointsInAreaCount;
            var iterations = 0;
            var left = 0;

            do
            {
                var yDiff = (surface[firstIndex].Y - point.Y) * (surface[secondIndex].Y - point.Y);
                iterations++;

                float xDiff;
                if (yDiff < 0)
                {
                    xDiff = surface[firstIndex].X + (surface[secondIndex].X - surface[firstIndex].X) * (point.Y - surface[firstIndex].Y) / (surface[secondIndex].Y - surface[firstIndex].Y);

                    if (xDiff < point.X)
                    {
                        left++;
                    }
                    else
                    {
                        if (xDiff.AboutEquals(point.X))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (yDiff.AboutZero())
                    {
                        var firstYDiff = surface[firstIndex].Y - point.Y;
                        while (surface[secondIndex].Y.AboutEquals(point.Y))
                        {
                            firstIndex = secondIndex;
                            secondIndex = (secondIndex + 1) % pointsInAreaCount;

                            if (surface[firstIndex].Y.AboutEquals(point.Y) && surface[secondIndex].Y.AboutEquals(point.Y))
                            {
                                if ((surface[firstIndex].X - point.X) * (surface[secondIndex].X - point.X) <= 0)
                                {
                                    return true;
                                }
                            }
                        }

                        yDiff = firstYDiff * (surface[secondIndex].Y - point.Y);

                        if (yDiff < 0)
                        {
                            xDiff = surface[firstIndex].X + (surface[secondIndex].X - surface[firstIndex].X) * (point.Y - surface[firstIndex].Y) / (surface[secondIndex].Y - surface[firstIndex].Y);

                            if (xDiff < point.X)
                            {
                                left++;
                            }
                            else
                            {
                                if (xDiff.AboutEquals(point.X))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                firstIndex = secondIndex;
                secondIndex = (secondIndex + 1) % pointsInAreaCount;
            }
            while (secondIndex != indFirst + 1 && iterations < pointsInAreaCount);

            return left % 2 == 1 && iterations <= pointsInAreaCount;
        }

        /// <summary>
        /// Check if the point belongs to the surface
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="surface"> Surface </param>
        /// <returns> True, if the point belongs to the surface </returns>
        public static bool BelongsToSurface(this Point point, IList<Point> surface)
        {
            var pointsInAreaCount = surface.Count - 1;

            if (pointsInAreaCount < 1)
            {
                return false;
            }

            for (var i = 1; i < surface.Count; ++i)
            {
                if (DistanceToSegment(point.X, point.Y, surface[i - 1].X, surface[i - 1].Y, surface[i].X, surface[i].Y) <= GeoPlanarNet.Epsilon)
                {
                    return true;
                }
            }

            var firstIndex = 0;

            while (firstIndex < surface.Count && surface[firstIndex].Y == point.Y)
            {
                firstIndex++;
            }

            if (firstIndex == surface.Count)
            {
                return false;
            }

            var indFirst = firstIndex;
            var secondIndex = (firstIndex + 1) % pointsInAreaCount;
            var iterations = 0;
            var left = 0;

            do
            {
                var yDiff = (surface[firstIndex].Y - point.Y) * (surface[secondIndex].Y - point.Y);
                iterations++;

                int xDiff;
                if (yDiff < 0)
                {
                    xDiff = surface[firstIndex].X + (surface[secondIndex].X - surface[firstIndex].X) * (point.Y - surface[firstIndex].Y) / (surface[secondIndex].Y - surface[firstIndex].Y);

                    if (xDiff < point.X)
                    {
                        left++;
                    }
                    else
                    {
                        if (xDiff == point.X)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (yDiff == 0)
                    {
                        var firstYDiff = surface[firstIndex].Y - point.Y;
                        while (surface[secondIndex].Y == point.Y)
                        {
                            firstIndex = secondIndex;
                            secondIndex = (secondIndex + 1) % pointsInAreaCount;

                            if (surface[firstIndex].Y == point.Y && surface[secondIndex].Y == point.Y)
                            {
                                if ((surface[firstIndex].X - point.X) * (surface[secondIndex].X - point.X) <= 0)
                                {
                                    return true;
                                }
                            }
                        }

                        yDiff = firstYDiff * (surface[secondIndex].Y - point.Y);

                        if (yDiff < 0)
                        {
                            xDiff = surface[firstIndex].X + (surface[secondIndex].X - surface[firstIndex].X) * (point.Y - surface[firstIndex].Y) / (surface[secondIndex].Y - surface[firstIndex].Y);

                            if (xDiff < point.X)
                            {
                                left++;
                            }
                            else
                            {
                                if (xDiff == point.X)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                firstIndex = secondIndex;
                secondIndex = (secondIndex + 1) % pointsInAreaCount;
            }
            while (secondIndex != indFirst + 1 && iterations < pointsInAreaCount);

            return left % 2 == 1 && iterations <= pointsInAreaCount;
        }

        #endregion

        #region GetClosestPoint

        /// <summary>
        /// Find the point on the segment closest to the given one
        /// </summary>
        /// <param name="segmentStart"> Segment point 1 </param>
        /// <param name="segmentEnd"> Segment point 2 </param>
        /// <param name="point"> Given point </param>
        /// <returns> Closest point on the Segment </returns>
        public static PointF GetClosestPointOnSegment(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            GetClosestPointOnSegment(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, point.X, point.Y, out var x, out var y);
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Find the point on the segment closest to the given one
        /// </summary>
        /// <param name="segmentStart"> Segment point 1 </param>
        /// <param name="segmentEnd"> Segment point 2 </param>
        /// <param name="point"> Given point </param>
        /// <returns> Closest point on the segment </returns>
        public static Point GetClosestPointOnSegment(this Point point, Point segmentStart, Point segmentEnd)
        {
            GetClosestPointOnSegment(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, point.X, point.Y, out var x, out var y);
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Find the point on the segment closest to the given one
        /// </summary>
        /// <param name="segmentStartX"> Segment point 1: X </param>
        /// <param name="segmentStartY"> Segment point 1: Y </param>
        /// <param name="segmentEndX"> Segment point 2: X </param>
        /// <param name="segmentEndY"> Segment point 2: Y </param>
        /// <param name="pointX"> Given point: X </param>
        /// <param name="pointY"> Given point: Y </param>
        /// <param name="closestPointX"> Closest point on the segment: X </param>
        /// <param name="closestPointY"> Closest point on the segment: Y </param>
        public static void GetClosestPointOnSegment(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, out double closestPointX, out double closestPointY)
        {
            var diffX = segmentEndX - segmentStartX;
            var diffY = segmentEndY - segmentStartY;
            var toPointX = pointX - segmentStartX;
            var toPointY = pointY - segmentStartY;
            var koefC1 = diffX * toPointX + diffY * toPointY;
            var koefC2 = diffX * diffX + diffY * diffY;
            var ratio = koefC1 / koefC2;

            closestPointX = segmentStartX + ratio * diffX;
            closestPointY = segmentStartY + ratio * diffY;
        }

        /// <summary>
        /// Get closest point on the circle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Closest point </returns>
        public static PointF GetClosestPointOnCircle(this PointF point, PointF circleCenter, float radius)
        {
            GetClosestPointOnCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, out var closestPointX, out var closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the circle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Closest point </returns>
        public static Point GetClosestPointOnCircle(this Point point, Point circleCenter, double radius)
        {
            GetClosestPointOnCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, out var closestPointX, out var closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the circle to the given point
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="closestPointX"> Closest point: X coordinate </param>
        /// <param name="closestPointY"> Closest point: Y coordinate </param>
        public static void GetClosestPointOnCircle(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius, out double closestPointX, out double closestPointY)
        {
            var dX = pointX - circleCenterX;
            var dY = pointY - circleCenterY;
            var distanceToCircle = Math.Sqrt(dX * dX + dY * dY);

            closestPointX = circleCenterX + dX / distanceToCircle * radius;
            closestPointY = circleCenterY + dY / distanceToCircle * radius;
        }

        /// <summary>
        /// Get closest point on the axis-parallel ellipse to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Point location </returns>
        public static PointF GetClosestPointOnEllipse(this PointF point, PointF ellipseCenter, float semiMajor, float semiMinor)
        {
            GetClosestPointOnEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor, out var closestPointX, out var closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the axis-parallel ellipse to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Point location </returns>
        public static Point GetClosestPointOnEllipse(this Point point, Point ellipseCenter, int semiMajor, int semiMinor)
        {
            GetClosestPointOnEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor, out var closestPointX, out var closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the axis-parallel ellipse to the given point
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="closestPointX"> Closest point: X coordinate </param>
        /// <param name="closestPointY"> Closest point: Y coordinate </param>
        /// <remarks> Credit to Adrian Stephens for the Trig-Free Optimization: https://github.com/0xfaded/ellipse_demo/issues/1 </remarks>
        public static void GetClosestPointOnEllipse(double pointX, double pointY, double ellipseCenterX, double ellipseCenterY, double semiMajor, double semiMinor, out double closestPointX, out double closestPointY)
        {
            var pointXAbs = Math.Abs(pointX);
            var pointYAbs = Math.Abs(pointY);

            var t = Math.PI / 4;

            for (var i = 0; i < 4; ++i)
            {
                var cost = Math.Cos(t);
                var sint = Math.Sin(t);

                closestPointX = semiMajor * cost;
                closestPointY = semiMinor * sint;

                var ex = (semiMajor * semiMajor - semiMinor * semiMinor) * (cost * cost * cost) / semiMajor;
                var ey = (semiMinor * semiMinor - semiMajor * semiMajor) * (sint * sint * sint) / semiMinor;

                var rx = closestPointX - ex;
                var ry = closestPointY - ey;

                var qx = pointXAbs - ex;
                var qy = pointYAbs - ey;

                var r = Math.Sqrt(rx * rx + ry * ry);
                var q = Math.Sqrt(qx * qx + qy * qy);

                var deltaC = r * Math.Asin((rx * qy - ry * qx) / (r * q));
                var deltaT = deltaC / Math.Sqrt(semiMajor * semiMajor + semiMinor * semiMinor - closestPointX * closestPointX - closestPointY * closestPointY);

                t += deltaT;

                t = Math.Min(Math.PI / 2, Math.Max(0, t));
            }

            closestPointX = ellipseCenterX + semiMajor * Math.Cos(t);
            closestPointY = ellipseCenterY + semiMinor * Math.Sin(t);

            closestPointX = pointX < 0 ? -closestPointX : closestPointX;
            closestPointY = pointY < 0 ? -closestPointY : closestPointY;
        }

        /// <summary>
        /// Get closest point on the triangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Closest point on the triangle </returns>
        public static PointF GetClosestPointOnTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            GetClosestPointOnTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var closestPointX, out var closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the triangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Closest point on the triangle </returns>
        public static Point GetClosestPointOnTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            GetClosestPointOnTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var closestPointX, out var closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the triangle to the given point
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="closestPointX"> Closest point: X coordinate </param>
        /// <param name="closestPointY"> Closest point: Y coordinate </param>
        public static void GetClosestPointOnTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double closestPointX, out double closestPointY)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y);
            var distanceBC = DistanceToSegment(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y);
            var distanceCA = DistanceToSegment(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y);

            if (distanceAB < distanceBC && distanceAB < distanceCA)
            {
                GetClosestPointOnSegment(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y, out closestPointX, out closestPointY);
            }
            else if (distanceBC < distanceCA)
            {
                GetClosestPointOnSegment(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y, out closestPointX, out closestPointY);
            }
            else
            {
                GetClosestPointOnSegment(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y, out closestPointX, out closestPointY);
            }
        }

        /// <summary>
        /// Get closest point on the axis-oriented rectangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Closest point on the rectangle </returns>
        public static PointF GetClosestPointOnRect(this PointF point, RectangleF rect)
        {
            GetClosestPointOnRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height, out var closestPointX, out var closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the axis-oriented rectangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Closest point on the rectangle </returns>
        public static Point GetClosestPointOnRect(this Point point, Rectangle rect)
        {
            GetClosestPointOnRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height, out var closestPointX, out var closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the rectangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Closest point on the rectangle </returns>
        public static PointF GetClosestPointOnRect(this PointF point, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            GetClosestPointOnRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var closestPointX, out var closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the rectangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Closest point on the rectangle </returns>
        public static Point GetClosestPointOnRect(this Point point, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            GetClosestPointOnRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var closestPointX, out var closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the rectangle to the given point
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="closestPointX"> Closest point: X coordinate </param>
        /// <param name="closestPointY"> Closest point: Y coordinate </param>
        public static void GetClosestPointOnRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY, out double closestPointX, out double closestPointY)
        {
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            GetClosestPointOnRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY, out closestPointX, out closestPointY);
        }

        /// <summary>
        /// Get closest point on the rectangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> Closest point on the rectangle </returns>
        public static PointF GetClosestPointOnRect(this PointF point, PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            GetClosestPointOnRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y, out var closestPointX, out var closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the rectangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> Closest point on the rectangle </returns>
        public static Point GetClosestPointOnRect(this Point point, Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            GetClosestPointOnRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y, out var closestPointX, out var closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the rectangle to the given point
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
        /// <param name="closestPointX"> Closest point: X coordinate </param>
        /// <param name="closestPointY"> Closest point: Y coordinate </param>
        public static void GetClosestPointOnRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                        double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY, out double closestPointX, out double closestPointY)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY);
            var distanceBC = DistanceToSegment(pointX, pointY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY);
            var distanceCD = DistanceToSegment(pointX, pointY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
            var distanceDA = DistanceToSegment(pointX, pointY, rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY);

            if (distanceAB < distanceBC && distanceAB < distanceCD && distanceAB < distanceDA)
            {
                GetClosestPointOnSegment(pointX, pointY, rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY, out closestPointX, out closestPointY);
            }
            else if (distanceBC < distanceCD && distanceBC < distanceDA)
            {
                GetClosestPointOnSegment(pointX, pointY, rectLeftTopX, rectRightBottomY, rectRightBottomX, rectRightBottomY, out closestPointX, out closestPointY);
            }
            else if (distanceCD < distanceDA)
            {
                GetClosestPointOnSegment(pointX, pointY, rectRightBottomX, rectRightBottomY, rectRightBottomX, rectLeftTopY, out closestPointX, out closestPointY);
            }
            else
            {
                GetClosestPointOnSegment(pointX, pointY, rectRightBottomX, rectLeftTopY, rectLeftTopX, rectLeftTopY, out closestPointX, out closestPointY);
            }
        }

        #endregion

        #region GetLocation

        /// <summary>
        /// Get the point location relative to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointAgainstSegmentSimpleLocation GetRelativeLocationSimple(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetRelativeLocationSimple(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get the point location relative to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointAgainstSegmentSimpleLocation GetRelativeLocationSimple(this Point point, Point segmentStart, Point segmentEnd)
        {
            return GetRelativeLocationSimple(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get the point location relative to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointAgainstSegmentSimpleLocation GetRelativeLocationSimple(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            var scalarMult = (segmentEndY - segmentStartY) * (pointX - segmentStartX) - (segmentEndX - segmentStartX) * (pointY - segmentStartY);

            if (scalarMult > 0)
            {
                return PointAgainstSegmentSimpleLocation.Left;
            }

            if (scalarMult < 0)
            {
                return PointAgainstSegmentSimpleLocation.Right;
            }

            return PointAgainstSegmentSimpleLocation.OnTheSegment;
        }

        /// <summary>
        /// Get the point location relative to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        public static PointAgainstSegmentLocation GetRelativeLocation(PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetRelativeLocation(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get the point location relative to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        public static PointAgainstSegmentLocation GetRelativeLocation(Point point, Point segmentStart, Point segmentEnd)
        {
            return GetRelativeLocation(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get the point location relative to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Point relative location </returns>
        public static PointAgainstSegmentLocation GetRelativeLocation(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            var diffSegmentX = segmentEndX - segmentStartX;
            var diffSegmentY = segmentEndY - segmentStartY;

            var diffToPointX = pointX - segmentStartX;
            var diffToPointY = pointY - segmentStartY;

            var diffKoef = diffSegmentX * diffToPointY - diffToPointX * diffSegmentY;

            if (diffKoef > 0.0)
            {
                return PointAgainstSegmentLocation.Left;
            }

            if (diffKoef < 0.0)
            {
                return PointAgainstSegmentLocation.Right;
            }

            if (diffSegmentX * diffToPointX < 0.0 || diffSegmentY * diffToPointY < 0.0)
            {
                return PointAgainstSegmentLocation.Behind;
            }

            if (diffSegmentX * diffSegmentX + diffSegmentY * diffSegmentY < diffToPointX * diffToPointX + diffToPointY * diffToPointY)
            {
                return PointAgainstSegmentLocation.Beyond;
            }

            if (segmentStartX.AboutEquals(pointX) && segmentStartY.AboutEquals(pointY))
            {
                return PointAgainstSegmentLocation.Start;
            }

            if (segmentEndX.AboutEquals(pointX) && segmentEndY.AboutEquals(pointY))
            {
                return PointAgainstSegmentLocation.End;
            }

            return PointAgainstSegmentLocation.Between;
        }

        /// <summary>
        /// Get the point location relative to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return GetRelativeLocationTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get the point location relative to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return GetRelativeLocationTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get the point location relative to the triangle
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="apex1X"> Apex 1: X Coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y Coordinate </param>
        /// <param name="apex2X"> Apex 2: X Coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y Coordinate </param>
        /// <param name="apex3X"> Apex 3: X Coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y Coordinate </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            var abLocation = GetRelativeLocationSimple(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y);
            var bcLocation = GetRelativeLocationSimple(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y);
            var caLocation = GetRelativeLocationSimple(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y);

            if (abLocation != PointAgainstSegmentSimpleLocation.Left && bcLocation != PointAgainstSegmentSimpleLocation.Left && caLocation != PointAgainstSegmentSimpleLocation.Left)
            {
                return PointAgainstFigureLocation.Outside;
            }

            if (abLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || bcLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || caLocation == PointAgainstSegmentSimpleLocation.OnTheSegment)
            {
                return PointAgainstFigureLocation.OnTheEdge;
            }

            return PointAgainstFigureLocation.Inside;
        }

        /// <summary>
        /// Get the point location relative to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(this PointF point, PointF circleCenterPoint, float circleRadius)
        {
            return GetRelativeLocationCircle(point.X, point.Y, circleCenterPoint.X, circleCenterPoint.Y, circleRadius);
        }

        /// <summary>
        /// Get the point location relative to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(this Point point, Point circleCenterPoint, int circleRadius)
        {
            return GetRelativeLocationCircle(point.X, point.Y, circleCenterPoint.X, circleCenterPoint.Y, circleRadius);
        }

        /// <summary>
        /// Get the point location relative to the circle
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="circleCenterPointX"> Circle center point: X Coordinate </param>
        /// <param name="circleCenterPointY"> Circle center point: Y Coordinate </param>
        /// <param name="circleCenterRadius"> Circle center radius </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(double pointX, double pointY, double circleCenterPointX, double circleCenterPointY, double circleCenterRadius)
        {
            var diff = DistanceToSqr(pointX, pointY, circleCenterPointX, circleCenterPointY);
            var radSqr = circleCenterRadius * circleCenterRadius;

            if (diff < radSqr)
            {
                return PointAgainstFigureLocation.Inside;
            }

            return diff.AboutEquals(radSqr) ? PointAgainstFigureLocation.OnTheEdge : PointAgainstFigureLocation.Outside;
        }

        /// <summary>
        /// Get the point location relative to the axis-parallel ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationEllipse(this PointF point, PointF ellipseCenter, float semiMajor, float semiMinor)
        {
            return GetRelativeLocationEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the point location relative to the axis-parallel ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationEllipse(this Point point, Point ellipseCenter, int semiMajor, int semiMinor)
        {
            return GetRelativeLocationEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, semiMajor, semiMinor);
        }

        /// <summary>
        /// Check if the point belongs to an axis-parallel ellipse
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationEllipse(double pointX, double pointY, double ellipseCenterX, double ellipseCenterY, double semiMajor, double semiMinor)
        {
            var dX = pointX - ellipseCenterX;
            var dY = pointY - ellipseCenterY;

            var diff = dX * dX / (semiMajor * semiMajor) + dY * dY / (semiMinor * semiMinor);

            if (diff < 1)
            {
                return PointAgainstFigureLocation.Inside;
            }

            return diff.AboutEquals(1) ? PointAgainstFigureLocation.OnTheEdge : PointAgainstFigureLocation.Outside;
        }

        /// <summary>
        /// Get the point location relative to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(this PointF point, RectangleF rect)
        {
            return GetRelativeLocationRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Get the point location relative to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(this Point point, Rectangle rect)
        {
            return GetRelativeLocationRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Get the point location relative to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(this PointF point, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            return GetRelativeLocationRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Get the point location relative to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(this Point point, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            return GetRelativeLocationRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Get the point location relative to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            return GetRelativeLocationRect(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
        }

        /// <summary>
        /// Get the point location relative to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(this PointF point, PointF rectLeftTop, PointF rectRightTop, PointF rectRightBottom, PointF rectLeftBottom)
        {
            return GetRelativeLocationRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Get the point location relative to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTop"> Rectangle left top </param>
        /// <param name="rectRightTop"> Rectangle right top </param>
        /// <param name="rectRightBottom"> Rectangle right bottom </param>
        /// <param name="rectLeftBottom"> Rectangle left bottom </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(this Point point, Point rectLeftTop, Point rectRightTop, Point rectRightBottom, Point rectLeftBottom)
        {
            return GetRelativeLocationRect(point.X, point.Y, rectLeftTop.X, rectLeftTop.Y, rectRightTop.X, rectRightTop.Y, rectRightBottom.X, rectRightBottom.Y, rectLeftBottom.X, rectLeftBottom.Y);
        }

        /// <summary>
        /// Get the point location relative to the rectangle
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
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightTopX, double rectRightTopY,
                                                                         double rectRightBottomX, double rectRightBottomY, double rectLeftBottomX, double rectLeftBottomY)
        {
            var abLocation = GetRelativeLocationSimple(pointX, pointY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY);
            var bcLocation = GetRelativeLocationSimple(pointX, pointY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY);
            var cdLocation = GetRelativeLocationSimple(pointX, pointY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY);
            var daLocation = GetRelativeLocationSimple(pointX, pointY, rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY);

            if (abLocation != PointAgainstSegmentSimpleLocation.Left && bcLocation != PointAgainstSegmentSimpleLocation.Left &&
                cdLocation != PointAgainstSegmentSimpleLocation.Left && daLocation != PointAgainstSegmentSimpleLocation.Left)
            {
                return PointAgainstFigureLocation.Outside;
            }

            if (abLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || bcLocation == PointAgainstSegmentSimpleLocation.OnTheSegment ||
                cdLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || daLocation == PointAgainstSegmentSimpleLocation.OnTheSegment)
            {
                return PointAgainstFigureLocation.OnTheEdge;
            }

            return PointAgainstFigureLocation.Inside;
        }

        #endregion

        #region Projection

        /// <summary>
        /// Get projection from the point to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static PointF GetProjectionToLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            GetProjectionToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out var projectionPoint1, out var projectionPoint2);
            return new PointF((float)projectionPoint1, (float)projectionPoint2);
        }

        /// <summary>
        /// Get projection from the point to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static Point GetProjectionToLine(this Point point, Point linePoint1, Point linePoint2)
        {
            GetProjectionToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out var projectionPoint1, out var projectionPoint2);
            return new Point((int)projectionPoint1, (int)projectionPoint2);
        }

        /// <summary>
        /// Get projection from the point to the line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="projectionPointX"> Projection point: X coordinate </param>
        /// <param name="projectionPointY"> Projection point: Y coordinate </param>
        public static void GetProjectionToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, out double projectionPointX, out double projectionPointY)
        {
            LineGeo.FindSlopeKoef(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, out var k, out var b);

            if (k.AboutZero())
            {
                projectionPointX = pointX;
                projectionPointY = b;

                return;
            }

            if (double.IsInfinity(k))
            {
                projectionPointX = b;
                projectionPointY = pointY;

                return;
            }

            var k2 = -1 / k;
            var b2 = pointY - pointX * k2;
            projectionPointX = (b2 - b) / (k - k2);
            projectionPointY = k * projectionPointX + b;
        }

        /// <summary>
        /// Get projection from the point to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yZeroValue"> Y value if x = 0 </param>
        /// <returns> Projection point </returns>
        public static PointF GetProjectionToLine(this PointF point, float slopeKoef, float yZeroValue)
        {
            if (slopeKoef.AboutZero())
            {
                return new PointF(point.X, yZeroValue);
            }

            if (double.IsInfinity(slopeKoef))
            {
                return new PointF(yZeroValue, point.Y);
            }

            var diffSlopeKoef = -1 / slopeKoef;
            var yZeroValueKoef = point.Y - point.X * diffSlopeKoef;

            var x = (yZeroValueKoef - yZeroValue) / (slopeKoef - diffSlopeKoef);
            var y = slopeKoef * x + yZeroValue;

            return new PointF(x, y);
        }

        /// <summary>
        /// Get projection from the point to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yZeroValue"> Y value if x = 0 </param>
        /// <returns> Projection point </returns>
        public static Point GetProjectionToLine(this Point point, int slopeKoef, int yZeroValue)
        {
            if (slopeKoef == 0)
            {
                return new Point(point.X, yZeroValue);
            }

            if (double.IsInfinity(slopeKoef))
            {
                return new Point(yZeroValue, point.Y);
            }

            var diffSlopeKoef = -1 / slopeKoef;
            var yZeroValueKoef = point.Y - point.X * diffSlopeKoef;

            var x = (yZeroValueKoef - yZeroValue) / (slopeKoef - diffSlopeKoef);
            var y = slopeKoef * x + yZeroValue;

            return new Point(x, y);
        }

        /// <summary>
        /// Check if the point has projection to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasProjectionToSegment(this PointF point, PointF segmentStartPoint, PointF segmentEndPoint)
        {
            return HasProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y);
        }

        /// <summary>
        /// Check if the point has projection to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasProjectionToSegment(this Point point, Point segmentStartPoint, Point segmentEndPoint)
        {
            return HasProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y);
        }

        /// <summary>
        /// Check if the point has projection to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartPointX"> Start segment point 1: X coordinate </param>
        /// <param name="segmentStartPointY"> Start segment point 1: Y coordinate </param>
        /// <param name="segmentEndPointX"> End segment point 2: X coordinate </param>
        /// <param name="segmentEndPointY"> End segment point 2: Y coordinate </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasProjectionToSegment(double pointX, double pointY, double segmentStartPointX, double segmentStartPointY, double segmentEndPointX, double segmentEndPointY)
        {
            GetProjectionToLine(pointX, pointY, segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY, out var projectionPointX, out var projectionPointY);

            var startToProjectionDiff = DistanceTo(segmentStartPointX, segmentStartPointY, projectionPointX, projectionPointY);
            var endToProjectionDiff = DistanceTo(segmentEndPointX, segmentEndPointY, projectionPointX, projectionPointY);
            var segmentDiff = DistanceTo(segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY);

            return Math.Abs(startToProjectionDiff + endToProjectionDiff - segmentDiff) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Get projection point to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Line point 1 </param>
        /// <param name="segmentEndPoint"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static PointF GetProjectionToSegment(this PointF point, PointF segmentStartPoint, PointF segmentEndPoint)
        {
            GetProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y, out var projectionPoint1, out var projectionPoint2);
            return new PointF((float)projectionPoint1, (float)projectionPoint2);
        }

        /// <summary>
        /// Get projection point to the segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Line point 1 </param>
        /// <param name="segmentEndPoint"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static Point GetProjectionToSegment(this Point point, Point segmentStartPoint, Point segmentEndPoint)
        {
            GetProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y, out var projectionPoint1, out var projectionPoint2);
            return new Point((int)projectionPoint1, (int)projectionPoint2);
        }

        /// <summary>
        /// Get projection point to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartPointX"> Line point 1: X coordinate </param>
        /// <param name="segmentStartPointY"> Line point 1: Y coordinate </param>
        /// <param name="segmentEndPointX"> Line point 2: X coordinate </param>
        /// <param name="segmentEndPointY"> Line point 2: Y coordinate </param>
        /// <param name="projectionPointX"> Projection point: X coordinate </param>
        /// <param name="projectionPointY"> Projection point: Y coordinate </param>
        public static void GetProjectionToSegment(double pointX, double pointY, double segmentStartPointX, double segmentStartPointY, double segmentEndPointX, double segmentEndPointY,
                                                  out double projectionPointX, out double projectionPointY)
        {
            var dX = segmentEndPointX - segmentStartPointX;
            var dY = segmentEndPointY - segmentStartPointY;
            var diff = dX * dX + dY * dY;
            var u = ((pointX - segmentStartPointX) * dX + (pointY - segmentStartPointY) * dY) / diff;

            projectionPointX = segmentStartPointX + u * dX;
            projectionPointY = segmentStartPointY + u * dY;
        }

        #endregion

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <returns> True, if equals </returns>
        public static bool Equals(this PointF point1, PointF point2)
        {
            return DistanceTo(point1, point2) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <returns> True, if equals </returns>
        public static bool Equals(this Point point1, Point point2)
        {
            return DistanceTo(point1, point2) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> True, if equals </returns>
        public static bool Equals(double point1X, double point1Y, double point2X, double point2Y)
        {
            return DistanceTo(point1X, point1Y, point2X, point2Y) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Check if three points are collinear
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="point3"> Point 3 </param>
        /// <returns> True, if points are collinear </returns>
        public static bool IsCollinear(this PointF point1, PointF point2, PointF point3)
        {
            return IsCollinear(point1.X, point1.Y, point2.X, point2.Y, point3.X, point3.Y);
        }

        /// <summary>
        /// Check if three points are collinear
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="point3"> Point 3 </param>
        /// <returns> True, if points are collinear </returns>
        public static bool IsCollinear(this Point point1, Point point2, Point point3)
        {
            return IsCollinear(point1.X, point1.Y, point2.X, point2.Y, point3.X, point3.Y);
        }

        /// <summary>
        /// Check if three points are collinear
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <param name="point3X"> Point 3: X coordinate </param>
        /// <param name="point3Y"> Point 3: Y coordinate </param>
        /// <returns> True, if points are collinear </returns>
        public static bool IsCollinear(double point1X, double point1Y, double point2X, double point2Y, double point3X, double point3Y)
        {
            return ((point3Y - point2Y) * (point2X - point1X)).AboutEquals((point2Y - point1Y) * (point3X - point2X));
        }

        /// <summary>
        /// Rotate the point around the center point
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static PointF Rotate(this PointF point, PointF center, double angleRadian)
        {
            Rotate(point.X, point.Y, center.X, center.Y, angleRadian, out var rotatedPointX, out var rotatedPointY);
            return new PointF((float)rotatedPointX, (float)rotatedPointY);
        }

        /// <summary>
        /// Rotate the point around the center point
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static Point Rotate(this Point point, Point center, double angleRadian)
        {
            Rotate(point.X, point.Y, center.X, center.Y, angleRadian, out var rotatedPointX, out var rotatedPointY);
            return new Point((int)rotatedPointX, (int)rotatedPointY);
        }

        /// <summary>
        /// Rotate the point around the center point
        /// </summary>
        /// <param name="pointX">Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="centerX"> Center point: X coordinate </param>
        /// <param name="centerY"> Center point: Y coordinate </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <param name="rotatedPointX"> Rotated point: X coordinate </param>
        /// <param name="rotatedPointY"> Rotated point: Y coordinate </param>
        public static void Rotate(double pointX, double pointY, double centerX, double centerY, double angleRadian, out double rotatedPointX, out double rotatedPointY)
        {
            var diffX = pointX - centerX;
            var diffY = pointY - centerY;

            rotatedPointX = centerX + diffX * Math.Cos(angleRadian) - diffY * Math.Sin(angleRadian);
            rotatedPointY = centerY + diffX * Math.Sin(angleRadian) + diffY * Math.Cos(angleRadian);
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Vector product </returns>
        public static float GetVectorProduct(PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetVectorProduct(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Vector product </returns>
        public static float GetVectorProduct(Point point, Point segmentStart, Point segmentEnd)
        {
            return GetVectorProduct(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Vector product </returns>
        public static float GetVectorProduct(float pointX, float pointY, float segmentStartX, float segmentStartY, float segmentEndX, float segmentEndY)
        {
            return (segmentEndY - segmentStartY) * (pointX - segmentStartX) - (segmentEndX - segmentStartX) * (pointY - segmentStartY);
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Vector product </returns>
        public static double GetVectorProduct(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return (segmentEndY - segmentStartY) * (pointX - segmentStartX) - (segmentEndX - segmentStartX) * (pointY - segmentStartY);
        }

        /// <summary>
        /// Get axis-degree angle between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <returns> Angle (degrees) </returns>
        public static double GetAngle(this PointF point1, PointF point2)
        {
            return GetAngle(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get axis-degree angle between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <returns> Angle (degrees) </returns>
        public static double GetAngle(this Point point1, Point point2)
        {
            return GetAngle(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get axis-degree angle between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Angle (degrees) </returns>
        public static double GetAngle(double point1X, double point1Y, double point2X, double point2Y)
        {
            var dx = point2X - point1X;
            var dy = point2Y - point1Y;

            var angle = Convert.ToInt32(Utils.ConvertRadianToDegree(Math.Atan2(dy, dx)));

            return angle < 0 ? angle + 360 : angle;
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="curve"> Curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToCurveLine(this PointF point, PointF[] curve)
        {
            return CurveLineGeo.MinDistanceToPoint(curve, point);
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="curve"> Curve </param>
        /// <param name="nearestPointIndex"> Index of the nearest point in the curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToCurveLine(this PointF point, PointF[] curve, out int nearestPointIndex)
        {
            return CurveLineGeo.MinDistanceToPoint(curve, point, out nearestPointIndex);
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="curve"> Curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToCurveLine(this Point point, Point[] curve)
        {
            return CurveLineGeo.MinDistanceToPoint(curve, point);
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="curve"> Curve </param>
        /// <param name="nearestPointIndex"> Index of the nearest point in the curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToCurveLine(this Point point, Point[] curve, out int nearestPointIndex)
        {
            return CurveLineGeo.MinDistanceToPoint(curve, point, out nearestPointIndex);
        }
    }
}
