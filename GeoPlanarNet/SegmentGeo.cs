﻿using GeoPlanarNet.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the line segment
    /// </summary>
    public static class SegmentGeo
    {
        #region Intersection

        /// <summary>
        /// Check if the curve line and the segment has intersection
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="curve"> Curve </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasSurfaceIntersection(PointF segmentStartPoint, PointF segmentEndPoint, PointF[] curve)
        {
            return CurveLineGeo.HasIntersection(curve, segmentStartPoint, segmentEndPoint);
        }

        /// <summary>
        /// Check if the curve line and the segment has intersection
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="curve"> Curve </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasSurfaceIntersection(Point segmentStartPoint, Point segmentEndPoint, Point[] curve)
        {
            return CurveLineGeo.HasIntersection(curve, segmentStartPoint, segmentEndPoint);
        }

        /// <summary>
        /// Find the intersection point between the segment and the surface
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="curve"> Curve </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindSurfaceIntersection(PointF segmentStartPoint, PointF segmentEndPoint, PointF[] curve, out PointF intersectionPoint)
        {
            return CurveLineGeo.FindIntersection(curve, segmentStartPoint, segmentEndPoint, out intersectionPoint);
        }

        /// <summary>
        /// Find the intersection point between the segment and the surface
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="curve"> Curve </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindSurfaceIntersection(Point segmentStartPoint, Point segmentEndPoint, Point[] curve, out Point intersectionPoint)
        {
            return CurveLineGeo.FindIntersection(curve, segmentStartPoint, segmentEndPoint, out intersectionPoint);
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(PointF segment1Start, PointF segment1End, PointF segment2Start, PointF segment2End)
        {
            return FindIntersection(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y, out _, out _);
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(Point segment1Start, Point segment1End, Point segment2Start, Point segment2End)
        {
            return FindIntersection(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y, out _, out _);
        }

        /// <summary>
        /// Find the intersection point between two segments
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(PointF segment1Start, PointF segment1End, PointF segment2Start, PointF segment2End, out PointF intersectionPoint)
        {
            var hasIntersection = FindIntersection(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y, out var x, out var y);
            intersectionPoint = hasIntersection ? new PointF((float)x, (float)y) : PointF.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Find the intersection point between two segments
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(Point segment1Start, Point segment1End, Point segment2Start, Point segment2End, out Point intersectionPoint)
        {
            var hasIntersection = FindIntersection(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y, out var x, out var y);
            intersectionPoint = hasIntersection ? new Point((int)x, (int)y) : Point.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Find the intersection point between two segments
        /// </summary>
        /// <param name="segment1StartX"> Segment 1, start point: coordinate X </param>
        /// <param name="segment1StartY"> Segment 1, start point: coordinate Y </param>
        /// <param name="segment1EndX"> Segment 1, end point: coordinate X </param>
        /// <param name="segment1EndY"> Segment 1, end point: coordinate Y </param>
        /// <param name="segment2StartX"> Segment 2, start point: coordinate X </param>
        /// <param name="segment2StartY"> Segment 2, start point: coordinate Y </param>
        /// <param name="segment2EndX"> Segment 2, end point: coordinate X </param>
        /// <param name="segment2EndY"> Segment 2, end point: coordinate Y </param>
        /// <param name="intesectionX"> Intersection point: coordinate X; NaN if not intersects </param>
        /// <param name="intersectionY"> Intersection point: coordinate Y; NaN if not intersects </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY, double segment2StartX, double segment2StartY, double segment2EndX, double segment2EndY, out double intesectionX, out double intersectionY)
        {
            intesectionX = intersectionY = 0;
            var minx1 = Math.Min(segment1StartX, segment1EndX);
            var miny1 = Math.Min(segment1StartY, segment1EndY);
            var maxx1 = Math.Max(segment1StartX, segment1EndX);
            var maxy1 = Math.Max(segment1StartY, segment1EndY);
            var minx2 = Math.Min(segment2StartX, segment2EndX);
            var miny2 = Math.Min(segment2StartY, segment2EndY);
            var maxx2 = Math.Max(segment2StartX, segment2EndX);
            var maxy2 = Math.Max(segment2StartY, segment2EndY);

            if (minx1 > maxx2 + GeoPlanarNet.Epsilon || maxx1 + GeoPlanarNet.Epsilon < minx2 || miny1 > maxy2 + GeoPlanarNet.Epsilon || maxy1 + GeoPlanarNet.Epsilon < miny2)
            {
                return false;
            }

            var segment1ProjectionX = segment1EndX - segment1StartX;
            var segment1ProjectionY = segment1EndY - segment1StartY;
            var segment2ProjectionX = segment2EndX - segment2StartX;
            var segment2ProjectionY = segment2EndY - segment2StartY;

            var div = segment2ProjectionY * segment1ProjectionX - segment2ProjectionX * segment1ProjectionY;

            if (Math.Abs(div) < GeoPlanarNet.Epsilon)
            {
                return false;
            }

            var segment12ProjectionX = segment1StartX - segment2StartX;
            var segment12ProjectionY = segment1StartY - segment2StartY;
            var koef = (segment1ProjectionX * segment12ProjectionY - segment1ProjectionY * segment12ProjectionX) / div;

            if (koef < -GeoPlanarNet.Epsilon || koef > 1 + GeoPlanarNet.Epsilon)
            {
                return false;
            }

            koef = (segment2ProjectionX * segment12ProjectionY - segment2ProjectionY * segment12ProjectionX) / div;

            if (koef < -GeoPlanarNet.Epsilon || koef > 1 + GeoPlanarNet.Epsilon)
            {
                return false;
            }

            intesectionX = segment1StartX + koef * (segment1EndX - segment1StartX);
            intersectionY = segment1StartY + koef * (segment1EndY - segment1StartY);

            return true;
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasRectIntersection(PointF segmentStart, PointF segmentEnd, RectangleF rect)
        {
            return FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                     out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rectLeftTop"> Rectangle left top point </param>
        /// <param name="rectRightBottom"> Rectangle right bottom point </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasRectIntersection(PointF segmentStart, PointF segmentEnd, PointF rectLeftTop, PointF rectRightBottom)
        {
            return FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y,
                out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasRectIntersection(Point segmentStart, Point segmentEnd, Rectangle rect)
        {
            return FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                              out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rectLeftTop"> Rectangle left top point </param>
        /// <param name="rectRightBottom"> Rectangle right bottom point </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool HasRectIntersection(Point segmentStart, Point segmentEnd, Point rectLeftTop, Point rectRightBottom)
        {
            return FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y,
                out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rectLeftTop"> Rectangle left top point </param>
        /// <param name="rectRightBottom"> Rectangle right bottom point </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindRectIntersection(PointF segmentStart, PointF segmentEnd, PointF rectLeftTop, PointF rectRightBottom, out PointF intersection1, out PointF intersection2)
        {
            intersection1 = intersection2 = PointF.Empty;
            var hasIntersection = FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rectLeftTop.X, rectLeftTop.Y, rectRightBottom.X, rectRightBottom.Y,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new PointF((float)intersection1X, (float)intersection1Y);
                intersection2 = new PointF((float)intersection2X, (float)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="rect"> Rectangle </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindRectIntersection(PointF segmentStart, PointF segmentEnd, RectangleF rect, out PointF intersection1, out PointF intersection2)
        {
            intersection1 = intersection2 = PointF.Empty;
            var hasIntersection = FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new PointF((float)intersection1X, (float)intersection1Y);
                intersection2 = new PointF((float)intersection2X, (float)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between the segment and the axis-oriented rectangle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="rect"> Rectangle </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindRectIntersection(Point segmentStart, Point segmentEnd, Rectangle rect, out Point intersection1, out Point intersection2)
        {
            intersection1 = intersection2 = Point.Empty;
            var hasIntersection = FindRectIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new Point((int)intersection1X, (int)intersection1Y);
                intersection2 = new Point((int)intersection2X, (int)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between the segment and the rectangle
        /// </summary>
        /// <param name="segmentStartX"> Line point 1: X coordinate </param>
        /// <param name="segmentStartY"> Line point 1: Y coordinate </param>
        /// <param name="segmentEndX"> Line point 2: X coordinate </param>
        /// <param name="segmentEndY"> Line point 2: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if the segment and the rectangle has intersection </returns>
        public static bool FindRectIntersection(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY,
                                                out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            intersection1X = intersection1Y = intersection2X = intersection2Y = double.NaN;

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, out var tempX, out var tempY))
            {
                intersection1X = tempX;
                intersection1Y = tempY;
            }

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, out tempX, out tempY))
            {
                if (double.IsNaN(intersection1X) && double.IsNaN(intersection1Y))
                {
                    intersection1X = tempX;
                    intersection1Y = tempY;
                }
                else
                {
                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY, out tempX, out tempY))
            {
                if (double.IsNaN(intersection1X) && double.IsNaN(intersection1Y))
                {
                    intersection1X = tempX;
                    intersection1Y = tempY;
                }
                else
                {
                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY, out tempX, out tempY))
            {
                if (double.IsNaN(intersection1X) && double.IsNaN(intersection1Y))
                {
                    intersection1X = tempX;
                    intersection1Y = tempY;
                }
                else
                {
                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            var hasIntersection = !double.IsNaN(intersection2X) && !double.IsNaN(intersection2Y);

            if (hasIntersection)
            {
                if (PointGeo.DistanceTo(segmentStartX, segmentStartY, intersection2X, intersection2Y) < PointGeo.DistanceTo(segmentStartX, segmentStartY, intersection1X, intersection1Y))
                {
                    tempX = intersection1X;
                    tempY = intersection1Y;

                    intersection1X = intersection2X;
                    intersection1Y = intersection2Y;

                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool HasTriangleIntersection(PointF segmentStart, PointF segmentEnd, PointF apex1, PointF apex2, PointF apex3)
        {
            return FindTriangleIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                     out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool HasTriangleIntersection(Point segmentStart, Point segmentEnd, PointF apex1, PointF apex2, PointF apex3)
        {
            return FindTriangleIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                              out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool FindTriangleIntersection(PointF segmentStart, PointF segmentEnd, PointF apex1, PointF apex2, PointF apex3, out PointF intersection1, out PointF intersection2)
        {
            intersection1 = intersection2 = PointF.Empty;
            var hasIntersection = FindTriangleIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new PointF((float)intersection1X, (float)intersection1Y);
                intersection2 = new PointF((float)intersection2X, (float)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool FindTriangleIntersection(Point segmentStart, Point segmentEnd, PointF apex1, PointF apex2, PointF apex3, out Point intersection1, out Point intersection2)
        {
            intersection1 = intersection2 = Point.Empty;
            var hasIntersection = FindTriangleIntersection(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new Point((int)intersection1X, (int)intersection1Y);
                intersection2 = new Point((int)intersection2X, (int)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="segmentStartX"> Line point 1: X coordinate </param>
        /// <param name="segmentStartY"> Line point 1: Y coordinate </param>
        /// <param name="segmentEndX"> Line point 2: X coordinate </param>
        /// <param name="segmentEndY"> Line point 2: Y coordinate </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool FindTriangleIntersection(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y,
                                                out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            intersection1X = intersection1Y = intersection2X = intersection2Y = double.NaN;

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, apex1X, apex1Y, apex2X, apex2Y, out var tempX, out var tempY))
            {
                intersection1X = tempX;
                intersection1Y = tempY;
            }

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, apex2X, apex2Y, apex3X, apex3Y, out tempX, out tempY))
            {
                if (double.IsNaN(intersection1X) && double.IsNaN(intersection1Y))
                {
                    intersection1X = tempX;
                    intersection1Y = tempY;
                }
                else
                {
                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            if (FindIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, apex3X, apex3Y, apex1X, apex1Y, out tempX, out tempY))
            {
                if (double.IsNaN(intersection1X) && double.IsNaN(intersection1Y))
                {
                    intersection1X = tempX;
                    intersection1Y = tempY;
                }
                else
                {
                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            var hasIntersection = !double.IsNaN(intersection2X) && !double.IsNaN(intersection2Y);

            if (hasIntersection)
            {
                if (PointGeo.DistanceTo(segmentStartX, segmentStartY, intersection2X, intersection2Y) < PointGeo.DistanceTo(segmentStartX, segmentStartY, intersection1X, intersection1Y))
                {
                    tempX = intersection1X;
                    tempY = intersection1Y;

                    intersection1X = intersection2X;
                    intersection1Y = intersection2Y;

                    intersection2X = tempX;
                    intersection2Y = tempY;
                }
            }

            return hasIntersection;
        }

        #endregion

        #region DistanceTo

        /// <summary>
        /// Get shortest distance from point to the segment
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToPoint(PointF segmentStart, PointF segmentEnd, PointF point)
        {
            return point.DistanceToSegment(segmentStart, segmentEnd);
        }

        /// <summary>
        /// Get shortest distance from point to the segment
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToPoint(Point segmentStart, Point segmentEnd, Point point)
        {
            return point.DistanceToSegment(segmentStart, segmentEnd);
        }

        /// <summary>
        /// Get shortest distance from point to the segment
        /// </summary>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> Distance from the point to the segment </returns>
        public static double DistanceToPoint(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double pointX, double pointY)
        {
            return PointGeo.DistanceToSegment(pointX, pointY, segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

        /// <summary>
        /// Get shortest distance from the segment to the circle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the segment and the circle </returns>
        public static double DistanceToCircle(PointF segmentStart, PointF segmentEnd, PointF circleCenter, float circleRadius)
        {
            return DistanceToCircle(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the segment to the circle
        /// </summary>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the segment and the circle </returns>
        public static double DistanceToCircle(Point segmentStart, Point segmentEnd, Point circleCenter, int circleRadius)
        {
            return DistanceToCircle(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the segment to the circle
        /// </summary>
        /// <param name="segmentStartX"> Segment, start point: coordinate X </param>
        /// <param name="segmentStartY"> Segment, start point: coordinate Y </param>
        /// <param name="segmentEndX"> Segment, end point: coordinate X </param>
        /// <param name="segmentEndY"> Segment, end point: coordinate Y </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Distance between the segment and the circle </returns>
        public static double DistanceToCircle(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double circleCenterX, double circleCenterY, double radius)
        {
            return PointGeo.DistanceToSegment(circleCenterX, circleCenterY, segmentStartX, segmentStartY, segmentEndX, segmentEndY) - radius;
        }

        #endregion

        /// <summary>
        /// Get segment length
        /// </summary>
        /// <param name="segmentStart"> Start segment point </param>
        /// <param name="segmentEnd"> End segment point </param>
        /// <returns> Segment length </returns>
        public static double Length(PointF segmentStart, PointF segmentEnd)
        {
            return Length(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get segment length
        /// </summary>
        /// <param name="segmentStart"> Start segment point </param>
        /// <param name="segmentEnd"> End segment point </param>
        /// <returns> Segment length </returns>
        public static double Length(Point segmentStart, Point segmentEnd)
        {
            return Length(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get segment length
        /// </summary>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: X coordinate </param>
        /// <param name="segmentEndX"> Segment end point: Y coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Segment length </returns>
        public static double Length(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return PointGeo.DistanceTo(segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

        /// <summary>
        /// Get segment squared length
        /// </summary>
        /// <param name="segmentStart"> Start segment point </param>
        /// <param name="segmentEnd"> End segment point </param>
        /// <returns> Segment length </returns>
        public static double LengthSqr(PointF segmentStart, PointF segmentEnd)
        {
            return LengthSqr(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get segment squared length
        /// </summary>
        /// <param name="segmentStart"> Start segment point </param>
        /// <param name="segmentEnd"> End segment point </param>
        /// <returns> Segment length </returns>
        public static double LengthSqr(Point segmentStart, Point segmentEnd)
        {
            return LengthSqr(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get segment squared length
        /// </summary>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: X coordinate </param>
        /// <param name="segmentEndX"> Segment end point: Y coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Segment length </returns>
        public static double LengthSqr(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return PointGeo.DistanceToSqr(segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

        /// <summary>
        /// Check if the segment belongs to the line
        /// </summary>
        /// <param name="segmentStart"> Start segment point </param>
        /// <param name="segmentEnd"> End segment point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> True, if the segment belongs to the line </returns>
        public static bool BelongsToLine(PointF segmentStart, PointF segmentEnd, PointF linePoint1, PointF linePoint2)
        {
            return BelongsToLine(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Check if the segment belongs to the line
        /// </summary>
        /// <param name="segmentStart"> Start segment point </param>
        /// <param name="segmentEnd"> End segment point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> True, if the segment belongs to the line </returns>
        public static bool BelongsToLine(Point segmentStart, Point segmentEnd, Point linePoint1, Point linePoint2)
        {
            return BelongsToLine(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Check if the segment belongs to the line
        /// </summary>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: X coordinate </param>
        /// <param name="segmentEndX"> Segment end point: Y coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <param name="linePoint1X"> Segment start point: X coordinate </param>
        /// <param name="linePoint1Y"> Segment start point: Y coordinate </param>
        /// <param name="linePoint2X"> Segment end point: X coordinate </param>
        /// <param name="linePoint2Y"> Segment end point: Y coordinate </param>
        /// <returns> True, if the segment belongs to the line </returns>
        public static bool BelongsToLine(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            return PointGeo.BelongsToLine(segmentStartX, segmentStartY, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y) &&
                   PointGeo.BelongsToLine(segmentEndX, segmentEndY, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y);
        }

        /// <summary>
        /// Get the segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Angle (radians) </returns>
        public static double GetXAngleRadians(this PointF segmentStart, PointF segmentEnd)
        {
            return GetXAngleRadians(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get the segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Angle (radians) </returns>
        public static double GetXAngleRadians(this Point segmentStart, PointF segmentEnd)
        {
            return GetXAngleRadians(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get the segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="segmentStartX"> Start point: X coordinate </param>
        /// <param name="segmentStartY"> Start point: Y coordinate </param>
        /// <param name="segmentEndX"> End point: X coordinate </param>
        /// <param name="segmentEndY"> End point: Y coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double GetXAngleRadians(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            var diffX = segmentEndX - segmentStartX;
            var diffY = segmentEndY - segmentStartY;

            if (diffX.AboutZero())
            {
                return diffY > 0 ? Math.PI / 2 : 3 * GeoPlanarNet.RightAngle;
            }

            var angle = Math.Atan2(diffY, diffX);

            return angle < 0 ? angle + 2 * Math.PI : angle;
        }

        /// <summary>
        /// Get angle between two segments
        /// </summary>
        /// <param name="segment1Start"> Start point of 1 segment </param>
        /// <param name="segment1End"> End point of 1 segment </param>
        /// <param name="segment2Start"> Start point of 2 segment </param>
        /// <param name="segment2End"> End point of 2 segment </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(PointF segment1Start, PointF segment1End, PointF segment2Start, PointF segment2End)
        {
            return GetAngleRadians(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments
        /// </summary>
        /// <param name="segment1Start"> Start point of 1 segment </param>
        /// <param name="segment1End"> End point of 1 segment </param>
        /// <param name="segment2Start"> Start point of 2 segment </param>
        /// <param name="segment2End"> End point of 2 segment </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(Point segment1Start, Point segment1End, Point segment2Start, Point segment2End)
        {
            return GetAngleRadians(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments
        /// </summary>
        /// <param name="segment1StartX"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment1StartY"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment1EndX"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment1EndY"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment2StartX"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment2StartY"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment2EndX"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment2EndY"> Start point of 1 segment: X coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY,
                                                 double segment2StartX, double segment2StartY, double segment2EndX, double segment2EndY)
        {
            var diff1X = segment1EndX - segment1StartX;
            var diff1Y = segment1EndY - segment1StartY;
            var diff2X = segment2EndX - segment2StartX;
            var diff2Y = segment2EndY - segment2StartY;

            var angle = (diff1X * diff2X + diff1Y * diff2Y) / (Math.Sqrt(diff1X * diff1X + diff1Y * diff1Y) * Math.Sqrt(diff2X * diff2X + diff2Y * diff2Y));

            return Math.Acos(Math.Round(angle, 3));
        }

        /// <summary>
        /// Get angle in radians between two segments with the common point: (commonPoint, startPoint1) and (commonPoint, startPoint2)
        /// </summary>
        /// <param name="commonPoint"> Common point </param>
        /// <param name="segment1Start"> Start point of the segment 1 </param>
        /// <param name="segment2Start"> Start point of the segment 2 </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(PointF commonPoint, PointF segment1Start, PointF segment2Start)
        {
            return GetAngleRadians(commonPoint.X, commonPoint.Y, segment1Start.X, segment1Start.Y, segment2Start.X, segment2Start.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments with the common point: (commonPoint, startPoint1) and (commonPoint, startPoint2)
        /// </summary>
        /// <param name="commonPoint"> Common point </param>
        /// <param name="segment1Start"> Start point of the segment 1 </param>
        /// <param name="segment2Start"> Start point of the segment 2 </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(Point commonPoint, Point segment1Start, Point segment2Start)
        {
            return GetAngleRadians(commonPoint.X, commonPoint.Y, segment1Start.X, segment1Start.Y, segment2Start.X, segment2Start.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments with the common point: (commonPoint, startPoint1) and (commonPoint, startPoint2)
        /// </summary>
        /// <param name="commonPointX"> Common point: X coordinate </param>
        /// <param name="commonPointY"> Common point: Y coordinate </param>
        /// <param name="segment1StartX"> Start point of 1 segment: X coordinate </param>
        /// <param name="segment1StartY"> Start point of 1 segment: Y coordinate </param>
        /// <param name="segment2StartX"> Start point of 2 segment: X coordinate </param>
        /// <param name="segment2StartY"> Start point of 2 segment: Y coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(double commonPointX, double commonPointY, double segment1StartX, double segment1StartY, double segment2StartX, double segment2StartY)
        {
            var numerator = (segment1StartX - commonPointX) * (segment2StartX - commonPointX) + (segment1StartY - commonPointY) * (segment2StartY - commonPointY);
            var denominator = PointGeo.DistanceTo(segment1StartX, segment1StartY, commonPointX, commonPointY) * PointGeo.DistanceTo(segment2StartX, segment2StartY, commonPointX, commonPointY);

            return Math.Acos(numerator / denominator);
        }

        /// <summary>
        /// Check if the segment lays between start angle and end angle (angles from the start point)
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="sectorStartAngleRad"> Start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Start angle (radians) </param>
        /// <returns> True, if the segment lays between angles </returns>
        public static bool IsBetweenAngles(PointF segmentStart, PointF segmentEnd, float sectorStartAngleRad, float sectorEndAngleRad)
        {
            return IsBetweenAngles(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the segment lays between start angle and end angle (angles from the start point)
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="sectorStartAngleRad"> Start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Start angle (radians) </param>
        /// <returns> True, if the segment lays between angles </returns>
        public static bool IsBetweenAngles(Point segmentStart, Point segmentEnd, double sectorStartAngleRad, double sectorEndAngleRad)
        {
            return IsBetweenAngles(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the segment lays between start angle and end angle (angles from the start point)
        /// </summary>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: X coordinate </param>
        /// <param name="segmentEndX"> Segment end point: Y coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <param name="sectorStartAngleRad"> Start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Start angle (radians) </param>
        /// <returns> True, if the segment lays between angles </returns>
        public static bool IsBetweenAngles(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double sectorStartAngleRad, double sectorEndAngleRad)
        {
            var ang = Math.Atan2(segmentEndY - segmentStartY, segmentEndX - segmentStartX);

            if (ang < 0)
            {
                ang += Math.PI * 2;
            }

            return ang >= sectorStartAngleRad && ang <= sectorEndAngleRad;
        }

        /// <summary>
        /// Get the point away from the segment start point on the specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from start point to the new point </param>
        /// <returns> New point away from the segment start </returns>
        public static PointF GetPointAwayFromStart(PointF segmentStart, PointF segmentEnd, double distance)
        {
            GetPointAwayFromStart(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out var newPointX, out var newPointY);
            return new PointF((float)newPointX, (float)newPointY);
        }

        /// <summary>
        /// Get the point away from the segment start point on the specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from start point to the new point </param>
        /// <returns> New point away from the segment start </returns>
        public static Point GetPointAwayFromStart(Point segmentStart, Point segmentEnd, int distance)
        {
            GetPointAwayFromStart(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out var newPointX, out var newPointY);
            return new Point((int)newPointX, (int)newPointY);
        }

        /// <summary>
        /// Get the point away from the segment start point on the specified distance
        /// </summary>
        /// <param name="segment1StartX"> Segment, start point: coordinate X </param>
        /// <param name="segment1StartY"> Segment, start point: coordinate Y </param>
        /// <param name="segment1EndX"> Segment, end point: coordinate X </param>
        /// <param name="segment1EndY"> Segment, end point: coordinate Y </param>
        /// <param name="distance"> Distance from start point to the new point </param>
        /// <param name="newPointX"> New point: coordinate X </param>
        /// <param name="newPointY"> New point: coordinate Y </param>
        public static void GetPointAwayFromStart(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY, double distance, out double newPointX, out double newPointY)
        {
            if (distance.AboutZero())
            {
                newPointX = segment1StartX;
                newPointY = segment1StartY;

                return;
            }

            var segmentLength = PointGeo.DistanceTo(segment1StartX, segment1StartY, segment1EndX, segment1EndY);

            if (Math.Abs(segmentLength) < GeoPlanarNet.Epsilon)
            {
                newPointX = segment1StartX;
                newPointY = segment1StartY;

                return;
            }

            var koef = distance / segmentLength;
            var x = segment1StartX + koef * (segment1EndX - segment1StartX);
            var y = segment1StartY + koef * (segment1EndY - segment1StartY);

            newPointX = x;
            newPointY = y;
        }

        /// <summary>
        /// Get the point away from the segment end point on the specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from end point to the new point </param>
        /// <returns> New point away from the segment end </returns>
        public static PointF GetPointAwayFromEnd(PointF segmentStart, PointF segmentEnd, double distance)
        {
            GetPointAwayFromEnd(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out var newPointX, out var newPointY);
            return new PointF((float)newPointX, (float)newPointY);
        }

        /// <summary>
        /// Get the point away from the segment end point on the specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from end point to the new point </param>
        /// <returns> New point away from the segment end </returns>
        public static Point GetPointAwayFromEnd(Point segmentStart, Point segmentEnd, int distance)
        {
            GetPointAwayFromEnd(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out var newPointX, out var newPointY);
            return new Point((int)newPointX, (int)newPointY);
        }

        /// <summary>
        /// Get the point away from the segment end point on the specified distance
        /// </summary>
        /// <param name="segmentStartX"> Segment, start point: coordinate X </param>
        /// <param name="segmentStartY"> Segment, start point: coordinate Y </param>
        /// <param name="segmentEndX"> Segment, end point: coordinate X </param>
        /// <param name="segmentEndY"> Segment, end point: coordinate Y </param>
        /// <param name="distance"> Distance from end point to the new point </param>
        /// <param name="newPointX"> New point: coordinate X </param>
        /// <param name="newPointY"> New point: coordinate Y </param>
        public static void GetPointAwayFromEnd(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double distance, out double newPointX, out double newPointY)
        {
            if (distance.AboutZero())
            {
                newPointX = segmentStartX;
                newPointY = segmentStartY;

                return;
            }

            var segmentLength = PointGeo.DistanceTo(segmentStartX, segmentStartY, segmentEndX, segmentEndY);

            if (Math.Abs(segmentLength) < GeoPlanarNet.Epsilon)
            {
                newPointX = segmentStartX;
                newPointY = segmentStartY;

                return;
            }

            var koef = (distance + segmentLength) / segmentLength;
            var x = segmentStartX + koef * (segmentEndX - segmentStartX);
            var y = segmentStartY + koef * (segmentEndY - segmentStartY);

            newPointX = x;
            newPointY = y;
        }

        /// <summary>
        /// Split the segment to small parts by the segments length
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="segmentsLength"> Length of each new segment </param>
        /// <returns> IList of consecutive segments </returns>
        public static PointF[] Split(PointF segmentStart, PointF segmentEnd, double segmentsLength)
        {
            var segmentLength = Length(segmentStart, segmentEnd);
            var newSegmentsCount = (int)(segmentLength / segmentsLength);

            newSegmentsCount += segmentLength <= newSegmentsCount * segmentsLength ? 1 : 2;
            newSegmentsCount -= 1;

            var result = new PointF[newSegmentsCount];
            var currentLength = segmentsLength;

            for (var i = 1; i < newSegmentsCount; ++i)
            {
                result[i] = GetPointAwayFromStart(segmentStart, segmentEnd, currentLength);

                currentLength += segmentsLength;
            }

            result[0] = segmentStart;
            result[newSegmentsCount] = segmentEnd;

            return result;
        }

        /// <summary>
        /// Split segment to small parts by segments length
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="segmentsLength"> Length of each new segment </param>
        /// <returns> IList of consecutive segments </returns>
        public static Point[] Split(Point segmentStart, Point segmentEnd, int segmentsLength)
        {
            var segmentLength = Length(segmentStart, segmentEnd);
            var newSegmentsCount = (int)(segmentLength / segmentsLength);

            newSegmentsCount += segmentLength <= newSegmentsCount * segmentsLength ? 1 : 2;
            newSegmentsCount -= 1;

            var result = new Point[newSegmentsCount];
            var currentLength = segmentsLength;

            for (var i = 1; i < newSegmentsCount; ++i)
            {
                result[i] = GetPointAwayFromStart(segmentStart, segmentEnd, currentLength);

                currentLength += segmentsLength;
            }

            result[0] = segmentStart;
            result[newSegmentsCount] = segmentEnd;

            return result;
        }

        /// <summary>
        /// Linear interpolation for point on the segment
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <returns> Point with X-Y coordinates </returns>
        public static PointF LinearInterpolation(PointF segmentStart, PointF segmentEnd, float pointX)
        {
            LinearInterpolation(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, pointX, out var pointY);
            return new PointF(pointX, (float)pointY);
        }

        /// <summary>
        /// Linear interpolation for point on the segment
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <returns> Point with X-Y coordinates </returns>
        public static Point LinearInterpolation(Point segmentStart, Point segmentEnd, int pointX)
        {
            LinearInterpolation(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, pointX, out var pointY);
            return new Point(pointX, (int)pointY);
        }

        /// <summary>
        /// Linear interpolation for point on the segment
        /// </summary>
        /// <param name="segmentStartX"> Segment, start point: coordinate X </param>
        /// <param name="segmentStartY"> Segment, start point: coordinate Y </param>
        /// <param name="segmentEndX"> Segment, end point: coordinate X </param>
        /// <param name="segmentEndY"> Segment, end point: coordinate Y </param>
        /// <param name="pointX"> Point: X coordiante</param>
        /// <param name="pointY"> Searchable point: Y coordinate </param>
        public static void LinearInterpolation(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double pointX, out double pointY)
        {
            var projectionX = segmentEndX - segmentStartX;

            if (projectionX.AboutZero())
            {
                pointY = (segmentStartY + segmentEndY) / 2;
            }
            else
            {
                pointY = segmentStartY + (pointX - segmentStartX) * (segmentEndY - segmentStartY) / projectionX;
            }
        }

        /// <summary>
        /// Linear interpolation with specified step
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="step"> Interpolation step </param>
        /// <returns> IList of interpolated points </returns>
        /// <exception cref="ArgumentException"> Exception if segmentStart more than segmentEnd </exception>
        public static IList<PointF> LinearInterpolationByStep(PointF segmentStart, PointF segmentEnd, float step)
        {
            if (segmentStart.X > segmentEnd.X)
            {
                throw new ArgumentException("Segment start point must be less than the segment end point");
            }

            var points = new List<PointF> { segmentStart };

            if (segmentStart.X.AboutEquals(segmentEnd.X))
            {
                points.Add(LinearInterpolation(segmentStart, segmentEnd, segmentStart.X));
                return points;
            }

            var i = segmentStart.X + step;

            while (i < segmentEnd.X)
            {
                points.Add(LinearInterpolation(segmentStart, segmentEnd, i));
                i += step;
            }

            points.Add(segmentEnd);
            return points;
        }

        /// <summary>
        /// Linear interpolation with specified step
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="step"> Interpolation step </param>
        /// <returns> IList of interpolated points </returns>
        /// <exception cref="ArgumentException"> Exception if segmentStart more than segmentEnd </exception>
        public static IList<Point> LinearInterpolationByStep(Point segmentStart, Point segmentEnd, int step)
        {
            if (segmentStart.X > segmentEnd.X)
            {
                throw new ArgumentException("Segment start point must be less than the segment end point");
            }

            var points = new List<Point> { segmentStart };

            if (segmentStart.X == segmentEnd.X)
            {
                points.Add(LinearInterpolation(segmentStart, segmentEnd, segmentStart.X));
                return points;
            }

            var i = segmentStart.X + step;

            while (i < segmentEnd.X)
            {
                points.Add(LinearInterpolation(segmentStart, segmentEnd, i));
                i += step;
            }

            points.Add(segmentEnd);
            return points;
        }

        /// <summary>
        /// Get the rectangle with one side equal to segment, another side equal to length
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="rectangleSideLength"> Another side length </param>
        /// <returns> Rectangle </returns>
        public static IList<PointF> GetRectangle(PointF segmentStart, PointF segmentEnd, float rectangleSideLength)
        {
            LineGeo.FindSlopeKoef(segmentStart, segmentEnd, out var slopeKoef, out var yZeroValue);

            var points = new List<PointF>();
            var halfLength = (float)rectangleSideLength / 2;

            if (double.IsInfinity(slopeKoef))
            {
                points.Add(new PointF(segmentStart.X - halfLength, segmentStart.Y));
                points.Add(new PointF(segmentStart.X - halfLength, segmentEnd.Y));
                points.Add(new PointF(segmentStart.X + halfLength, segmentEnd.Y));
                points.Add(new PointF(segmentStart.X + halfLength, segmentStart.Y));

                return points;
            }

            var cos = (float)Math.Cos(Math.Atan(slopeKoef));
            float koefMinus, koefPlus;

            if (slopeKoef < 0)
            {
                koefMinus = yZeroValue - halfLength / cos;
                koefPlus = yZeroValue + halfLength / cos;
            }
            else
            {
                koefMinus = yZeroValue + halfLength / cos;
                koefPlus = yZeroValue - halfLength / cos;
            }

            points.Add(segmentStart.GetProjectionToLine(slopeKoef, koefMinus));
            points.Add(segmentEnd.GetProjectionToLine(slopeKoef, koefMinus));
            points.Add(segmentEnd.GetProjectionToLine(slopeKoef, koefPlus));
            points.Add(segmentStart.GetProjectionToLine(slopeKoef, koefPlus));
            return points;
        }

        /// <summary>
        /// Check if two segments are parallel
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <returns> True, if segments are parallel </returns>
        public static bool IsParallel(PointF segment1Start, PointF segment1End, PointF segment2Start, PointF segment2End)
        {
            return IsParallel(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y);
        }

        /// <summary>
        /// Check if two segments are parallel
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <returns> True, if segments are parallel </returns>
        public static bool IsParallel(Point segment1Start, Point segment1End, Point segment2Start, Point segment2End)
        {
            return IsParallel(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y);
        }

        /// <summary>
        /// Check if two segments are parallel/anti-parallel
        /// </summary>
        /// <param name="segment1StartX"> Segment 1, start point: coordinate X </param>
        /// <param name="segment1StartY"> Segment 1, start point: coordinate Y </param>
        /// <param name="segment1EndX"> Segment 1, end point: coordinate X </param>
        /// <param name="segment1EndY"> Segment 1, end point: coordinate Y </param>
        /// <param name="segment2StartX"> Segment 2, start point: coordinate X </param>
        /// <param name="segment2StartY"> Segment 2, start point: coordinate Y </param>
        /// <param name="segment2EndX"> Segment 2, end point: coordinate X </param>
        /// <param name="segment2EndY"> Segment 2, end point: coordinate Y </param>
        /// <returns> True, if segments are parallel/anti-parallel </returns>
        public static bool IsParallel(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY, double segment2StartX, double segment2StartY, double segment2EndX, double segment2EndY)
        {
            return LineGeo.IsParallel(segment1StartX, segment1StartY, segment1EndX, segment1EndY, segment2StartX, segment2StartY, segment2EndX, segment2EndY);
        }

        /// <summary>
        /// Get the segment location relative to the triangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(PointF linePoint1, PointF linePoint2, PointF apex1, PointF apex2, PointF apex3)
        {
            return GetRelativeLocationTriangle(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get the segment location relative to the triangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(Point linePoint1, Point linePoint2, PointF apex1, PointF apex2, PointF apex3)
        {
            return GetRelativeLocationTriangle(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get the segment location relative to the triangle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Point location </returns>
        /// <remarks> Return 'inside' if has two intersections </remarks>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            FindTriangleIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y, out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            var hasIntersection1 = !double.IsNaN(intersection1X) && !double.IsNaN(intersection1Y);
            var hasIntersection2 = !double.IsNaN(intersection2X) && !double.IsNaN(intersection2Y);

            if (hasIntersection1 && hasIntersection2)
            {
                return PointAgainstFigureLocation.Inside;
            }

            if (hasIntersection1)
            {
                return PointAgainstFigureLocation.OnTheEdge;
            }

            return PointAgainstFigureLocation.Outside;
        }

        /// <summary>
        /// Cut the line to the segment by X bounds
        /// </summary>
        /// <param name="xBoundsMin"> Bounds X: min value </param>
        /// <param name="xBoundsMax"> Bounds X: max value </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True, if success </returns>
        public static bool CreateFromLine(double xBoundsMin, double xBoundsMax, PointF linePoint1, PointF linePoint2, out PointF segmentStart, out PointF segmentEnd)
        {
            return LineGeo.CutByXBounds(xBoundsMin, xBoundsMax, linePoint1, linePoint2, out segmentStart, out segmentEnd);
        }

        /// <summary>
        /// Cut the line to the segment by X bounds
        /// </summary>
        /// <param name="xBoundsMin"> Bounds X: min value </param>
        /// <param name="xBoundsMax"> Bounds X: max value </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> True, if success </returns>
        public static bool CreateFromLine(double xBoundsMin, double xBoundsMax, Point linePoint1, Point linePoint2, out Point segmentStart, out Point segmentEnd)
        {
            return LineGeo.CutByXBounds(xBoundsMin, xBoundsMax, linePoint1, linePoint2, out segmentStart, out segmentEnd);
        }

        /// <summary>
        /// Cut the line to the segment by X bounds
        /// </summary>
        /// <param name="xBoundsMin"> Bounds X: min value </param>
        /// <param name="xBoundsMax"> Bounds X: max value </param>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="segmentStartX"> Segment start point: X </param>
        /// <param name="segmentStartY"> Segment start point: Y </param>
        /// <param name="segmentEndX"> Segment end point: X </param>
        /// <param name="segmentEndY"> Segment end point: Y </param>
        /// <returns> True, if success </returns>
        public static bool CreateFromLine(double xBoundsMin, double xBoundsMax, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y,
                                        out double segmentStartX, out double segmentStartY, out double segmentEndX, out double segmentEndY)
        {
            return LineGeo.CutByXBounds(xBoundsMin, xBoundsMax, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, out segmentStartX, out segmentStartY, out segmentEndX, out segmentEndY);
        }

        /// <summary>
        /// Check if the point has projection to the segment
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasPointProjection(PointF segmentStartPoint, PointF segmentEndPoint, PointF point)
        {
            return point.HasProjectionToSegment(segmentStartPoint, segmentEndPoint);
        }

        /// <summary>
        /// Check if the point has projection to the segment
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasPointProjection(Point segmentStartPoint, Point segmentEndPoint, Point point)
        {
            return point.HasProjectionToSegment(segmentStartPoint, segmentEndPoint);
        }

        /// <summary>
        /// Check if the point has projection to the segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartPointX"> Start segment point: X coordinate </param>
        /// <param name="segmentStartPointY"> Start segment point: Y coordinate </param>
        /// <param name="segmentEndPointX"> End segment point: X coordinate </param>
        /// <param name="segmentEndPointY"> End segment point: Y coordinate </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasPointProjection(double segmentStartPointX, double segmentStartPointY, double segmentEndPointX, double segmentEndPointY, double pointX, double pointY)
        {
            return PointGeo.HasProjectionToSegment(pointX, pointY, segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY);
        }

        /// <summary>
        /// Get projection point to the segment
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> Projection point </returns>
        public static PointF GetPointProjection(PointF segmentStartPoint, PointF segmentEndPoint, PointF point)
        {
            return point.GetProjectionToSegment(segmentStartPoint, segmentEndPoint);
        }

        /// <summary>
        /// Get projection point to the segment
        /// </summary>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> Projection point </returns>
        public static Point GetPointProjection(Point segmentStartPoint, Point segmentEndPoint, Point point)
        {
            return point.GetProjectionToSegment(segmentStartPoint, segmentEndPoint);
        }

        /// <summary>
        /// Get projection point to the segment
        /// </summary>
        /// <param name="segmentStartPointX"> Start segment point: X coordinate </param>
        /// <param name="segmentStartPointY"> Start segment point: Y coordinate </param>
        /// <param name="segmentEndPointX"> End segment point: X coordinate </param>
        /// <param name="segmentEndPointY"> End segment point: Y coordinate </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="projectionPointX"> Projection point: X coordinate </param>
        /// <param name="projectionPointY"> Projection point: Y coordinate </param>
        public static void GetPointProjection(double segmentStartPointX, double segmentStartPointY, double segmentEndPointX, double segmentEndPointY, double pointX, double pointY,
                                                  out double projectionPointX, out double projectionPointY)
        {
            PointGeo.GetProjectionToSegment(pointX, pointY, segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY, out projectionPointX, out projectionPointY);
        }

        /// <summary>
        /// Check if the segment contains the point
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the segment contains the point </returns>
        public static bool Contains(PointF segmentStart, PointF segmentEnd, PointF point)
        {
            return point.BelongsToSegment(segmentStart, segmentEnd);
        }

        /// <summary>
        /// Check if the segment contains the point
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the segment contains the point </returns>
        public static bool Contains(Point segmentStart, Point segmentEnd, Point point)
        {
            return point.BelongsToSegment(segmentStart, segmentEnd);
        }

        /// <summary>
        /// Check if the segment contains the point
        /// </summary>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coordinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the segment contains the point </returns>
        public static bool Contains(double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY, double pointX, double pointY)
        {
            return PointGeo.BelongsToSegment(pointX, pointY, segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }
    }
}
