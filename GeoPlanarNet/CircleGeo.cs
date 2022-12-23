using System.Drawing;

namespace GeoPlanarNet
{
    public static class CircleGeo
    {
        /// <summary>
        /// Get the circle area
        /// </summary>
        /// <param name="radius"> Radius </param>
        /// <returns> Area </returns>
        public static double Area(double radius)
        {
            return radius * radius * Math.PI;
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="pointCenter"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <returns> Point on the circle edge </returns>
        public static PointF GetEdgePoint(PointF pointCenter, double radius, double angleRad)
        {
            GetEdgePoint(pointCenter.X, pointCenter.Y, radius, angleRad, out double x, out double y);
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="pointCenterX"> Center point: X coordinate </param>
        /// <param name="pointCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <param name="edgePointX"> Point on the edge: X coordinate </param>
        /// <param name="edgePointY"> Point on the edge: Y coordinate </param>
        public static void GetEdgePoint(double pointCenterX, double pointCenterY, double radius, double angleRad, out double edgePointX, out double edgePointY)
        {
            edgePointX = pointCenterX + radius * Math.Cos(angleRad);
            edgePointY = pointCenterY + radius * Math.Sin(angleRad);
        }
    }
}
