using System.Drawing;

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
            var hasIntersection = FindIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out double x, out double y);
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
            var hasIntersection = FindIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out double x, out double y);
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

            if (projectionLengthX1 == 0 && projectionLengthY1 == 0 && projectionLengthX2 == 0 && projectionLengthY2 == 0)
            {
                var lineIsPoint = line1x1 == line2x2 && line1y1 == line2y2;

                if (lineIsPoint)
                {
                    intesectionX = line1x1;
                    intersectionY = line1y1;
                }

                return lineIsPoint;
            }

            if (projectionLengthX1 == 0 && projectionLengthY1 == 0)
            {
                var line1IsPoint = PointGeo.DistanceToSegment(line1x1, line1y1, line2x1, line2y1, line2x2, line2y2) < GeoPlanarNet.Epsilon;

                if (line1IsPoint)
                {
                    intesectionX = line1x1;
                    intersectionY = line1y1;
                }

                return line1IsPoint;
            }

            if (projectionLengthX2 == 0 && projectionLengthY2 == 0)
            {
                var line2IsPoint = PointGeo.DistanceToSegment(line2x1, line2y1, line1x1, line1y1, line1x2, line1y2) < GeoPlanarNet.Epsilon;

                if (line2IsPoint)
                {
                    intesectionX = line2x1;
                    intersectionY = line2y1;
                }

                return line2IsPoint;
            }

            var div = (projectionLengthY2 * projectionLengthX1) - (projectionLengthX2 * projectionLengthY1);

            if (div == 0)
            {
                return false;
            }

            var koefIv = ((projectionLengthX2 * (line1y1 - line2y1)) - (projectionLengthY2 * (line1x1 - line2x1))) / div;
            intesectionX = line1x1 + (koefIv * (line1x2 - line1x1));
            intersectionY = line1y1 + (koefIv * (line1y2 - line1y1));

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
                                     out double _, out double _, out double _, out double _);
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
                                              out double _, out double _, out double _, out double _);
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
                                              out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y);

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
                                              out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y);

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
            intersection1X = intersection1Y = intersection2X = intersection2Y = double.NaN;
            double tempX, tempY;

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY, out tempX, out tempY))
            {
                intersection1X = tempX;
                intersection1Y = tempY;
            }

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectLeftTopX, rectRightBottomY, rectRightBottomX, rectRightBottomY, out tempX, out tempY))
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

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectRightBottomX, rectRightBottomY, rectRightBottomX, rectLeftTopY, out tempX, out tempY))
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

            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, rectRightBottomX, rectLeftTopY, rectLeftTopX, rectLeftTopY, out tempX, out tempY))
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
        /// Get koefficients of line linear function K and B
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yIntersection"> Y value if x = 0 </param>
        internal static void FindSlopeKoef(PointF linePoint1, PointF linePoint2, out float slopeKoef, out float yIntersection)
        {
            FindSlopeKoef(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out double slopeKoefD, out double yIntersectionD);

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
            yIntersection = double.IsInfinity(slopeKoef) ? linePoint2X : linePoint2Y - (linePoint2X * slopeKoef);
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


            if (SegmentGeo.FindIntersection(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, xBoundsMin, Math.Min(linePoint1Y, linePoint2Y) - 1, xBoundsMin, Math.Max(linePoint1Y, linePoint2Y) + 1, out double x, out double y))
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
        /// Find the point on the line closest to the given one
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="point"> Given point </param>
        /// <returns> Closest point on the line </returns>
        public static PointF FindClosestPoint(PointF linePoint1, PointF linePoint2, PointF point)
        {
            FindClosestPoint(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, point.X, point.Y, out double x, out double y);
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Find the point on the line closest to the given one
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="point"> Given point </param>
        /// <returns> Closest point on the line </returns>
        public static Point FindClosestPoint(Point linePoint1, Point linePoint2, Point point)
        {
            FindClosestPoint(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, point.X, point.Y, out double x, out double y);
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Find the point on the line closest to the given one
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="pointX"> Given point: X </param>
        /// <param name="pointY"> Given point: Y </param>
        /// <param name="closestPointX"> Closest point on the line: X </param>
        /// <param name="closestPointY"> Closest point on the line: Y </param>
        public static void FindClosestPoint(double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, double pointX, double pointY, out double closestPointX, out double closestPointY)
        {
            var projectionLineX = linePoint2X - linePoint1X;
            var projectionLineY = linePoint2Y - linePoint1Y;
            var toPointX = pointX - linePoint1X;
            var toPointY = pointY - linePoint1Y;
            var koefC1 = (projectionLineX * toPointX) + (projectionLineY * toPointY);
            var koefC2 = (projectionLineX * projectionLineX) + (projectionLineY * projectionLineY);
            var ratio = koefC1 / koefC2;

            closestPointX = linePoint1X + (ratio * projectionLineX);
            closestPointY = linePoint1Y + (ratio * projectionLineY);
        }
    }
}
