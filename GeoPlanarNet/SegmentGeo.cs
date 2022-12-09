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
        public static double GetAngleRadians(PointF pointStart, PointF pointEnd)
        {
            return GetAngleRadians(pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);
        }

        /// <summary>
        /// Get a segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="pointStart"> Segment start point </param>
        /// <param name="pointEnd"> Segment end point </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(Point pointStart, PointF pointEnd)
        {
            return GetAngleRadians(pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);
        }

        /// <summary>
        /// Get a segment tilt angle relative to the X axis
        /// </summary>
        /// <param name="pointStartX"> Start point: X coordinate </param>
        /// <param name="pointStartY"> Start point: Y coordinate </param>
        /// <param name="pointEndX"> End point: X coordinate </param>
        /// <param name="pointEndY"> End point: Y coordinate </param>
        /// <returns> Angle (radians) </returns>
        public static double GetAngleRadians(double pointStartX, double pointStartY, double pointEndX, double pointEndY)
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
    }
}
