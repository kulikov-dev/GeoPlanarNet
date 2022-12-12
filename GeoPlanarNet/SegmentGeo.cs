using System.Drawing;

namespace GeoPlanarNet
{
    public static class SegmentGeo
    {
        /// <summary>
        /// Get a segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="pointStart"> Segment start point </param>
        /// <param name="pointEnd"> Segment end point </param>
        /// <returns> Angle (radians) </returns>
        public static double GetXAngleRadians(this PointF pointStart, PointF pointEnd)
        {
            return GetXAngleRadians(pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);
        }

        /// <summary>
        /// Get a segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="pointStart"> Segment start point </param>
        /// <param name="pointEnd"> Segment end point </param>
        /// <returns> Angle (radians) </returns>
        public static double GetXAngleRadians(this Point pointStart, PointF pointEnd)
        {
            return GetXAngleRadians(pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);
        }

        /// <summary>
        /// Get a segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="pointStartX"> Start point: X coordinate </param>
        /// <param name="pointStartY"> Start point: Y coordinate </param>
        /// <param name="pointEndX"> End point: X coordinate </param>
        /// <param name="pointEndY"> End point: Y coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double GetXAngleRadians(double pointStartX, double pointStartY, double pointEndX, double pointEndY)
        {
            var diffX = pointEndX - pointStartX;
            var diffY = pointEndY - pointStartY;

            if (diffX == 0)
            {
                return diffY > 0 ? Math.PI / 2 : 3 * Math.PI / 2;
            }

            var angle = Math.Atan2(diffY, diffX);

            return angle < 0 ? angle + (2 * Math.PI) : angle;
        }

