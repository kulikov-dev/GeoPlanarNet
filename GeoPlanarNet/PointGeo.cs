using GeoPlanarNet.Enums;
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
        public static double Distance(double point1X, double point1Y, double point2X, double point2Y)
        {
            return Math.Sqrt(Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2));
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
        public static double DistanceToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            var koef = (((linePoint2X - linePoint1X) * (pointX - linePoint1X)) + ((linePoint2Y - linePoint1Y) * (pointY - linePoint1Y))) / (Math.Pow(linePoint2X - linePoint1X, 2) + Math.Pow(linePoint2Y - linePoint1Y, 2));
            var koefX = linePoint1X + ((linePoint2X - linePoint1X) * koef);
            var koefY = linePoint1Y + ((linePoint2Y - linePoint1Y) * koef);

            return Math.Sqrt(Math.Pow(pointX - koefX, 2) + Math.Pow(pointY - koefY, 2));
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

        /// <summary>
        /// Check if a point belongs to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Flag if the point belongs to the segment </returns>
        public static bool InSegment(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return InSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Check if a point belongs to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Flag if the point belongs to the segment </returns>
        public static bool InSegment(this Point point, Point segmentStart, Point segmentEnd)
        {
            return InSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Check if a point belongs to a segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coodinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Flag if the point belongs to the segment </returns>
        public static bool InSegment(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return Distance(segmentStartX, segmentStartY, pointX, pointY) + Distance(segmentEndX, segmentEndY, pointX, pointY) == Distance(segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

        /// <summary>
        /// Check if a point belongs to a circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Flag if the point belongs to the cirle </returns>
        public static bool InCircle(this PointF point, PointF circleCenter, float radius)
        {
            return InCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius);
        }

        /// <summary>
        /// Check if a point belongs to a circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Flag if the point belongs to the cirle </returns>
        public static bool InCircle(this Point point, Point circleCenter, double radius)
        {
            return InCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius);

        }

        /// <summary>
        /// Check if a point belongs to a circle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleX"> Circle center: X coordinate </param>
        /// <param name="circleY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Flag if the point belongs to the cirle </returns>
        public static bool InCircle(double pointX, double pointY, double circleX, double circleY, double radius)
        {
            return Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) <= Math.Pow(radius, 2);
        }

        /// <summary>
        /// Check if a point belongs to an ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Flag if the point belongs to the ellipse </returns>
        public static bool InEllipse(this PointF point, PointF ellipseCenter, float radiusX, float radiusY)
        {
            return InEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY);
        }

        /// <summary>
        /// Check if a point belongs to an ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Flag if the point belongs to the ellipse </returns>
        public static bool InEllipse(this Point point, Point ellipseCenter, float radiusX, float radiusY)
        {
            return InEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY);
        }

        /// <summary>
        /// Check if a point belongs to an ellipse
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleX"> Ellipse center: X coordinate </param>
        /// <param name="circleY"> Ellipse center: X coordinate </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Flag if the point belongs to the ellipse </returns>
        public static bool InEllipse(double pointX, double pointY, double circleX, double circleY, double radiusX, double radiusY)
        {
            return (Math.Pow(pointX - circleX, 2) / Math.Pow(radiusX, 2)) + (Math.Pow(pointY - circleY, 2) / Math.Pow(radiusY, 2)) <= 1;
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Vector product </returns>
        public static float GetVectorProduct(PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetVectorProduct(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Vector product </returns>
        public static float GetVectorProduct(Point point, Point segmentStart, Point segmentEnd)
        {
            return GetVectorProduct(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coodinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Vector product </returns>
        public static float GetVectorProduct(float pointX, float pointY, float segmentStartX, float segmentStartY, float segmentEndX, float segmentEndY)
        {
            return ((segmentEndY - segmentStartY) * (pointX - segmentStartX)) - ((segmentEndX - segmentStartX) * (pointY - segmentStartY));
        }

        /// <summary>
        /// Calc vector product between point and segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coodinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Vector product </returns>
        public static double GetVectorProduct(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return ((segmentEndY - segmentStartY) * (pointX - segmentStartX)) - ((segmentEndX - segmentStartX) * (pointY - segmentStartY));
        }

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointSimpleRelativeLocation GetPointLocationFast(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetPointLocationFast(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointSimpleRelativeLocation GetPointLocationFast(this Point point, Point segmentStart, Point segmentEnd)
        {
            return GetPointLocationFast(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartX"> Segment start point: X coordinate </param>
        /// <param name="segmentStartY"> Segment start point: Y coodinate </param>
        /// <param name="segmentEndX"> Segment end point: X coordinate </param>
        /// <param name="segmentEndY"> Segment end point: Y coordinate </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointSimpleRelativeLocation GetPointLocationFast(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return GetPointLocationFast((float)pointX, pointY, segmentStartX, segmentStartY, segmentEndX, segmentEndY);
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="eps"> Epsilon </param>
        /// <returns> Flag if equals </returns>
        public static bool Equals(this PointF point1, PointF point2, float eps)
        {
            return Distance(point1, point2) <= eps;
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="eps"> Epsilon </param>
        /// <returns> Flag if equals </returns>
        public static bool Equals(this Point point1, Point point2, double eps)
        {
            return Distance(point1, point2) <= eps;
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Flag if equals </returns>
        public static bool Equals(double point1X, double point1Y, double point2X, double point2Y, double eps)
        {
            return Distance(point1X, point1Y, point2X, point2Y) <= eps;
        }
    }
}
