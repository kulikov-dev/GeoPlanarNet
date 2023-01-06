using System;
using System.Drawing;
using GeoPlanarNet.Enums;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the line
    /// </summary>
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
        /// <param name="line1X1"> Line 1, point 1: coordinate X </param>
        /// <param name="line1Y1"> Line 1, point 1: coordinate Y </param>
        /// <param name="line1X2"> Line 1, point 2: coordinate X </param>
        /// <param name="line1Y2"> Line 1, point 2: coordinate Y </param>
        /// <param name="line2X1"> Line 2, point 1: coordinate X </param>
        /// <param name="line2Y1"> Line 2, point 1: coordinate Y </param>
        /// <param name="line2X2"> Line 2, point 2: coordinate X </param>
        /// <param name="line2Y2"> Line 2, point 2: coordinate Y </param>
        /// <param name="intesectionX"> Intersection point: coordinate X; NaN if not intersects </param>
        /// <param name="intersectionY"> Intersection point: coordinate Y; NaN if not intersects </param>
        /// <returns> True, if lines have intersection </returns>
        public static bool FindIntersection(double line1X1, double line1Y1, double line1X2, double line1Y2, double line2X1, double line2Y1, double line2X2, double line2Y2, out double intesectionX, out double intersectionY)
        {
            intesectionX = intersectionY = double.NaN;

            var lengthX1 = line1X2 - line1X1;
            var lengthY1 = line1Y2 - line1Y1;

            var lengthX2 = line2X2 - line2X1;
            var lengthY2 = line2Y2 - line2Y1;

            if (lengthX1.AboutZero() && lengthY1.AboutZero() && lengthX2.AboutZero() && lengthY2.AboutZero())
            {
                var lineIsPoint = line1X1.AboutEquals(line2X2) && line1Y1.AboutEquals(line2Y2);

                if (lineIsPoint)
                {
                    intesectionX = line1X1;
                    intersectionY = line1Y1;
                }

                return lineIsPoint;
            }

            if (lengthX1.AboutZero() && lengthY1.AboutZero())
            {
                var line1IsPoint = PointGeo.DistanceToSegment(line1X1, line1Y1, line2X1, line2Y1, line2X2, line2Y2) < GeoPlanarNet.Epsilon;

                if (line1IsPoint)
                {
                    intesectionX = line1X1;
                    intersectionY = line1Y1;
                }

                return line1IsPoint;
            }

            if (lengthX2.AboutZero() && lengthY2.AboutZero())
            {
                var line2IsPoint = PointGeo.DistanceToSegment(line2X1, line2Y1, line1X1, line1Y1, line1X2, line1Y2) < GeoPlanarNet.Epsilon;

                if (line2IsPoint)
                {
                    intesectionX = line2X1;
                    intersectionY = line2Y1;
                }

                return line2IsPoint;
            }

            var div = lengthY2 * lengthX1 - lengthX2 * lengthY1;

            if (div.AboutZero())
            {
                return false;
            }

            var koefIv = (lengthX2 * (line1Y1 - line2Y1) - lengthY2 * (line1X1 - line2X1)) / div;
            intesectionX = line1X1 + koefIv * (line1X2 - line1X1);
            intersectionY = line1Y1 + koefIv * (line1Y2 - line1Y1);

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
        /// Get coefficients of line linear function K and B
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
        /// <returns> True, if success </returns>
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
        /// <returns> True, if success </returns>
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
        /// <returns> True, if success </returns>
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
        /// Has intersection between the line and the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool HasCircleIntersection(PointF linePoint1, PointF linePoint2, PointF circleCenter, float radius)
        {
            return FindCircleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, radius,
                                     out _, out _, out _, out _);
        }

        /// <summary>
        /// Has intersection between the line and the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool HasCircleIntersection(Point linePoint1, Point linePoint2, PointF circleCenter, float radius)
        {
            return FindCircleIntersection(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, circleCenter.X, circleCenter.Y, radius,
                                              out _, out _, out _, out _);
        }

        /// <summary>
        /// Has intersection between the line and the circle
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> True if the line and the circle has intersection </returns>
        public static bool HasCircleIntersection(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double circleCenterX, double circleCenterY, double radius)
        {
            return FindCircleIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, circleCenterX, circleCenterY, radius,
                                  out _, out _, out _, out _);
        }

        /// <summary>
        /// Find intersection between the line and the circle
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the line and the circle has intersection </returns>
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

            var lengthX = linePoint2X - linePoint1X;
            var lengthY = linePoint2Y - linePoint1Y;

            var A = lengthX * lengthX + lengthY * lengthY;
            var B = 2 * (lengthX * (linePoint1X - circleCenterX) + lengthY * (linePoint1Y - circleCenterY));
            var C = (linePoint1X - circleCenterX) * (linePoint1X - circleCenterX) + (linePoint1Y - circleCenterY) * (linePoint1Y - circleCenterY) - radius * radius;

            var determinant = B * B - 4 * A * C;

            if (A.AboutZero() || determinant < 0)
            {
                return false;
            }

            if (determinant.AboutZero())
            {
                var koef = -B / (2 * A);
                intersection1X = linePoint1X + koef * lengthX;
                intersection1Y = linePoint1Y + koef * lengthY;
            }
            else
            {
                var koef = (float)((-B + Math.Sqrt(determinant)) / (2 * A));
                intersection1X = linePoint1X + koef * lengthX;
                intersection1Y = linePoint1Y + koef * lengthY;

                koef = (float)((-B - Math.Sqrt(determinant)) / (2 * A));
                intersection2X = linePoint1X + koef * lengthX;
                intersection2Y = linePoint1Y + koef * lengthY;
            }

            return true;
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
        /// <param name="line1X1"> Line 1, point 1: coordinate X </param>
        /// <param name="line1Y1"> Line 1, point 1: coordinate Y </param>
        /// <param name="line1X2"> Line 1, point 2: coordinate X </param>
        /// <param name="line1Y2"> Line 1, point 2: coordinate Y </param>
        /// <param name="line2X1"> Line 2, point 1: coordinate X </param>
        /// <param name="line2Y1"> Line 2, point 1: coordinate Y </param>
        /// <param name="line2X2"> Line 2, point 2: coordinate X </param>
        /// <param name="line2Y2"> Line 2, point 2: coordinate Y </param>
        /// <returns> True, if lines are parallel/anti-parallel </returns>
        public static bool IsParallel(double line1X1, double line1Y1, double line1X2, double line1Y2, double line2X1, double line2Y1, double line2X2, double line2Y2)
        {
            var dx1 = line1X2 - line1X1;
            var dy1 = line1Y2 - line1Y1;
            var dx2 = line2X2 - line2X1;
            var dy2 = line2Y2 - line2Y1;
            var cosAngle = Math.Abs((dx1 * dx2 + dy1 * dy2) / Math.Sqrt((dx1 * dx1 + dy1 * dy1) * (dx2 * dx2 + dy2 * dy2)));

            return cosAngle.AboutEquals(1);
        }
    }
}
