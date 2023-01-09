using System.Collections.Generic;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the curved line (line with sections)
    /// </summary>
    public class CurveLineGeo
    {
        /// <summary>
        /// Get curve length
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <returns> Length </returns>
        public static double Length(IList<PointF> curve)
        {
            var length = 0d;

            for (var i = 0; i < curve.Count - 1; ++i)
            {
                length += curve[i].DistanceTo(curve[i + 1]);
            }

            return length;
        }

        /// <summary>
        /// Get curve length
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <returns> Length </returns>
        public static double Length(IList<Point> curve)
        {
            var length = 0d;

            for (var i = 0; i < curve.Count - 1; ++i)
            {
                length += curve[i].DistanceTo(curve[i + 1]);
            }

            return length;
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(PointF[] curve, PointF point)
        {
            return MinDistanceToPoint(curve, point, out _);
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <param name="nearestPointIndex"> Index of the nearest point in the curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(PointF[] curve, PointF point, out int nearestPointIndex)
        {
            var resultLength = double.MaxValue;
            nearestPointIndex = -1;

            if (curve.Length == 1)
            {
                resultLength = PointGeo.DistanceTo(point.X, point.Y, curve[0].X, curve[0].Y);
            }

            for (var i = 0; i < curve.Length - 1; i++)
            {
                var currentLength = PointGeo.DistanceToSegment(point.X, point.Y, curve[i].X, curve[i].Y, curve[i + 1].X, curve[i + 1].Y);

                if (currentLength < resultLength)
                {
                    resultLength = currentLength;
                    nearestPointIndex = i;
                }
            }

            return resultLength;
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(Point[] curve, Point point)
        {
            return MinDistanceToPoint(curve, point, out _);
        }

        /// <summary>
        /// Find the minimal distance from the curve to the point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <param name="nearestPointIndex"> Index of the nearest point in the curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(Point[] curve, Point point, out int nearestPointIndex)
        {
            var resultLength = double.MaxValue;
            nearestPointIndex = -1;

            if (curve.Length == 1)
            {
                resultLength = PointGeo.DistanceTo(point.X, point.Y, curve[0].X, curve[0].Y);
            }

            for (var i = 0; i < curve.Length - 1; i++)
            {
                var currentLength = PointGeo.DistanceToSegment(point.X, point.Y, curve[i].X, curve[i].Y, curve[i + 1].X, curve[i + 1].Y);

                if (currentLength < resultLength)
                {
                    resultLength = currentLength;
                    nearestPointIndex = i;
                }
            }

            return resultLength;
        }

        /// <summary>
        /// Split the curve line to small parts by the segments length
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="partsLength"> Length of each part of the curve line </param>
        /// <returns> Curve with segments of the parts length </returns>
        public static PointF[] Split(PointF[] curve, double partsLength)
        {
            var result = new List<PointF>();

            if (curve.Length <= 1)
            {
                return curve;
            }

            for (var i = 0; i < curve.Length - 1; i++)
            {
                result.AddRange(SegmentGeo.Split(curve[i], curve[i + 1], partsLength));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Split the curve line to small parts by the segments length
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="partsLength"> Length of each part of the curve line </param>
        /// <returns> Curve with segments of the parts length </returns>
        public static Point[] Split(Point[] curve, int partsLength)
        {
            var result = new List<Point>();

            if (curve.Length <= 1)
            {
                return curve;
            }

            for (var i = 0; i < curve.Length - 1; i++)
            {
                result.AddRange(SegmentGeo.Split(curve[i], curve[i + 1], partsLength));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Check if the curve line and the segment has intersection
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(PointF[] curve, PointF segmentStartPoint, PointF segmentEndPoint)
        {
            return FindIntersection(curve, segmentStartPoint, segmentEndPoint, out _);
        }

        /// <summary>
        /// Check if the curve line and the segment has intersection
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool HasIntersection(Point[] curve, Point segmentStartPoint, Point segmentEndPoint)
        {
            return FindIntersection(curve, segmentStartPoint, segmentEndPoint, out _);
        }

        /// <summary>
        /// Check if the curve line and the segment has intersection
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(PointF[] curve, PointF segmentStartPoint, PointF segmentEndPoint, out PointF intersectionPoint)
        {
            intersectionPoint = PointF.Empty;

            for (var i = 0; i < curve.Length - 1; i++)
            {
                if (SegmentGeo.FindIntersection(segmentStartPoint, segmentEndPoint, curve[i], curve[i + 1], out intersectionPoint))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if the curve line and the segment has intersection
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <param name="intersectionPoint"> Intersection point </param>
        /// <returns> True, if segments have intersection </returns>
        public static bool FindIntersection(Point[] curve, Point segmentStartPoint, Point segmentEndPoint, out Point intersectionPoint)
        {
            intersectionPoint = Point.Empty;

            for (var i = 0; i < curve.Length - 1; i++)
            {
                if (SegmentGeo.FindIntersection(segmentStartPoint, segmentEndPoint, curve[i], curve[i + 1], out intersectionPoint))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
