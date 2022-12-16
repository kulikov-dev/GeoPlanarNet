using System.Drawing;

namespace GeoPlanarNet
{
    public static class SegmentGeo
    {
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
            return PointGeo.Distance(segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

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
        /// <param name="segment1Start"> Start point of 1 segment </param>
        /// <param name="segment1End"> End point of 1 segment </param>
        /// <param name="segment2Start"> Start point of 2 segment </param>
        /// <param name="segment2End"> End point of 2 segment </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(PointF segment1Start, PointF segment1End, PointF segment2Start, PointF segment2End)
        {
            return AngleBetweenVectors(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y);
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
            return AngleBetweenVectors(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y);
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
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(PointF segment1Start, PointF segment1End, PointF segment2Start, PointF segment2End, out PointF intersectionPoint)
        {
            var hasIntersection = FindIntersection(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y, out double x, out double y);
            intersectionPoint = hasIntersection ? new PointF((float)x, (float)y) : PointF.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1Start"> Segment 1, point 1 </param>
        /// <param name="segment1End"> Segment 1, point 2 </param>
        /// <param name="segment2Start"> Segment 2, point 1 </param>
        /// <param name="segment2End"> Segment 2, point 2 </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(Point segment1Start, Point segment1End, Point segment2Start, Point segment2End, out Point intersectionPoint)
        {
            var hasIntersection = FindIntersection(segment1Start.X, segment1Start.Y, segment1End.X, segment1End.Y, segment2Start.X, segment2Start.Y, segment2End.X, segment2End.Y, out double x, out double y);
            intersectionPoint = hasIntersection ? new Point((int)x, (int)y) : Point.Empty;

            return hasIntersection;
        }

        /// <summary>
        /// Check if two segments have intersection
        /// </summary>
        /// <param name="segment1StartX"> Segment 1, start point: coordinate X </param>
        /// <param name="segment1StartY"> Segment 1, start point: coordinate Y </param>
        /// <param name="segment1EndX"> Segment 1, end point: coordinate X </param>
        /// <param name="segment1EndY"> Segment 1, end point: coordinate Y </param>
        /// <param name="segment2BeginX"> Segment 2, start point: coordinate X </param>
        /// <param name="segment2BeginY"> Segment 2, start point: coordinate Y </param>
        /// <param name="segment2EndX"> Segment 2, end point: coordinate X </param>
        /// <param name="segment2EndY"> Segment 2, end point: coordinate Y </param>
        /// <param name="intesectionX"> Intersection point: coordinate X; NaN if not intersects </param>
        /// <param name="intersectionY"> Intersection point: coordinate Y; NaN if not intersects </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY, double segment2BeginX, double segment2BeginY, double segment2EndX, double segment2EndY, out double intesectionX, out double intersectionY)
        {
            intesectionX = intersectionY = 0;
            var minx1 = Math.Min(segment1StartX, segment1EndX);
            var miny1 = Math.Min(segment1StartY, segment1EndY);
            var maxx1 = Math.Max(segment1StartX, segment1EndX);
            var maxy1 = Math.Max(segment1StartY, segment1EndY);
            var minx2 = Math.Min(segment2BeginX, segment2EndX);
            var miny2 = Math.Min(segment2BeginY, segment2EndY);
            var maxx2 = Math.Max(segment2BeginX, segment2EndX);
            var maxy2 = Math.Max(segment2BeginY, segment2EndY);

            if (minx1 > maxx2 + 0.0001 || maxx1 + 0.0001 < minx2 || miny1 > maxy2 + 0.0001 || maxy1 + 0.0001 < miny2)
            {
                return false;
            }

            var segment1ProjectionX = segment1EndX - segment1StartX;
            var segment1ProjectionY = segment1EndY - segment1StartY;

            var segment2ProjectionX = segment2EndX - segment2BeginX;
            var segment2ProjectionН = segment2EndY - segment2BeginY;
            var div = (segment2ProjectionН * segment1ProjectionX) - (segment2ProjectionX * segment1ProjectionY);

            if (Math.Abs(div) < 0.0001)
            {
                return false;
            }

            var segment12ProjectionX = segment1StartX - segment2BeginX;
            var segment12ProjectionY = segment1StartY - segment2BeginY;
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

            intesectionX = segment1StartX + (koef * (segment1EndX - segment1StartX));
            intersectionY = segment1StartY + (koef * (segment1EndY - segment1StartY));

            return true;
        }

        /// <summary>
        /// Get a point away from a segment start point on a specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from start point to a new point </param>
        /// <returns> New point awaw from a segment start </returns>
        public static PointF GetPointAwayFromStart(PointF segmentStart, PointF segmentEnd, double distance)
        {
            GetPointAwayFromStart(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out double newPointX, out double newPointY);
            return new PointF((float)newPointX, (float)newPointY);
        }

        /// <summary>
        /// Get a point away from a segment start point on a specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from start point to a new point </param>
        /// <returns> New point awaw from a segment start </returns>
        public static Point GetPointAwayFromStart(Point segmentStart, Point segmentEnd, int distance)
        {
            GetPointAwayFromStart(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out double newPointX, out double newPointY);
            return new Point((int)newPointX, (int)newPointY);
        }

        /// <summary>
        /// Get a point away from a segment start point on a specified distance
        /// </summary>
        /// <param name="segment1StartX"> Segment, start point: coordinate X </param>
        /// <param name="segment1StartY"> Segment, start point: coordinate Y </param>
        /// <param name="segment1EndX"> Segment, end point: coordinate X </param>
        /// <param name="segment1EndY"> Segment, end point: coordinate Y </param>
        /// <param name="distance"> Distance from start point to a new point </param>
        /// <param name="newPointX"> New point: coordinate X </param>
        /// <param name="newPointY"> New point: coordinate Y </param>
        public static void GetPointAwayFromStart(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY, double distance, out double newPointX, out double newPointY)
        {
            if (distance == 0)
            {
                newPointX = segment1StartX;
                newPointY = segment1StartY;
                return;
            }

            var segmentLength = PointGeo.Distance(segment1StartX, segment1StartY, segment1EndX, segment1EndY);
            if (Math.Abs(segmentLength) < 0.0001)
            {
                newPointX = segment1StartX;
                newPointY = segment1StartY;
                return;
            }

            var koef = distance / segmentLength;
            var x = segment1StartX + (koef * (segment1EndX - segment1StartX));
            var y = segment1StartY + (koef * (segment1EndY - segment1StartY));

            newPointX = x;
            newPointY = y;
        }

        /// <summary>
        /// Get a point away from a segment end point on a specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from end point to a new point </param>
        /// <returns> New point awaw from a segment end </returns>
        public static PointF GetPointAwayFromEnd(PointF segmentStart, PointF segmentEnd, double distance)
        {
            GetPointAwayFromEnd(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out double newPointX, out double newPointY);
            return new PointF((float)newPointX, (float)newPointY);
        }

        /// <summary>
        /// Get a point away from a segment end point on a specified distance
        /// </summary>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <param name="distance"> Distance from end point to a new point </param>
        /// <returns> New point awaw from a segment end </returns>
        public static Point GetPointAwayFromEnd(Point segmentStart, Point segmentEnd, int distance)
        {
            GetPointAwayFromEnd(segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y, distance, out double newPointX, out double newPointY);
            return new Point((int)newPointX, (int)newPointY);
        }

        /// <summary>
        /// Get a point away from a segment end point on a specified distance
        /// </summary>
        /// <param name="segment1StartX"> Segment, start point: coordinate X </param>
        /// <param name="segment1StartY"> Segment, start point: coordinate Y </param>
        /// <param name="segment1EndX"> Segment, end point: coordinate X </param>
        /// <param name="segment1EndY"> Segment, end point: coordinate Y </param>
        /// <param name="distance"> Distance from end point to a new point </param>
        /// <param name="newPointX"> New point: coordinate X </param>
        /// <param name="newPointY"> New point: coordinate Y </param>
        public static void GetPointAwayFromEnd(double segment1StartX, double segment1StartY, double segment1EndX, double segment1EndY, double distance, out double newPointX, out double newPointY)
        {
            if (distance == 0)
            {
                newPointX = segment1StartX;
                newPointY = segment1StartY;
                return;
            }

            var segmentLength = PointGeo.Distance(segment1StartX, segment1StartY, segment1EndX, segment1EndY);
            if (Math.Abs(segmentLength) < 0.0001)
            {
                newPointX = segment1StartX;
                newPointY = segment1StartY;
                return;
            }

            var koef = (distance + segmentLength) / segmentLength;
            var x = segment1StartX + (koef * (segment1EndX - segment1StartX));
            var y = segment1StartY + (koef * (segment1EndY - segment1StartY));

            newPointX = x;
            newPointY = y;
        }
    }
}
