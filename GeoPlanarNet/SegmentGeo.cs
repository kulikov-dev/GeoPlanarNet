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
        /// Get angle in radians between two segments: (commonPoint, startPoint1) and (commonPoint, startPoint2)
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
        /// Get angle in radians between two segments: (commonPoint, startPoint1) and (commonPoint, startPoint2)
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
        /// Get angle in radians between two segments: (commonPoint, startPoint1) and (commonPoint, startPoint2)
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
    }
}
