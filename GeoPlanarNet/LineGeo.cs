using System;
using System.Drawing;
using GeoPlanarNet.Enums;

namespace GeoPlanarNet
{
    public static class LineGeo
    {
        /// <summary>
        /// Check if two lines have intersection
        /// </summary>
        /// <param name="line1Point1"> Line 1, point 1 </param>
        /// <param name="line1Point2"> Line 1, point 2 </param>
        /// <param name="line2Point1"> Line 2, point 1 </param>
        /// <param name="line2Point2"> Line 2, point 2 </param>
        /// <returns> True, if lines have intersection </returns>
        public static bool HasIntersection(PointF line1Point1, PointF line1Point2, PointF line2Point1, PointF line2Point2)
        {
            return FindIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out _, out _);
        }

        /// <summary>
        /// Check if two lines have intersection
        /// </summary>
        /// <param name="line1Point1"> Line 1, point 1 </param>
        /// <param name="line1Point2"> Line 1, point 2 </param>
        /// <param name="line2Point1"> Line 2, point 1 </param>
        /// <param name="line2Point2"> Line 2, point 2 </param>
        /// <returns> True, if lines have intersection </returns>
        public static bool HasIntersection(Point line1Point1, Point line1Point2, Point line2Point1, Point line2Point2)
        {
            return FindIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out _, out _);
        }

        /// <summary>
        /// Check if two lines have intersection
        /// </summary>
        /// <param name="line1Point1"> Line 1, point 1 </param>
        /// <param name="line1Point2"> Line 1, point 2 </param>
        /// <param name="line2Point1"> Line 2, point 1 </param>
        /// <param name="line2Point2"> Line 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if lines have intersection </returns>
        public static bool FindIntersection(PointF line1Point1, PointF line1Point2, PointF line2Point1, PointF line2Point2, out PointF intersectionPoint)
        {
            var hasIntersection = FindIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out var x, out var y);
            intersectionPoint = hasIntersection ? new PointF((float)x, (float)y) : PointF.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Check if two lines have intersection
        /// </summary>
        /// <param name="line1Point1"> Line 1, point 1 </param>
        /// <param name="line1Point2"> Line 1, point 2 </param>
        /// <param name="line2Point1"> Line 2, point 1 </param>
        /// <param name="line2Point2"> Line 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if lines have intersection </returns>
        public static bool FindIntersection(Point line1Point1, Point line1Point2, Point line2Point1, Point line2Point2, out Point intersectionPoint)
        {
            var hasIntersection = FindIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out var x, out var y);
            intersectionPoint = hasIntersection ? new Point((int)x, (int)y) : Point.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Check if two lines have intersection
        /// </summary>
        /// <param name="line1x1"> Line 1, point 1: coordinate X </param>
        /// <param name="line1y1"> Line 1, point 1: coordinate Y </param>
        /// <param name="line1x2"> Line 1, point 2: coordinate X </param>
        /// <param name="line1y2"> Line 1, point 2: coordinate Y </param>
        /// <param name="line2x1"> Line 2, point 1: coordinate X </param>
        /// <param name="line2y1"> Line 2, point 1: coordinate Y </param>
        /// <param name="line2x2"> Line 2, point 2: coordinate X </param>
        /// <param name="line2y2"> Line 2, point 2: coordinate Y </param>
        /// <param name="intesectionX"> Intersection point: coordinate X; NaN if not intersects </param>
        /// <param name="intersectionY"> Intersection point: coordinate Y; NaN if not intersects </param>
        /// <returns> True, if lines have intersection </returns>
        public static bool FindIntersection(double line1x1, double line1y1, double line1x2, double line1y2, double line2x1, double line2y1, double line2x2, double line2y2, out double intesectionX, out double intersectionY)
        {
            intesectionX = intersectionY = double.NaN;

            var projectionLengthX1 = line1x2 - line1x1;
            var projectionLengthY1 = line1y2 - line1y1;

            var projectionLengthX2 = line2x2 - line2x1;
            var projectionLengthY2 = line2y2 - line2y1;

            if (GeoPlanarNet.AboutZero(projectionLengthX1) && GeoPlanarNet.AboutZero(projectionLengthY1) && GeoPlanarNet.AboutZero(projectionLengthX2) && GeoPlanarNet.AboutZero(projectionLengthY2))
            {
                var lineIsPoint = GeoPlanarNet.AboutEquals(line1x1, line2x2) && GeoPlanarNet.AboutEquals(line1y1, line2y2);

                if (lineIsPoint)
                {
                    intesectionX = line1x1;
                    intersectionY = line1y1;
                }

                return lineIsPoint;
            }

            if (GeoPlanarNet.AboutZero(projectionLengthX1) && GeoPlanarNet.AboutZero(projectionLengthY1))
            {
                var line1IsPoint = PointGeo.DistanceToSegment(line1x1, line1y1, line2x1, line2y1, line2x2, line2y2) < GeoPlanarNet.Epsilon;

                if (line1IsPoint)
                {
                    intesectionX = line1x1;
                    intersectionY = line1y1;
                }

                return line1IsPoint;
            }

            if (GeoPlanarNet.AboutZero(projectionLengthX2) && GeoPlanarNet.AboutZero(projectionLengthY2))
            {
                var line2IsPoint = PointGeo.DistanceToSegment(line2x1, line2y1, line1x1, line1y1, line1x2, line1y2) < GeoPlanarNet.Epsilon;

                if (line2IsPoint)
                {
                    intesectionX = line2x1;
                    intersectionY = line2y1;
                }

                return line2IsPoint;
            }

            var div = projectionLengthY2 * projectionLengthX1 - projectionLengthX2 * projectionLengthY1;

            if (GeoPlanarNet.AboutZero(div))
            {
                return false;
            }

            var koefIv = (projectionLengthX2 * (line1y1 - line2y1) - projectionLengthY2 * (line1x1 - line2x1)) / div;
            intesectionX = line1x1 + koefIv * (line1x2 - line1x1);
            intersectionY = line1y1 + koefIv * (line1y2 - line1y1);

            return true;
        }

        /// <summary>
        /// Find intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool HasRectIntersection(PointF linePoint1, PointF linePoint2, RectangleF rect)
        {
            return FindRectIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                     out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Find intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool HasRectIntersection(Point linePoint1, Point linePoint2, Rectangle rect)
        {
            return FindRectIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                              out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Find intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="rect"> Rectangle </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool FindRectIntersection(PointF linePoint1, PointF linePoint2, RectangleF rect, out PointF intersection1, out PointF intersection2)
        {
            intersection1 = intersection2 = PointF.Empty;
            var hasIntersection = FindRectIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new PointF((float)intersection1X, (float)intersection1Y);
                intersection2 = new PointF((float)intersection2X, (float)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="rect"> Rectangle </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool FindRectIntersection(Point linePoint1, Point linePoint2, Rectangle rect, out Point intersection1, out Point intersection2)
        {
            intersection1 = intersection2 = Point.Empty;
            var hasIntersection = FindRectIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new Point((int)intersection1X, (int)intersection1Y);
                intersection2 = new Point((int)intersection2X, (int)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool FindRectIntersection(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY,
                                                out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            RectGeo.GetPoints(rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY, out var rectRightTopX, out var rectRightTopY, out var rectLeftBottomX, out var rectLeftBottomY);

            intersection1X = intersection1Y = intersection2X = intersection2Y = double.NaN;

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectLeftTopX, rectLeftTopY, rectRightTopX, rectRightTopY, out var tempX, out var tempY))
            {
                intersection1X = tempX;
                intersection1Y = tempY;
            }

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectRightTopX, rectRightTopY, rectRightBottomX, rectRightBottomY, out tempX, out tempY))
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

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectRightBottomX, rectRightBottomY, rectLeftBottomX, rectLeftBottomY, out tempX, out tempY))
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

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectLeftBottomX, rectLeftBottomY, rectLeftTopX, rectLeftTopY, out tempX, out tempY))
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
                if (PointGeo.DistanceTo(linePoint1X, linePoint1Y, intersection2X, intersection2Y) < PointGeo.DistanceTo(linePoint1X, linePoint1Y, intersection1X, intersection1Y))
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
        /// Find intersection between line and triangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> True if line and triangle has intersection </returns>
        public static bool HasTriangleIntersection(PointF linePoint1, PointF linePoint2, PointF apex1, PointF apex2, PointF apex3)
        {
            return FindTriangleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                     out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Find intersection between line and triangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> True if line and triangle has intersection </returns>
        public static bool HasTriangleIntersection(Point linePoint1, Point linePoint2, PointF apex1, PointF apex2, PointF apex3)
        {
            return FindTriangleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                              out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Find intersection between line and triangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and triangle has intersection </returns>
        public static bool FindTriangleIntersection(PointF linePoint1, PointF linePoint2, PointF apex1, PointF apex2, PointF apex3, out PointF intersection1, out PointF intersection2)
        {
            intersection1 = intersection2 = PointF.Empty;
            var hasIntersection = FindTriangleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new PointF((float)intersection1X, (float)intersection1Y);
                intersection2 = new PointF((float)intersection2X, (float)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between line and triangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and triangle has intersection </returns>
        public static bool FindTriangleIntersection(Point linePoint1, Point linePoint2, PointF apex1, PointF apex2, PointF apex3, out Point intersection1, out Point intersection2)
        {
            intersection1 = intersection2 = Point.Empty;
            var hasIntersection = FindTriangleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new Point((int)intersection1X, (int)intersection1Y);
                intersection2 = new Point((int)intersection2X, (int)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between line and triangle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
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
        /// <returns> True if line and triangle has intersection </returns>
        public static bool FindTriangleIntersection(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y,
                                                out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            intersection1X = intersection1Y = intersection2X = intersection2Y = double.NaN;

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, apex1X, apex1Y, apex2X, apex2Y, out var tempX, out var tempY))
            {
                intersection1X = tempX;
                intersection1Y = tempY;
            }

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, apex2X, apex2Y, apex3X, apex3Y, out tempX, out tempY))
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

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, apex3X, apex3Y, apex1X, apex1Y, out tempX, out tempY))
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
                if (PointGeo.DistanceTo(linePoint1X, linePoint1Y, intersection2X, intersection2Y) < PointGeo.DistanceTo(linePoint1X, linePoint1Y, intersection1X, intersection1Y))
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
        /// Has intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool HasCircleIntersection(PointF linePoint1, PointF linePoint2, PointF circleCenter, float radius)
        {
            return FindCircleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, radius,
                                     out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Has intersection between line and rectangle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True if line and rectangle has intersection </returns>
        public static bool HasCircleIntersection(Point linePoint1, Point linePoint2, PointF circleCenter, float radius)
        {
            return FindCircleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, radius,
                                              out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Has intersection between line and circle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True if line and circle has intersection </returns>
        public static bool HasCircleIntersection(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double circleCenterX, double circleCenterY, double radius)
        {
            return FindCircleIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterX, circleCenterY, radius,
                                  out var _, out var _, out var _, out var _);
        }

        /// <summary>
        /// Find intersection between line and circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and circle has intersection </returns>
        public static bool FindCircleIntersection(PointF linePoint1, PointF linePoint2, PointF circleCenter, float radius, out PointF intersection1, out PointF intersection2)
        {
            intersection1 = intersection2 = Point.Empty;
            var hasIntersection = FindCircleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, radius,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new Point((int)intersection1X, (int)intersection1Y);
                intersection2 = new Point((int)intersection2X, (int)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between line and circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if line and circle has intersection </returns>
        public static bool FindCircleIntersection(Point linePoint1, Point linePoint2, Point circleCenter, int radius, out Point intersection1, out Point intersection2)
        {
            intersection1 = intersection2 = Point.Empty;
            var hasIntersection = FindCircleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, radius,
                                              out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

            if (hasIntersection)
            {
                intersection1 = new Point((int)intersection1X, (int)intersection1Y);
                intersection2 = new Point((int)intersection2X, (int)intersection2Y);
            }

            return hasIntersection;
        }

        /// <summary>
        /// Find intersection between line and circle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if line and circle has intersection </returns>
        public static bool FindCircleIntersection(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double circleCenterX, double circleCenterY, double radius,
            out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            intersection1X = intersection1Y = intersection2X = intersection2Y = double.NaN;

            var dx = linePoint2X - linePoint1X;
            var dy = linePoint2Y - linePoint1Y;

            var A = dx * dx + dy * dy;
            var B = 2 * (dx * (linePoint1X - circleCenterX) + dy * (linePoint1Y - circleCenterY));
            var C = (linePoint1X - circleCenterX) * (linePoint1X - circleCenterX) + (linePoint1Y - circleCenterY) * (linePoint1Y - circleCenterY) - radius * radius;

            var determinant = B * B - 4 * A * C;

            if (GeoPlanarNet.AboutZero(A) || determinant < 0)
            {
                return false;
            }

            if (GeoPlanarNet.AboutZero(determinant))
            {
                var koef = -B / (2 * A);
                intersection1X = linePoint1X + koef * dx;
                intersection1Y = linePoint1Y + koef * dy;
            }
            else
            {
                var koef = (float)((-B + Math.Sqrt(determinant)) / (2 * A));
                intersection1X = linePoint1X + koef * dx;
                intersection1Y = linePoint1Y + koef * dy;

                koef = (float)((-B - Math.Sqrt(determinant)) / (2 * A));
                intersection2X = linePoint1X + koef * dx;
                intersection2Y = linePoint1Y + koef * dy;
            }

            return true;
        }

        /// <summary>
        /// Get koefficients of line linear function K and B
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yIntersection"> Y value if x = 0 </param>
        internal static void FindSlopeKoef(PointF linePoint1, PointF linePoint2, out float slopeKoef, out float yIntersection)
        {
            FindSlopeKoef(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out var slopeKoefD, out var yIntersectionD);

            slopeKoef = (float)slopeKoefD;
            yIntersection = (float)yIntersectionD;
        }

        /// <summary>
        /// Get koefficients of line linear function K and B
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yIntersection"> Y value if x = 0 </param>
        internal static void FindSlopeKoef(Point linePoint1, Point linePoint2, out double slopeKoef, out double yIntersection)
        {
            FindSlopeKoef(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out slopeKoef, out yIntersection);
        }

        /// <summary>
        /// Get koefficients of line linear function K and B
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yIntersection"> Y value if x = 0 </param>
        internal static void FindSlopeKoef(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, out double slopeKoef, out double yIntersection)
        {
            slopeKoef = (linePoint1Y - linePoint2Y) / (linePoint1X - linePoint2X);
            yIntersection = double.IsInfinity(slopeKoef) ? linePoint2X : linePoint2Y - linePoint2X * slopeKoef;
        }

        /// <summary>
        /// Cut line to segment by X bounds
        /// </summary>
        /// <param name="xBoundsMin"> Bounds X: min value </param>
        /// <param name="xBoundsMax"> Bounds X: max value </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Flag, if success </returns>
        public static bool CutByXBounds(double xBoundsMin, double xBoundsMax, ref PointF linePoint1, ref PointF linePoint2)
        {
            var linePoint1X = (double)linePoint1.X;
            var linePoint1Y = (double)linePoint1.Y;
            var linePoint2X = (double)linePoint2.X;
            var linePoint2Y = (double)linePoint2.Y;

            var result = CutByXBounds(xBoundsMin, xBoundsMax, ref linePoint1X, ref linePoint1Y, ref linePoint2X, ref linePoint2Y);
            linePoint1 = new PointF((float)linePoint1X, (float)linePoint1Y);
            linePoint2 = new PointF((float)linePoint2X, (float)linePoint2Y);

            return result;
        }

        /// <summary>
        /// Cut line to segment by X bounds
        /// </summary>
        /// <param name="xBoundsMin"> Bounds X: min value </param>
        /// <param name="xBoundsMax"> Bounds X: max value </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Flag, if success </returns>
        public static bool CutByXBounds(double xBoundsMin, double xBoundsMax, ref Point linePoint1, ref Point linePoint2)
        {
            var linePoint1X = (double)linePoint1.X;
            var linePoint1Y = (double)linePoint1.Y;
            var linePoint2X = (double)linePoint2.X;
            var linePoint2Y = (double)linePoint2.Y;

            var result = CutByXBounds(xBoundsMin, xBoundsMax, ref linePoint1X, ref linePoint1Y, ref linePoint2X, ref linePoint2Y);
            linePoint1 = new Point((int)linePoint1X, (int)linePoint1Y);
            linePoint2 = new Point((int)linePoint2X, (int)linePoint2Y);

            return result;
        }

        /// <summary>
        /// Cut line to segment by X bounds
        /// </summary>
        /// <param name="xBoundsMin"> Bounds X: min value </param>
        /// <param name="xBoundsMax"> Bounds X: max value </param>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <returns> Flag, if success </returns>
        public static bool CutByXBounds(double xBoundsMin, double xBoundsMax, ref double linePoint1X, ref double linePoint1Y, ref double linePoint2X, ref double linePoint2Y)
        {
            if (Math.Min(linePoint1X, linePoint2X) > xBoundsMax || Math.Max(linePoint1X, linePoint2X) < xBoundsMin)
            {
                return false;
            }


            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, xBoundsMin, Math.Min(linePoint1Y, linePoint2Y) - 1, xBoundsMin, Math.Max(linePoint1Y, linePoint2Y) + 1, out var x, out var y))
            {
                if (linePoint1X <= xBoundsMin)
                {
                    linePoint1X = x;
                    linePoint1Y = y;
                }
                else
                {
                    linePoint2X = x;
                    linePoint2Y = y;
                }
            }

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, xBoundsMax, Math.Min(linePoint1Y, linePoint2Y) - 1, xBoundsMax, Math.Max(linePoint1Y, linePoint2Y) + 1, out x, out y))
            {
                if (linePoint1X >= xBoundsMax)
                {
                    linePoint1X = x;
                    linePoint1Y = y;
                }
                else
                {
                    linePoint2X = x;
                    linePoint2Y = y;
                }
            }

            return true;
        }

        /// <summary>
        /// Get the line location relative to the triangle
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
        /// Get the line location relative to the triangle
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
        /// Get the line location relative to the triangle
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
        /// Get the line location relative to the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(PointF linePoint1, PointF linePoint2, PointF circleCenterPoint, float circleRadius)
        {
            return GetRelativeLocationCircle(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenterPoint.X, circleCenterPoint.Y, circleRadius);
        }

        /// <summary>
        /// Get the line location relative to the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(Point linePoint1, Point linePoint2, Point circleCenterPoint, int circleRadius)
        {
            return GetRelativeLocationCircle(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenterPoint.X, circleCenterPoint.Y, circleRadius);
        }

        /// <summary>
        /// Get the line location relative to the circle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="circleCenterPointX"> Circle center point: X Coordinate </param>
        /// <param name="circleCenterPointY"> Circle center point: Y Coordinate </param>
        /// <param name="circleCenterRadius"> Circle cente radius </param>
        /// <returns> Point location </returns>
        /// <remarks> Return 'inside' if has two intersections </remarks>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double circleCenterPointX, double circleCenterPointY, double circleCenterRadius)
        {
            FindCircleIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterPointX, circleCenterPointY, circleCenterRadius, out var intersection1X, out var intersection1Y, out var intersection2X, out var intersection2Y);

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
        /// Get shortest distance from the line to the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the line and the circle </returns>
        public static double DistanceToCircle(PointF linePoint1, PointF linePoint2, PointF circleCenter, float circleRadius)
        {
            return DistanceToCircle(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the line to the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the line and the circle </returns>
        public static double DistanceToCircle(Point linePoint1, Point linePoint2, Point circleCenter, int circleRadius)
        {
            return DistanceToCircle(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the line to the circle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Distance between the line and the circle </returns>
        public static double DistanceToCircle(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double circleCenterX, double circleCenterY, double radius)
        {
            return PointGeo.DistanceToLine(circleCenterX, circleCenterY, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y) - radius;
        }

        /// <summary>
        /// Check if two lines are parallel
        /// </summary>
        /// <param name="line1Point1"> Line 1, point 1 </param>
        /// <param name="line1Point2"> Line 1, point 2 </param>
        /// <param name="line2Point1"> Line 2, point 1 </param>
        /// <param name="line2Point2"> Line 2, point 2 </param>
        /// <returns> True, if lines are parallel </returns>
        public static bool IsParallel(PointF line1Point1, PointF line1Point2, PointF line2Point1, PointF line2Point2)
        {
            return IsParallel(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y);
        }

        /// <summary>
        /// Check if two lines are parallel
        /// </summary>
        /// <param name="line1Point1"> Line 1, point 1 </param>
        /// <param name="line1Point2"> Line 1, point 2 </param>
        /// <param name="line2Point1"> Line 2, point 1 </param>
        /// <param name="line2Point2"> Line 2, point 2 </param>
        /// <returns> True, if lines are parallel </returns>
        public static bool IsParallel(Point line1Point1, Point line1Point2, Point line2Point1, Point line2Point2)
        {
            return IsParallel(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y);
        }

        /// <summary>
        /// Check if two lines are parallel/anti-parallel
        /// </summary>
        /// <param name="line1x1"> Line 1, point 1: coordinate X </param>
        /// <param name="line1y1"> Line 1, point 1: coordinate Y </param>
        /// <param name="line1x2"> Line 1, point 2: coordinate X </param>
        /// <param name="line1y2"> Line 1, point 2: coordinate Y </param>
        /// <param name="line2x1"> Line 2, point 1: coordinate X </param>
        /// <param name="line2y1"> Line 2, point 1: coordinate Y </param>
        /// <param name="line2x2"> Line 2, point 2: coordinate X </param>
        /// <param name="line2y2"> Line 2, point 2: coordinate Y </param>
        /// <returns> True, if lines are parallel/anti-parallel </returns>
        public static bool IsParallel(double line1x1, double line1y1, double line1x2, double line1y2, double line2x1, double line2y1, double line2x2, double line2y2)
        {
            var dx1 = line1x2 - line1x1;
            var dy1 = line1y2 - line1y1;
            var dx2 = line2x2 - line2x1;
            var dy2 = line2y2 - line2y1;
            var cosAngle = Math.Abs((dx1 * dx2 + dy1 * dy2) / Math.Sqrt((dx1 * dx1 + dy1 * dy1) * (dx2 * dx2 + dy2 * dy2)));
            return cosAngle.AboutEquals(1);
        }
    }
}
