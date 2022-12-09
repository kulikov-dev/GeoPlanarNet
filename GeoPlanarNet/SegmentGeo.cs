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
    }
}
