using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class to process operations with points
    /// </summary>
    public static class PointGeo
    {
        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static float Distance(PointF point1, PointF point2)
        {
            return Distance(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static float DistanceTo(this PointF point1, PointF point2)
        {
            return Distance(point1, point2);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double Distance(Point point1, Point point2)
        {
            return Distance(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceTo(this Point point1, Point point2)
        {
            return Distance(point1, point2);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static float Distance(float point1X, float point1Y, float point2X, float point2Y)
        {
            return (float)Math.Sqrt(Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2));
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static double Distance(double point1X, double point1Y, double point2X, double point2Y)
        {
            return Math.Sqrt(Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2));
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static double Distance(int point1X, int point1Y, int point2X, int point2Y)
        {
            return Math.Sqrt(Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2));
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static PointF Rotate(PointF point, PointF center, double angleRadian)
        {
            return Rotate(point.X, point.Y, center.X, center.Y, angleRadian);
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static PointF RotateAround(this PointF point, PointF center, double angleRadian)
        {
            return Rotate(point, center, angleRadian);
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static Point Rotate(Point point, Point center, double angleRadian)
        {
            return Rotate(point.X, point.Y, center.X, center.Y, angleRadian);
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static Point RotateAround(this Point point, Point center, double angleRadian)
        {
            return Rotate(point, center, angleRadian);
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="pointX">Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="centerX"> Center point: X coordinate </param>
        /// <param name="centerY"> Center point: Y coordinate </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static PointF Rotate(float pointX, float pointY, float centerX, float centerY, double angleRadian)
        {
            var diff = new PointF(pointX - centerX, pointY - centerY);

            return new PointF((float)(centerX + (diff.X * Math.Cos(angleRadian)) - (diff.Y * Math.Sin(angleRadian))), (float)(centerY + (diff.X * Math.Sin(angleRadian)) + (diff.Y * Math.Cos(angleRadian))));
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="pointX">Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="centerX"> Center point: X coordinate </param>
        /// <param name="centerY"> Center point: Y coordinate </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static Point Rotate(int pointX, int pointY, int centerX, int centerY, double angleRadian)
        {
            var diff = new Point(pointX - centerX, pointY - centerY);

            return new Point((int)(centerX + (diff.X * Math.Cos(angleRadian)) - (diff.Y * Math.Sin(angleRadian))), (int)(centerY + (diff.X * Math.Sin(angleRadian)) + (diff.Y * Math.Cos(angleRadian))));
        }
    }
}
