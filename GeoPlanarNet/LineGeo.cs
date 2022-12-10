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
            return HasIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out _, out _);
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
            return HasIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out _, out _);
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
        public static bool HasIntersection(PointF line1Point1, PointF line1Point2, PointF line2Point1, PointF line2Point2, out PointF intersectionPoint)
        {
            var hasIntersection = HasIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out double x, out double y);
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
        public static bool HasIntersection(Point line1Point1, Point line1Point2, Point line2Point1, Point line2Point2, out Point intersectionPoint)
        {
            var hasIntersection = HasIntersection(line1Point1.X, line1Point1.Y, line1Point2.X, line1Point2.Y, line2Point1.X, line2Point1.Y, line2Point2.X, line2Point2.Y, out double x, out double y);
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
        public static bool HasIntersection(double line1x1, double line1y1, double line1x2, double line1y2, double line2x1, double line2y1, double line2x2, double line2y2, out double intesectionX, out double intersectionY)
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
                var line1IsPoint = PointGeo.DistanceToSegment(line1x1, line1y1, line2x1, line2y1, line2x2, line2y2) < 0.0001;
                if (line1IsPoint)
                {
                    intesectionX = line1x1;
                    intersectionY = line1y1;
                }

                return line1IsPoint;
            }

            if (projectionLengthX2 == 0 && projectionLengthY2 == 0)
            {
                var line2IsPoint = PointGeo.DistanceToSegment(line2x1, line2y1, line1x1, line1y1, line1x2, line1y2) < 0.0001;
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
    }
}
