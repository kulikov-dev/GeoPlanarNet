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
        public static double Distance(this PointF point1, PointF point2)
        {
            return Distance(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double Distance(this Point point1, Point point2)
        {
            return Distance(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static double Distance(float point1X, float point1Y, float point2X, float point2Y)
        {
            return Distance((double)point1X, point1Y, point2X, point2Y);
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
        /// Get distance to segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToSegment(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return DistanceToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get distance to segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToSegment(this Point point, Point segmentStart, Point segmentEnd)
        {
            return DistanceToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get distance to segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coodinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Distance from point to segment </returns>
        public static double DistanceToSegment(float pointX, float pointY, float segmentStartX, float segmentStartY, float segmentEndX, float segmentEndY)
        {
            return DistanceToSegment((double)pointX, pointY, segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

        /// <summary>
        /// Get distance to a segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coodinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Distance from a point to the segment </returns>
        public static double DistanceToSegment(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            var diffSegmentX = segmentEndX - segmentStartX;
            var diffSegmentY = segmentEndY - segmentStartY;
            var diffPointSegmentStartX = pointX - segmentStartX;
            var diffPointSegmentStartY = pointY - segmentStartY;
            var koef = ((diffSegmentX * diffPointSegmentStartX) + (diffSegmentY * diffPointSegmentStartY)) / ((diffSegmentX * diffSegmentX) + (diffSegmentY * diffSegmentY));
            var koefX = segmentStartX + (diffSegmentX * koef);
            var koefY = segmentStartY + (diffSegmentY * koef);

            if (Utils.CheckDotBetweenInterval(koefX, segmentStartX, segmentEndX) && Utils.CheckDotBetweenInterval(koefY, segmentStartY, segmentEndY))
            {
                return Math.Sqrt(Math.Pow(pointX - koefX, 2) + Math.Pow(pointY - koefY, 2));
            }

            var diffPointSegmentEndX = pointX - segmentEndX;
            var diffPointSegmentEndY = pointY - segmentEndY;

            return Math.Min(
                            Math.Sqrt(Math.Pow(diffPointSegmentStartX, 2) + Math.Pow(diffPointSegmentStartY, 2)),
                            Math.Sqrt(Math.Pow(diffPointSegmentEndX, 2) + Math.Pow(diffPointSegmentEndY, 2)));
        }

        /// <summary>
        /// Get distance to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line first point </param>
        /// <param name="linePoint2"> Line second point </param>
        /// <returns> Distance from a point to the line </returns>
        public static double DistanceToLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            return DistanceToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Get distance to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line first point </param>
        /// <param name="linePoint2"> Line second point </param>
        /// <returns> Distance from a point to the line </returns>
        public static double DistanceToLine(this Point point, Point linePoint1, Point linePoint2)
        {
            return DistanceToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Get distance to a line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X">Line first point: X coordinate</param>
        /// <param name="linePoint1Y">Line first point: X coordinate</param>
        /// <param name="linePoint2X">Line second point: X coordinate</param>
        /// <param name="linePoint2Y">Line second point: X coordinate</param>
        /// <returns> Distance from a point to the line </returns>
        public static double DistanceToLine(float pointX, float pointY, float linePoint1X, float linePoint1Y, float linePoint2X, float linePoint2Y)
        {
            return DistanceToLine((double)pointX, pointY, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y);
        }

        /// <summary>
        /// Get distance to a line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X">Line first point: X coordinate</param>
        /// <param name="linePoint1Y">Line first point: X coordinate</param>
        /// <param name="linePoint2X">Line second point: X coordinate</param>
        /// <param name="linePoint2Y">Line second point: X coordinate</param>
        /// <returns> Distance from a point to the line </returns>
        public static double DistanceToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            var koef = (((linePoint2X - linePoint1X) * (pointX - linePoint1X)) + ((linePoint2Y - linePoint1Y) * (pointY - linePoint1Y))) / (Math.Pow(linePoint2X - linePoint1X, 2) + Math.Pow(linePoint2Y - linePoint1Y, 2));
            var koefX = linePoint1X + ((linePoint2X - linePoint1X) * koef);
            var koefY = linePoint1Y + ((linePoint2Y - linePoint1Y) * koef);

            return Math.Sqrt(Math.Pow(pointX - koefX, 2) + Math.Pow(pointY - koefY, 2));
        }

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static PointF Rotate(this PointF point, PointF center, double angleRadian)
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
        public static Point Rotate(this Point point, Point center, double angleRadian)
        {
            return Rotate(point.X, point.Y, center.X, center.Y, angleRadian);
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
