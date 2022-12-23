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
        /// <param name="centerPoint"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <returns> Point on the circle edge </returns>
        public static PointF GetEdgePoint(PointF centerPoint, float radius, double angleRad)
        {
            GetEdgePoint(centerPoint.X, centerPoint.Y, radius, angleRad, out double x, out double y);
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="centerPoint"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <returns> Point on the circle edge </returns>
        public static Point GetEdgePoint(Point centerPoint, int radius, int angleRad)
        {
            GetEdgePoint(centerPoint.X, centerPoint.Y, radius, angleRad, out double x, out double y);
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Get the point on the circle edge on the specified angle (radians)
        /// </summary>
        /// <param name="centerPointX"> Center point: X coordinate </param>
        /// <param name="centerPointY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="angleRad"> Angle (radians) </param>
        /// <param name="edgePointX"> Point on the edge: X coordinate </param>
        /// <param name="edgePointY"> Point on the edge: Y coordinate </param>
        public static void GetEdgePoint(double centerPointX, double centerPointY, double radius, double angleRad, out double edgePointX, out double edgePointY)
        {
            edgePointX = centerPointX + radius * Math.Cos(angleRad);
            edgePointY = centerPointY + radius * Math.Sin(angleRad);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="centerPoint"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> Bounding rectangle </returns>
        public static RectangleF GetBoundingRect(PointF centerPoint, float radius)
        {
            GetBoundingRect(centerPoint.X, centerPoint.Y, radius, out double leftTopX, out double leftTopY, out double width, out double height);
            return new RectangleF((float)leftTopX, (float)leftTopY, (float)width, (float)height);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="centerPoint"> Center point </param>
        /// <param name="radius"> Radius </param>
        /// <returns> Bounding rectangle </returns>
        public static Rectangle GetBoundingRect(Point centerPoint, float radius)
        {
            GetBoundingRect(centerPoint.X, centerPoint.Y, radius, out double leftTopX, out double leftTopY, out double width, out double height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the bounding rect of the circle
        /// </summary>
        /// <param name="centerPointX"> Center point: X coordinate </param>
        /// <param name="centerPointY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <param name="leftTopX"> Rectangle left top point: X coodinate </param>
        /// <param name="leftTopY"> Rectangle left top point: Y coodinate </param>
        /// <param name="width"> Rectangle width </param>
        /// <param name="height"> Rectangle height </param>
        public static void GetBoundingRect(double centerPointX, double centerPointY, double radius, out double leftTopX, out double leftTopY, out double width, out double height)
        {
            leftTopX = centerPointX - radius;
            leftTopY = centerPointY + radius;

            width = height = radius * 2;
        }
    }
}