        /// <summary>
        /// Get angle in radians between two segments with a common point: (commonPoint, startPoint1) and (commonPoint, startPoint2)
        /// </summary>
        /// <param name="commonPoint"> Common point </param>
        /// <param name="startPoint1"> Start point of a segment 1 </param>
        /// <param name="startPoint2"> Start point of a segment 2 </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(PointF commonPoint, PointF startPoint1, PointF startPoint2)
        {
            return GetAngleRadians(commonPoint.X, commonPoint.Y, startPoint1.X, startPoint1.Y, startPoint2.X, startPoint2.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments with a common point: (commonPoint, startPoint1) and (commonPoint, startPoint2)
        /// </summary>
        /// <param name="commonPoint"> Common point </param>
        /// <param name="startPoint1"> Start point of a segment 1 </param>
        /// <param name="startPoint2"> Start point of a segment 2 </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(Point commonPoint, Point startPoint1, Point startPoint2)
        {
            return GetAngleRadians(commonPoint.X, commonPoint.Y, startPoint1.X, startPoint1.Y, startPoint2.X, startPoint2.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments with a common point: (commonPoint, startPoint1) and (commonPoint, startPoint2)
        /// </summary>
        /// <param name="commonPointX"> Common point: X coordinate </param>
        /// <param name="commonPointY"> Common point: Y coordinate </param>
        /// <param name="startPoint1X"> Start point of 1 segment: X coordinate </param>
        /// <param name="startPoint1Y"> Start point of 1 segment: Y coordinate </param>
        /// <param name="startPoint2X"> Start point of 2 segment: X coordinate </param>
        /// <param name="startPoint2Y"> Start point of 2 segment: Y coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(double commonPointX, double commonPointY, double startPoint1X, double startPoint1Y, double startPoint2X, double startPoint2Y)
        {
            var numerator = ((startPoint1X - commonPointX) * (startPoint2X - commonPointX)) + ((startPoint1Y - commonPointY) * (startPoint2Y - commonPointY));
            var denominator = Math.Sqrt(Math.Pow(startPoint1X - commonPointX, 2) + Math.Pow(startPoint1Y - commonPointY, 2)) * Math.Sqrt(Math.Pow(startPoint2X - commonPointX, 2) + Math.Pow(startPoint2Y - commonPointY, 2));

            return Math.Acos(numerator / denominator);
        }

        /// <summary>
        /// Get angle in radians between two segments
        /// </summary>
        /// <param name="startPoint1"> Start point of 1 segment </param>
        /// <param name="endPoint1"> End point of 1 segment </param>
        /// <param name="startPoint2"> Start point of 2 segment </param>
        /// <param name="endPoint2"> End point of 2 segment </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(PointF startPoint1, PointF endPoint1, PointF startPoint2, PointF endPoint2)
        {
            return AngleBetweenVectors(startPoint1.X, startPoint1.Y, endPoint1.X, endPoint1.Y, startPoint2.X, startPoint2.Y, endPoint2.X, endPoint2.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments
        /// </summary>
        /// <param name="startPoint1"> Start point of 1 segment </param>
        /// <param name="endPoint1"> End point of 1 segment </param>
        /// <param name="startPoint2"> Start point of 2 segment </param>
        /// <param name="endPoint2"> End point of 2 segment </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(Point startPoint1, Point endPoint1, Point startPoint2, Point endPoint2)
        {
            return AngleBetweenVectors(startPoint1.X, startPoint1.Y, endPoint1.X, endPoint1.Y, startPoint2.X, startPoint2.Y, endPoint2.X, endPoint2.Y);
        }

        /// <summary>
        /// Get angle in radians between two segments
        /// </summary>
        /// <param name="startPoint1X"> Start point of 1 segment: X coordinate </param>
        /// <param name="startPoint1Y"> Start point of 1 segment: X coordinate </param>
        /// <param name="endPoint1X"> Start point of 1 segment: X coordinate </param>
        /// <param name="endPoint1Y"> Start point of 1 segment: X coordinate </param>
        /// <param name="startPoint2X"> Start point of 1 segment: X coordinate </param>
        /// <param name="startPoint2Y"> Start point of 1 segment: X coordinate </param>
        /// <param name="endPoint2X"> Start point of 1 segment: X coordinate </param>
        /// <param name="endPoint2Y"> Start point of 1 segment: X coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double AngleBetweenVectors(double startPoint1X, double startPoint1Y, double endPoint1X, double endPoint1Y,
                                                 double startPoint2X, double startPoint2Y, double endPoint2X, double endPoint2Y)
        {
            var diff1X = endPoint1X - startPoint1X;
            var diff1Y = endPoint1Y - startPoint1Y;
            var diff2X = endPoint2X - startPoint2X;
            var diff2Y = endPoint2Y - startPoint2Y;

            var angle = ((diff1X * diff2X) + (diff1Y * diff2Y)) / (Math.Sqrt((diff1X * diff1X) + (diff1Y * diff1Y)) * Math.Sqrt((diff2X * diff2X) + (diff2Y * diff2Y)));

            return Math.Acos(Math.Round(angle, 3));
        }


        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Point1"> Segment 1, point 1 </param>
        /// <param name="segment1Point2"> Segment 1, point 2 </param>
        /// <param name="segment2Point1"> Segment 2, point 1 </param>
        /// <param name="segment2Point2"> Segment 2, point 2 </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(PointF segment1Point1, PointF segment1Point2, PointF segment2Point1, PointF segment2Point2)
        {
            return HasIntersection(segment1Point1.X, segment1Point1.Y, segment1Point2.X, segment1Point2.Y, segment2Point1.X, segment2Point1.Y, segment2Point2.X, segment2Point2.Y, out _, out _);
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Point1"> Segment 1, point 1 </param>
        /// <param name="segment1Point2"> Segment 1, point 2 </param>
        /// <param name="segment2Point1"> Segment 2, point 1 </param>
        /// <param name="segment2Point2"> Segment 2, point 2 </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(Point segment1Point1, Point segment1Point2, Point segment2Point1, Point segment2Point2)
        {
            return HasIntersection(segment1Point1.X, segment1Point1.Y, segment1Point2.X, segment1Point2.Y, segment2Point1.X, segment2Point1.Y, segment2Point2.X, segment2Point2.Y, out _, out _);
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Point1"> Segment 1, point 1 </param>
        /// <param name="segment1Point2"> Segment 1, point 2 </param>
        /// <param name="segment2Point1"> Segment 2, point 1 </param>
        /// <param name="segment2Point2"> Segment 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(PointF segment1Point1, PointF segment1Point2, PointF segment2Point1, PointF segment2Point2, out PointF intersectionPoint)
        {
            var hasIntersection = HasIntersection(segment1Point1.X, segment1Point1.Y, segment1Point2.X, segment1Point2.Y, segment2Point1.X, segment2Point1.Y, segment2Point2.X, segment2Point2.Y, out double x, out double y);
            intersectionPoint = hasIntersection ? new PointF((float)x, (float)y) : PointF.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Point1"> Segment 1, point 1 </param>
        /// <param name="segment1Point2"> Segment 1, point 2 </param>
        /// <param name="segment2Point1"> Segment 2, point 1 </param>
        /// <param name="segment2Point2"> Segment 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(Point segment1Point1, Point segment1Point2, Point segment2Point1, Point segment2Point2, out Point intersectionPoint)
        {
            var hasIntersection = HasIntersection(segment1Point1.X, segment1Point1.Y, segment1Point2.X, segment1Point2.Y, segment2Point1.X, segment2Point1.Y, segment2Point2.X, segment2Point2.Y, out double x, out double y);
            intersectionPoint = hasIntersection ? new Point((int)x, (int)y) : Point.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1x1"> segment 1, point 1: coordinate X </param>
        /// <param name="segment1y1"> segment 1, point 1: coordinate Y </param>
        /// <param name="segment1x2"> segment 1, point 2: coordinate X </param>
        /// <param name="segment1y2"> segment 1, point 2: coordinate Y </param>
        /// <param name="segment2x1"> segment 2, point 1: coordinate X </param>
        /// <param name="segment2y1"> segment 2, point 1: coordinate Y </param>
        /// <param name="segment2x2"> segment 2, point 2: coordinate X </param>
        /// <param name="segment2y2"> segment 2, point 2: coordinate Y </param>
        /// <param name="intesectionX"> Intersection point: coordinate X; NaN if not intersects </param>
        /// <param name="intersectionY"> Intersection point: coordinate Y; NaN if not intersects </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(double segment1x1, double segment1y1, double segment1x2, double segment1y2, double segment2x1, double segment2y1, double segment2x2, double segment2y2, out double intesectionX, out double intersectionY)
        {
            intesectionX = intersectionY = 0;
            var minx1 = Math.Min(segment1x1, segment1x2);
            var miny1 = Math.Min(segment1y1, segment1y2);
            var maxx1 = Math.Max(segment1x1, segment1x2);
            var maxy1 = Math.Max(segment1y1, segment1y2);
            var minx2 = Math.Min(segment2x1, segment2x2);
            var miny2 = Math.Min(segment2y1, segment2y2);
            var maxx2 = Math.Max(segment2x1, segment2x2);
            var maxy2 = Math.Max(segment2y1, segment2y2);

            if (minx1 > maxx2 + 0.0001 || maxx1 + 0.0001 < minx2 || miny1 > maxy2 + 0.0001 || maxy1 + 0.0001 < miny2)
            {
                return false;
            }

            // Длина проекций первой линии на ось x и y
            var segment1ProjectionX = segment1x2 - segment1x1;
            var segment1ProjectionY = segment1y2 - segment1y1;

            // Длина проекций второй линии на ось x и y
            var segment2ProjectionX = segment2x2 - segment2x1;
            var segment2ProjectionН = segment2y2 - segment2y1;
            var div = (segment2ProjectionН * segment1ProjectionX) - (segment2ProjectionX * segment1ProjectionY);

            if (Math.Abs(div) < 0.0001)
            {
                return false;
            }

            var segment12ProjectionX = segment1x1 - segment2x1;
            var segment12ProjectionY = segment1y1 - segment2y1;
            var koef = ((segment1ProjectionX * segment12ProjectionY) - (segment1ProjectionY * segment12ProjectionX)) / div;

            if (koef < -0.0001 || koef > 1 + 0.0001)
            {
                return false;
            }

            koef = ((segment2ProjectionX * segment12ProjectionY) - (segment2ProjectionН * segment12ProjectionX)) / div;

            if (koef < -0.0001 || koef > 1 + 0.0001)
            {
                return false;
            }

            intesectionX = segment1x1 + (koef * (segment1x2 - segment1x1));
            intersectionY = segment1y1 + (koef * (segment1y2 - segment1y1));

            return true;
        }
    }
}
