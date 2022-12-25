using GeoPlanarNet.Enums;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class to process operations with points
    /// </summary>
    public static class PointGeo
    {
        #region DistanceTo

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceTo(this PointF point1, PointF point2)
        {
            return DistanceTo(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2</param>
        /// <returns> Distance </returns>
        public static double DistanceTo(this Point point1, Point point2)
        {
            return DistanceTo(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Get distance between two points
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Distance </returns>
        public static double DistanceTo(double point1X, double point1Y, double point2X, double point2Y)
        {
            var distX = point1X - point2X;
            var distY = point1Y - point2Y;

            return Math.Sqrt(distX * distX + distY * distY);
        }

        /// <summary>
        /// Get shortest distance to the line
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
        /// Get shortest distance to the line
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
        /// Get shortest distance to the line
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
            var linesdistX = linePoint2X - linePoint1X;
            var linesdistY = linePoint2Y - linePoint1Y;

            var koef = (((linePoint2X - linePoint1X) * (pointX - linePoint1X)) + ((linePoint2Y - linePoint1Y) * (pointY - linePoint1Y))) / (linesdistX * linesdistX + linesdistY * linesdistY);
            var koefX = linePoint1X + ((linePoint2X - linePoint1X) * koef);
            var koefY = linePoint1Y + ((linePoint2Y - linePoint1Y) * koef);

            var distX = pointX - koefX;
            var distY = pointY - koefY;

            return Math.Sqrt(distX * distX + distY * distY);
        }

        /// <summary>
        /// Get shortest distance from point to the segment
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
        /// Get shortest distance from point to the segment
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
        /// Get shortest distance from point to the segment
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
            if ((segmentStartX - segmentEndX) * (pointX - segmentEndX) + (segmentStartY - segmentEndY) * (pointY - segmentEndY) <= 0)
            {
                return Math.Sqrt((pointX - segmentEndX) * (pointX - segmentEndX) + (pointY - segmentEndY) * (pointY - segmentEndY));
            }

            if ((segmentEndX - segmentStartX) * (pointX - segmentStartX) + (segmentEndY - segmentStartY) * (pointY - segmentStartY) <= 0)
            {
                return Math.Sqrt((pointX - segmentStartX) * (pointX - segmentStartX) + (pointY - segmentStartY) * (pointY - segmentStartY));
            }

            return Math.Abs((segmentEndY - segmentStartY) * pointX - (segmentEndX - segmentStartX) * pointY + segmentEndX * segmentStartY - segmentEndY * segmentStartX) /
                Math.Sqrt((segmentStartY - segmentEndY) * (segmentStartY - segmentEndY) + (segmentStartX - segmentEndX) * (segmentStartX - segmentEndX));
        }

        /// <summary>
        /// Get shortest distance from point to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToRect(this PointF point, RectangleF rect)
        {
            return DistanceToRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Get shortest distance from point to the axis-oriented rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rect"> Rectangle </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToRect(this Point point, Rectangle rect)
        {
            return DistanceToRect(point.X, point.Y, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        /// <summary>
        /// Get shortest distance from point to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Distance from the point to the rectangle </returns>
        public static double DistanceToRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY);
            var distanceBC = DistanceToSegment(pointX, pointY, rectLeftTopX, rectRightBottomY, rectRightBottomX, rectRightBottomY);
            var distanceCD = DistanceToSegment(pointX, pointY, rectRightBottomX, rectRightBottomY, rectRightBottomX, rectLeftTopY);
            var distanceDA = DistanceToSegment(pointX, pointY, rectRightBottomX, rectLeftTopY, rectLeftTopX, rectLeftTopY);

            return Math.Min(distanceAB, Math.Min(distanceBC, Math.Min(distanceCD, distanceDA)));
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(this PointF point, PointF circleCenter, float circleRadius)
        {
            return DistanceToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(this Point point, Point circleCenter, int circleRadius)
        {
            return DistanceToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, circleRadius);
        }

        /// <summary>
        /// Get shortest distance from the point to the circle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center point: X coordinate </param>
        /// <param name="circleCenterY"> Circle center point: Y coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Distance between the point and the circle </returns>
        public static double DistanceToCircle(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius)
        {
            var distX = pointX - circleCenterX;
            var distY = pointY - circleCenterY;

            return Math.Sqrt(distX * distX + distY * distY) - radius;
        }

        /// <summary>
        /// Get shortest distnace from the point to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Distance from the point to the triangle</returns>
        public static double DistanceToTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return DistanceToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distnace from the point to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Distance from the point to the triangle </returns>
        public static double DistanceToTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return DistanceToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distnace from the point to the triangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Distance from the point to the triangle </returns>
        public static double DistanceToTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y);
            var distanceBC = DistanceToSegment(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y);
            var distanceCA = DistanceToSegment(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y);

            return Math.Min(distanceAB, Math.Min(distanceBC, distanceCA));
        }

        /// <summary>
        /// Get shortest distance from point to the Surface
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="surface"> Surface </param>
        /// <returns> Distance to the surface </returns>
        public static double DistanceToSurface(this PointF point, PointF[] surface)
        {
            var minDistance = double.MaxValue;

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];
                var currentPoint = surface[i];
                var distance = DistanceToSegment(point, prevPoint, currentPoint);
                minDistance = Math.Min(distance, minDistance);
            }

            return minDistance;
        }

        /// <summary>
        /// Get shortest distance from point to the Surface
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="surface"> Surface </param>
        /// <returns> Distance to the surface </returns>
        public static double DistanceToSurface(this Point point, Point[] surface)
        {
            var minDistance = double.MaxValue;

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];
                var currentPoint = surface[i];
                var distance = DistanceToSegment(point, prevPoint, currentPoint);
                minDistance = Math.Min(distance, minDistance);
            }

            return minDistance;
        }

        #endregion

        #region BelongsTo

        /// <summary>
        /// Check if a point belongs to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Flag if the point belongs to the segment </returns>
        public static bool BelongsToSegment(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return BelongsToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Check if a point belongs to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Flag if the point belongs to the segment </returns>
        public static bool BelongsToSegment(this Point point, Point segmentStart, Point segmentEnd)
        {
            return BelongsToSegment(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
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
        public static bool BelongsToSegment(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            return GeoPlanarNet.AboutEquals(
                                DistanceTo(segmentStartX, segmentStartY, pointX, pointY) + DistanceTo(segmentEndX, segmentEndY, pointX, pointY),
                                DistanceTo(segmentStartX, segmentStartY, segmentEndX, segmentEndY));
        }

        /// <summary>
        /// Check if the point belongs to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Flag if the point belongs to the line </returns>
        public static bool BelongsToLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            return BelongsToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Check if the point belongs to the line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Flag if the point belongs to the line </returns>
        public static bool BelongsToLine(this Point point, Point linePoint1, Point linePoint2)
        {
            return BelongsToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        /// <summary>
        /// Check if the point belongs to the line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X"> Segment start point: X coordinate </param>
        /// <param name="linePoint1Y"> Segment start point: Y coodinate </param>
        /// <param name="linePoint2X"> Segment end point: X coordinate </param>
        /// <param name="linePoint2Y"> Segment end point: Y coordinate </param>
        /// <returns> Flag if the point belongs to the line </returns>
        public static bool BelongsToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            LineGeo.FindSlopeKoef(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, out double slopeKoef, out double yIntersection);

            return GeoPlanarNet.AboutEquals(pointY, slopeKoef * pointX + yIntersection);
        }

        /// <summary>
        /// Check if a point belongs to a circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Flag if the point belongs to the cirle </returns>
        public static bool BelongsToCircle(this PointF point, PointF circleCenter, float radius)
        {
            return BelongsToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius);
        }

        /// <summary>
        /// Check if a point belongs to a circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Flag if the point belongs to the cirle </returns>
        public static bool BelongsToCircle(this Point point, Point circleCenter, double radius)
        {
            return BelongsToCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius);

        }

        /// <summary>
        /// Check if a point belongs to a circle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Flag if the point belongs to the cirle </returns>
        public static bool BelongsToCircle(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius)
        {
            var distX = pointX - circleCenterX;
            var distY = pointY - circleCenterY;

            return distX * distX + distY * distY <= radius * radius;
        }

        /// <summary>
        /// Check if a point belong to a specific circle sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> Flag if the point belongs to the cirle sector </returns>
        public static bool BelongsToCircleSector(this PointF point, PointF circleCenter, float radius, float sectorStartAngleRad, float sectorEndAngleRad)
        {
            return BelongsToCircleSector(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if a point belong to a specific circle sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> Flag if the point belongs to the cirle sector </returns>
        public static bool BelongsToCircleSector(this Point point, Point circleCenter, int radius, int sectorStartAngleRad, int sectorEndAngleRad)
        {
            return BelongsToCircleSector(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if a point belong to a specific circle sector
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> Flag if the point belongs to the cirle sector </returns>
        public static bool BelongsToCircleSector(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius, double sectorStartAngleRad, double sectorEndAngleRad)
        {
            return BelongsToCircle(pointX, pointY, circleCenterX, circleCenterY, radius) && SegmentGeo.IsBetweenAngles(pointX, pointY, circleCenterX, circleCenterY, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if a point belongs to an ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Flag if the point belongs to the ellipse </returns>
        public static bool BelongsToEllipse(this PointF point, PointF ellipseCenter, float radiusX, float radiusY)
        {
            return BelongsToEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY);
        }

        /// <summary>
        /// Check if a point belongs to an ellipse
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Flag if the point belongs to the ellipse </returns>
        public static bool BelongsToEllipse(this Point point, Point ellipseCenter, int radiusX, int radiusY)
        {
            return BelongsToEllipse(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY);
        }

        /// <summary>
        /// Check if a point belongs to an ellipse
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Flag if the point belongs to the ellipse </returns>
        public static bool BelongsToEllipse(double pointX, double pointY, double ellipseCenterX, double ellipseCenterY, double radiusX, double radiusY)
        {
            var distX = pointX - ellipseCenterX;
            var distY = pointY - ellipseCenterY;

            return ((distX * distX) / (radiusX * radiusX)) + ((distY * distY) / (radiusY * radiusY)) <= 1;
        }

        /// <summary>
        /// Check if a point belong to a specific ellipse sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> Flag if the point belongs to the ellipse sector </returns>
        public static bool BelongsToEllipseSector(PointF point, PointF ellipseCenter, float radiusX, float radiusY, float sectorStartAngleRad, float sectorEndAngleRad)
        {
            return BelongsToEllipseSector(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if a point belong to a specific ellipse sector
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> Flag if the point belongs to the ellipse sector </returns>
        public static bool BelongsToEllipseSector(Point point, Point ellipseCenter, int radiusX, int radiusY, int sectorStartAngleRad, int sectorEndAngleRad)
        {
            return BelongsToEllipseSector(point.X, point.Y, ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if a point belong to a specific ellipse sector
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <returns> Flag if the point belongs to the ellipse sector </returns>
        public static bool BelongsToEllipseSector(double pointX, double pointY, double ellipseCenterX, double ellipseCenterY, double radiusX, double radiusY, double sectorStartAngleRad, double sectorEndAngleRad)
        {
            return BelongsToEllipse(pointX, pointY, ellipseCenterX, ellipseCenterY, radiusX, radiusY) && SegmentGeo.IsBetweenAngles(pointX, pointY, ellipseCenterX, ellipseCenterY, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if a point belongs to a triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Triangle apex 1 </param>
        /// <param name="apex2"> Triangle apex 2 </param>
        /// <param name="apex3"> Triangle apex 3 </param>
        /// <returns> Flag if the point belongs to the triangle </returns>
        public static bool BelongsToTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return BelongsToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if a point belongs to a triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Triangle apex 1 </param>
        /// <param name="apex2"> Triangle apex 2 </param>
        /// <param name="apex3"> Triangle apex 3 </param>
        /// <returns> Flag if the point belongs to the triangle </returns>
        public static bool BelongsToTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return BelongsToTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if a point belongs to a triangle
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="apex1X"> Apex 1: X Coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y Coordinate </param>
        /// <param name="apex2X"> Apex 2: X Coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y Coordinate </param>
        /// <param name="apex3X"> Apex 3: X Coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y Coordinate </param>
        /// <returns> Flag if the point belongs to the triangle </returns>
        public static bool BelongsToTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            return (GetRelativeLocationSimple(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y) != PointAgainstSegmentSimpleLocation.Left) &&
                    (GetRelativeLocationSimple(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y) != PointAgainstSegmentSimpleLocation.Left) &&
                    (GetRelativeLocationSimple(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y) != PointAgainstSegmentSimpleLocation.Left);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Flag, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this PointF point, float rectLeftTopX, float rectLeftTopY, float rectRightBottomX, float rectRightBottomY)
        {
            return BelongsToRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Flag, if belongs to the rectangle </returns>
        public static bool BelongsToRect(this Point point, int rectLeftTopX, int rectLeftTopY, int rectRightBottomX, int rectRightBottomY)
        {
            return BelongsToRect(point.X, point.Y, rectLeftTopX, rectLeftTopY, rectRightBottomX, rectRightBottomY);
        }

        /// <summary>
        /// Check if the point belongs to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopX"> Rectangle left top: X coordinate </param>
        /// <param name="rectLeftTopY"> Rectangle left top: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Flag, if belongs to the rectangle </returns>
        public static bool BelongsToRect(double pointX, double pointY, double rectLeftTopX, double rectLeftTopY, double rectRightBottomX, double rectRightBottomY)
        {
            return (GetRelativeLocationSimple(pointX, pointY, rectLeftTopX, rectLeftTopY, rectLeftTopX, rectRightBottomY) != PointAgainstSegmentSimpleLocation.Left) &&
                    (GetRelativeLocationSimple(pointX, pointY, rectLeftTopX, rectRightBottomY, rectRightBottomX, rectRightBottomY) != PointAgainstSegmentSimpleLocation.Left) &&
                    (GetRelativeLocationSimple(pointX, pointY, rectRightBottomX, rectRightBottomY, rectRightBottomX, rectLeftTopY) != PointAgainstSegmentSimpleLocation.Left) &&
                    (GetRelativeLocationSimple(pointX, pointY, rectRightBottomX, rectLeftTopY, rectLeftTopX, rectLeftTopY) != PointAgainstSegmentSimpleLocation.Left);
        }

        /// <summary>
        /// Check if a point belongs to an area
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="area"> Area </param>
        /// <param name="epsilon"> Accuracy </param>
        /// <returns> Flag if the point belongs to the area </returns>
        public static bool BelongsToSurface(this PointF point, IList<PointF> area)
        {
            var pointsInAreaCount = area.Count - 1;

            if (pointsInAreaCount < 1)
            {
                return false;
            }

            for (var i = 1; i < area.Count; ++i)
            {
                if (DistanceToSegment(point.X, point.Y, area[i - 1].X, area[i - 1].Y, area[i].X, area[i].Y) <= GeoPlanarNet.Epsilon)
                {
                    return true;
                }
            }

            var firstIndex = 0;

            while (firstIndex < area.Count && area[firstIndex].Y.AboutEquals(point.Y))
            {
                firstIndex++;
            }

            if (firstIndex == area.Count)
            {
                return false;
            }

            var indFirst = firstIndex;
            var secondIndex = (firstIndex + 1) % pointsInAreaCount;
            var iterations = 0;
            var left = 0;

            do
            {
                var yDiff = (area[firstIndex].Y - point.Y) * (area[secondIndex].Y - point.Y);
                iterations++;

                float xDiff;
                if (yDiff < 0)
                {
                    xDiff = area[firstIndex].X + ((area[secondIndex].X - area[firstIndex].X) * (point.Y - area[firstIndex].Y) / (area[secondIndex].Y - area[firstIndex].Y));

                    if (xDiff < point.X)
                    {
                        left++;
                    }
                    else
                    {
                        if (xDiff.AboutEquals(point.X))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (GeoPlanarNet.AboutZero(yDiff))
                    {
                        var firstYDiff = area[firstIndex].Y - point.Y;
                        while (area[secondIndex].Y.AboutEquals(point.Y))
                        {
                            firstIndex = secondIndex;
                            secondIndex = (secondIndex + 1) % pointsInAreaCount;

                            if (area[firstIndex].Y.AboutEquals(point.Y) && area[secondIndex].Y.AboutEquals(point.Y))
                            {
                                if (((area[firstIndex].X - point.X) * (area[secondIndex].X - point.X)) <= 0)
                                {
                                    return true;
                                }
                            }
                        }

                        yDiff = firstYDiff * (area[secondIndex].Y - point.Y);

                        if (yDiff < 0)
                        {
                            xDiff = area[firstIndex].X + ((area[secondIndex].X - area[firstIndex].X) * (point.Y - area[firstIndex].Y) / (area[secondIndex].Y - area[firstIndex].Y));

                            if (xDiff < point.X)
                            {
                                left++;
                            }
                            else
                            {
                                if (xDiff.AboutEquals(point.X))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                firstIndex = secondIndex;
                secondIndex = (secondIndex + 1) % pointsInAreaCount;
            }
            while ((secondIndex != (indFirst + 1)) && iterations < pointsInAreaCount);

            return (left % 2 == 1) && iterations <= pointsInAreaCount;
        }

        /// <summary>
        /// Check if a point belongs to an area
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="area"> Area </param>
        /// <param name="epsilon"> Accuracy </param>
        /// <returns> Flag if the point belongs to the area </returns>
        public static bool BelongsToSurface(this Point point, IList<Point> area)
        {
            var pointsInAreaCount = area.Count - 1;

            if (pointsInAreaCount < 1)
            {
                return false;
            }

            for (var i = 1; i < area.Count; ++i)
            {
                if (DistanceToSegment(point.X, point.Y, area[i - 1].X, area[i - 1].Y, area[i].X, area[i].Y) <= GeoPlanarNet.Epsilon)
                {
                    return true;
                }
            }

            var firstIndex = 0;

            while (firstIndex < area.Count && area[firstIndex].Y == point.Y)
            {
                firstIndex++;
            }

            if (firstIndex == area.Count)
            {
                return false;
            }

            var indFirst = firstIndex;
            var secondIndex = (firstIndex + 1) % pointsInAreaCount;
            var iterations = 0;
            var left = 0;

            do
            {
                var yDiff = (area[firstIndex].Y - point.Y) * (area[secondIndex].Y - point.Y);
                iterations++;

                int xDiff;
                if (yDiff < 0)
                {
                    xDiff = area[firstIndex].X + ((area[secondIndex].X - area[firstIndex].X) * (point.Y - area[firstIndex].Y) / (area[secondIndex].Y - area[firstIndex].Y));

                    if (xDiff < point.X)
                    {
                        left++;
                    }
                    else
                    {
                        if (xDiff == point.X)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (yDiff == 0)
                    {
                        var firstYDiff = area[firstIndex].Y - point.Y;
                        while (area[secondIndex].Y == point.Y)
                        {
                            firstIndex = secondIndex;
                            secondIndex = (secondIndex + 1) % pointsInAreaCount;

                            if (area[firstIndex].Y == point.Y && area[secondIndex].Y == point.Y)
                            {
                                if (((area[firstIndex].X - point.X) * (area[secondIndex].X - point.X)) <= 0)
                                {
                                    return true;
                                }
                            }
                        }

                        yDiff = firstYDiff * (area[secondIndex].Y - point.Y);

                        if (yDiff < 0)
                        {
                            xDiff = area[firstIndex].X + ((area[secondIndex].X - area[firstIndex].X) * (point.Y - area[firstIndex].Y) / (area[secondIndex].Y - area[firstIndex].Y));

                            if (xDiff < point.X)
                            {
                                left++;
                            }
                            else
                            {
                                if (xDiff == point.X)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                firstIndex = secondIndex;
                secondIndex = (secondIndex + 1) % pointsInAreaCount;
            }
            while ((secondIndex != (indFirst + 1)) && iterations < pointsInAreaCount);

            return (left % 2 == 1) && iterations <= pointsInAreaCount;
        }

        #endregion

        #region GetClosestPoint

        /// <summary>
        /// Find the point on the line closest to the given one
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="point"> Given point </param>
        /// <returns> Closest point on the line </returns>
        public static PointF GetClosestPointOnLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            GetClosestPointOnLine(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, point.X, point.Y, out double x, out double y);
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Find the point on the line closest to the given one
        /// </summary>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <param name="point"> Given point </param>
        /// <returns> Closest point on the line </returns>
        public static Point GetClosestPointOnLine(this Point point, Point linePoint1, Point linePoint2)
        {
            GetClosestPointOnLine(linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, point.X, point.Y, out double x, out double y);
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Find the point on the line closest to the given one
        /// </summary>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <param name="pointX"> Given point: X </param>
        /// <param name="pointY"> Given point: Y </param>
        /// <param name="closestPointX"> Closest point on the line: X </param>
        /// <param name="closestPointY"> Closest point on the line: Y </param>
        public static void GetClosestPointOnLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, out double closestPointX, out double closestPointY)
        {
            var projectionLineX = linePoint2X - linePoint1X;
            var projectionLineY = linePoint2Y - linePoint1Y;
            var toPointX = pointX - linePoint1X;
            var toPointY = pointY - linePoint1Y;
            var koefC1 = (projectionLineX * toPointX) + (projectionLineY * toPointY);
            var koefC2 = (projectionLineX * projectionLineX) + (projectionLineY * projectionLineY);
            var ratio = koefC1 / koefC2;

            closestPointX = linePoint1X + (ratio * projectionLineX);
            closestPointY = linePoint1Y + (ratio * projectionLineY);
        }

        /// <summary>
        /// Get closest point on the circle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Closest point </returns>
        public static PointF GetClosestPointOnCircle(this PointF point, PointF circleCenter, float radius)
        {
            GetClosestPointOnCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, out double closestPointX, out double closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the circle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenter"> Circle center </param>
        /// <param name="radius"> Circle radius </param>
        /// <returns> Closest point </returns>
        public static Point GetClosestPointOnCircle(this Point point, Point circleCenter, double radius)
        {
            GetClosestPointOnCircle(point.X, point.Y, circleCenter.X, circleCenter.Y, radius, out double closestPointX, out double closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the circle to the given point
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="circleCenterX"> Circle center: X coordinate </param>
        /// <param name="circleCenterY"> Circle center: X coordinate </param>
        /// <param name="radius"> Circle radius </param>
        /// <param name="closestPointX"> Closest point: X coordinate </param>
        /// <param name="closestPointY"> Closest point: Y coordinate </param>
        public static void GetClosestPointOnCircle(double pointX, double pointY, double circleCenterX, double circleCenterY, double radius, out double closestPointX, out double closestPointY)
        {
            var distX = pointX - circleCenterX;
            var distY = pointY - circleCenterY;
            var distanceToCircle = Math.Sqrt(distX * distX + distY * distY);

            closestPointX = circleCenterX + distX / distanceToCircle * radius;
            closestPointY = circleCenterY + distY / distanceToCircle * radius;
        }

        /// <summary>
        /// Get closest point on the triangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Closest point on the triangle </returns>
        public static PointF GetClosestPointOnTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            GetClosestPointOnTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out double closestPointX, out double closestPointY);
            return new PointF((float)closestPointX, (float)closestPointY);
        }

        /// <summary>
        /// Get closest point on the triangle to the given point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Closest point on the triangle </returns>
        public static Point GetClosestPointOnTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            GetClosestPointOnTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out double closestPointX, out double closestPointY);
            return new Point((int)closestPointX, (int)closestPointY);
        }

        /// <summary>
        /// Get closest point on the triangle to the given point
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Closest point on the triangle </returns>
        public static void GetClosestPointOnTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double closestPointX, out double closestPointY)
        {
            var distanceAB = DistanceToSegment(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y);
            var distanceBC = DistanceToSegment(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y);
            var distanceCA = DistanceToSegment(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y);

            if (distanceAB < distanceBC && distanceAB < distanceCA)
            {
                GetClosestPointOnLine(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y, out closestPointX, out closestPointY);
            }
            else if (distanceBC < distanceCA)
            {
                GetClosestPointOnLine(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y, out closestPointX, out closestPointY);
            }
            else
            {
                GetClosestPointOnLine(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y, out closestPointX, out closestPointY);
            }
        }


        #endregion

        #region GetLocation

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointAgainstSegmentSimpleLocation GetRelativeLocationSimple(this PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetRelativeLocationSimple(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        /// <remarks> Faster </remarks>
        public static PointAgainstSegmentSimpleLocation GetRelativeLocationSimple(this Point point, Point segmentStart, Point segmentEnd)
        {
            return GetRelativeLocationSimple(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
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
        public static PointAgainstSegmentSimpleLocation GetRelativeLocationSimple(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            var scalarMult = ((segmentEndY - segmentStartY) * (pointX - segmentStartX)) - ((segmentEndX - segmentStartX) * (pointY - segmentStartY));

            if (scalarMult > 0)
            {
                return PointAgainstSegmentSimpleLocation.Left;
            }

            if (scalarMult < 0)
            {
                return PointAgainstSegmentSimpleLocation.Right;
            }

            return PointAgainstSegmentSimpleLocation.OnTheSegment;
        }

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        public static PointAgainstSegmentLocation GetRelativeLocation(PointF point, PointF segmentStart, PointF segmentEnd)
        {
            return GetRelativeLocation(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
        }

        /// <summary>
        /// Get a point location relative to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStart"> Segment start point </param>
        /// <param name="segmentEnd"> Segment end point </param>
        /// <returns> Point relative location </returns>
        public static PointAgainstSegmentLocation GetRelativeLocation(Point point, Point segmentStart, Point segmentEnd)
        {
            return GetRelativeLocation(point.X, point.Y, segmentStart.X, segmentStart.Y, segmentEnd.X, segmentEnd.Y);
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
        public static PointAgainstSegmentLocation GetRelativeLocation(double pointX, double pointY, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY)
        {
            var diffSegmentX = segmentEndX - segmentStartX;
            var diffSegmentY = segmentEndY - segmentStartY;

            var diffToPointX = pointX - segmentStartX;
            var diffToPointY = pointY - segmentStartY;

            var diffKoef = (diffSegmentX * diffToPointY) - (diffToPointX * diffSegmentY);

            if (diffKoef > 0.0)
            {
                return PointAgainstSegmentLocation.Left;
            }

            if (diffKoef < 0.0)
            {
                return PointAgainstSegmentLocation.Right;
            }

            if ((diffSegmentX * diffToPointX < 0.0) || (diffSegmentY * diffToPointY < 0.0))
            {
                return PointAgainstSegmentLocation.Behind;
            }

            if (((diffSegmentX * diffSegmentX) + (diffSegmentY * diffSegmentY)) < ((diffToPointX * diffToPointX) + (diffToPointY * diffToPointY)))
            {
                return PointAgainstSegmentLocation.Beyond;
            }

            if (segmentStartX == pointX && segmentStartY == pointY)
            {
                return PointAgainstSegmentLocation.Start;
            }

            if (segmentEndX == pointX && segmentEndY == pointY)
            {
                return PointAgainstSegmentLocation.End;
            }

            return PointAgainstSegmentLocation.Between;
        }

        /// <summary>
        /// Get the point location relative to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return GetRelativeLocationTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get the point location relative to the triangle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return GetRelativeLocationTriangle(point.X, point.Y, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get the point location relative to the triangle
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="apex1X"> Apex 1: X Coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y Coordinate </param>
        /// <param name="apex2X"> Apex 2: X Coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y Coordinate </param>
        /// <param name="apex3X"> Apex 3: X Coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y Coordinate </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationTriangle(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            var abLocation = GetRelativeLocationSimple(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y);
            var bcLocation = GetRelativeLocationSimple(pointX, pointY, apex2X, apex2Y, apex3X, apex3Y);
            var caLocation = GetRelativeLocationSimple(pointX, pointY, apex3X, apex3Y, apex1X, apex1Y);

            if (abLocation != PointAgainstSegmentSimpleLocation.Left && bcLocation != PointAgainstSegmentSimpleLocation.Left && caLocation != PointAgainstSegmentSimpleLocation.Left)
            {
                return PointAgainstFigureLocation.Outside;
            }

            if (abLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || bcLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || caLocation == PointAgainstSegmentSimpleLocation.OnTheSegment)
            {
                return PointAgainstFigureLocation.OnTheEdge;
            }

            return PointAgainstFigureLocation.Inside;
        }

        /// <summary>
        /// Get the point location relative to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(this PointF point, PointF circleCenterPoint, float circleRadius)
        {
            return GetRelativeLocationCircle(point.X, point.Y, circleCenterPoint.X, circleCenterPoint.Y, circleRadius);
        }

        /// <summary>
        /// Get the point location relative to the circle
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="circleCenterPoint"> Circle center point </param>
        /// <param name="circleRadius"> Circle radius</param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(this Point point, Point circleCenterPoint, int circleRadius)
        {
            return GetRelativeLocationCircle(point.X, point.Y, circleCenterPoint.X, circleCenterPoint.Y, circleRadius);
        }

        /// <summary>
        ///  Get the point location relative to the circle
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="circleCenterPointX"> Circle center point: X Coordinate </param>
        /// <param name="circleCenterPointY"> Circle center point: Y Coordinate </param>
        /// <param name="circleCenterRadius"> Circle cente radius </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationCircle(double pointX, double pointY, double circleCenterPointX, double circleCenterPointY, double circleCenterRadius)
        {
            var distX = pointX - circleCenterPointX;
            var distY = pointY - circleCenterPointY;
            var diff = distX * distX + distY * distY;

            var radSqr = circleCenterRadius * circleCenterRadius;

            if (diff < radSqr)
            {
                return PointAgainstFigureLocation.Inside;
            }

            if (diff == radSqr)
            {
                return PointAgainstFigureLocation.OnTheEdge;
            }

            return PointAgainstFigureLocation.Outside;
        }

        /// <summary>
        /// Get the point location relative to the rectangle
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="rectLeftTopPointX"> Rectangle left-top point: X coordinate </param>
        /// <param name="rectLeftTopPointY"> Rectangle left-top point: Y coordinate </param>
        /// <param name="rectRightBottomX"> Rectangle right bottom: X coordinate </param>
        /// <param name="rectRightBottomY"> Rectangle right bottom: Y coordinate </param>
        /// <returns> Point location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationRect(double pointX, double pointY, double rectLeftTopPointX, double rectLeftTopPointY, double rectRightBottomX, double rectRightBottomY)
        {
            var abLocation = GetRelativeLocationSimple(pointX, pointY, rectLeftTopPointX, rectLeftTopPointY, rectRightBottomX, rectLeftTopPointY);
            var bcLocation = GetRelativeLocationSimple(pointX, pointY, rectRightBottomX, rectLeftTopPointY, rectRightBottomX, rectRightBottomY);
            var cdLocation = GetRelativeLocationSimple(pointX, pointY, rectRightBottomX, rectRightBottomY, rectLeftTopPointX, rectRightBottomY);
            var daLocation = GetRelativeLocationSimple(pointX, pointY, rectLeftTopPointX, rectRightBottomY, rectLeftTopPointX, rectLeftTopPointY);

            if (abLocation != PointAgainstSegmentSimpleLocation.Left && bcLocation != PointAgainstSegmentSimpleLocation.Left &&
                cdLocation != PointAgainstSegmentSimpleLocation.Left && daLocation != PointAgainstSegmentSimpleLocation.Left)
            {
                return PointAgainstFigureLocation.Outside;
            }

            if (abLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || bcLocation == PointAgainstSegmentSimpleLocation.OnTheSegment ||
                cdLocation == PointAgainstSegmentSimpleLocation.OnTheSegment || daLocation == PointAgainstSegmentSimpleLocation.OnTheSegment)
            {
                return PointAgainstFigureLocation.OnTheEdge;
            }

            return PointAgainstFigureLocation.Inside;
        }

        #endregion

        /// <summary>
        /// Rotate point around the center
        /// </summary>
        /// <param name="point"> Source point </param>
        /// <param name="center"> Center point </param>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Rotated point </returns>
        public static PointF Rotate(this PointF point, PointF center, double angleRadian)
        {
            Rotate(point.X, point.Y, center.X, center.Y, angleRadian, out double rotatedPointX, out double rotatedPointY);
            return new PointF((float)rotatedPointX, (float)rotatedPointY);
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
            Rotate(point.X, point.Y, center.X, center.Y, angleRadian, out double rotatedPointX, out double rotatedPointY);
            return new Point((int)rotatedPointX, (int)rotatedPointY);
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
        public static void Rotate(double pointX, double pointY, double centerX, double centerY, double angleRadian, out double rotatedPointX, out double rotatedPointY)
        {
            var diffX = pointX - centerX;
            var diffY = pointY - centerY;

            rotatedPointX = centerX + (diffX * Math.Cos(angleRadian)) - (diffY * Math.Sin(angleRadian));
            rotatedPointY = centerY + (diffX * Math.Sin(angleRadian)) + (diffY * Math.Cos(angleRadian));
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
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="eps"> Epsilon </param>
        /// <returns> Flag if equals </returns>
        public static bool Equals(this PointF point1, PointF point2)
        {
            return DistanceTo(point1, point2) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="eps"> Epsilon </param>
        /// <returns> Flag if equals </returns>
        public static bool Equals(this Point point1, Point point2)
        {
            return DistanceTo(point1, point2) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Check if two points are equal
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <returns> Flag if equals </returns>
        public static bool Equals(double point1X, double point1Y, double point2X, double point2Y)
        {
            return DistanceTo(point1X, point1Y, point2X, point2Y) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static PointF GetProjectionToLine(this PointF point, PointF linePoint1, PointF linePoint2)
        {
            GetProjectionToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out double projectionPoint1, out double projectionPoint2);
            return new PointF((float)projectionPoint1, (float)projectionPoint2);
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static Point GetProjectionToLine(this Point point, Point linePoint1, Point linePoint2)
        {
            GetProjectionToLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, out double projectionPoint1, out double projectionPoint2);
            return new Point((int)projectionPoint1, (int)projectionPoint2);
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="linePoint1X"> Line point 1: X coordinate </param>
        /// <param name="linePoint1Y"> Line point 1: Y coordinate </param>
        /// <param name="linePoint2X"> Line point 2: X coordinate </param>
        /// <param name="linePoint2Y"> Line point 2: Y coordinate </param>
        /// <param name="projectionPointX"> Projection point: X coordinate </param>
        /// <param name="projectionPointY"> Projection point: Y coordinate </param>
        public static void GetProjectionToLine(double pointX, double pointY, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y, out double projectionPointX, out double projectionPointY)
        {
            LineGeo.FindSlopeKoef(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, out double k, out double b);

            if (GeoPlanarNet.AboutZero(k))
            {
                projectionPointX = pointX;
                projectionPointY = b;

                return;
            }

            if (double.IsInfinity(k))
            {
                projectionPointX = b;
                projectionPointY = pointY;

                return;
            }

            var k2 = -1 / k;
            var b2 = pointY - (pointX * k2);
            projectionPointX = (b2 - b) / (k - k2);
            projectionPointY = (k * projectionPointX) + b;
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="slopeKoef"> Angle of inclination θ by the tangent function </param>
        /// <param name="yZeroValue"> Y value if x = 0 </param>
        /// <returns> Projection point </returns>
        public static PointF GetProjectionToLine(this PointF point, float slopeKoef, float yZeroValue)
        {
            if (GeoPlanarNet.AboutZero(slopeKoef))
            {
                return new PointF(point.X, yZeroValue);
            }

            if (double.IsInfinity(slopeKoef))
            {
                return new PointF(yZeroValue, point.Y);
            }

            var diffSlopeKoef = -1 / slopeKoef;
            var yZeroValueKoef = point.Y - (point.X * diffSlopeKoef);

            var x = (yZeroValueKoef - yZeroValue) / (slopeKoef - diffSlopeKoef);
            var y = (slopeKoef * x) + yZeroValue;

            return new PointF(x, y);
        }

        /// <summary>
        /// Check if a point has projection to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasProjectionToSegment(this PointF point, PointF segmentStartPoint, PointF segmentEndPoint)
        {
            return HasProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y);
        }

        /// <summary>
        /// Check if a point has projection to a segment
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Segment start point </param>
        /// <param name="segmentEndPoint"> Segment end point </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasProjectionToSegment(this Point point, Point segmentStartPoint, Point segmentEndPoint)
        {
            return HasProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y);
        }

        /// <summary>
        /// Check if a point has projection to a segment
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartPointX"> Start segment point 1: X coordinate </param>
        /// <param name="segmentStartPointY"> Start segment point 1: Y coordinate </param>
        /// <param name="segmentEndPointX"> End segment point 2: X coordinate </param>
        /// <param name="segmentEndPointY"> End segment point 2: Y coordinate </param>
        /// <returns> True, if has intersection with the segment </returns>
        public static bool HasProjectionToSegment(double pointX, double pointY, double segmentStartPointX, double segmentStartPointY, double segmentEndPointX, double segmentEndPointY)
        {
            GetProjectionToLine(pointX, pointY, segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY, out double projectionPointX, out double projectionPointY);

            var startToProjectionDiff = DistanceTo(segmentStartPointX, segmentStartPointY, projectionPointX, projectionPointY);
            var endToProjectionDiff = DistanceTo(segmentEndPointX, segmentEndPointY, projectionPointX, projectionPointY);
            var segmentDiff = DistanceTo(segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY);

            return Math.Abs(startToProjectionDiff + endToProjectionDiff - segmentDiff) <= GeoPlanarNet.Epsilon;
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Line point 1 </param>
        /// <param name="segmentEndPoint"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static PointF GetProjectionToSegment(this PointF point, PointF segmentStartPoint, PointF segmentEndPoint)
        {
            GetProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y, out double projectionPoint1, out double projectionPoint2);
            return new PointF((float)projectionPoint1, (float)projectionPoint2);
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="segmentStartPoint"> Line point 1 </param>
        /// <param name="segmentEndPoint"> Line point 2 </param>
        /// <returns> Projection point </returns>
        public static Point GetProjectionToSegment(this Point point, Point segmentStartPoint, Point segmentEndPoint)
        {
            GetProjectionToSegment(point.X, point.Y, segmentStartPoint.X, segmentStartPoint.Y, segmentEndPoint.X, segmentEndPoint.Y, out double projectionPoint1, out double projectionPoint2);
            return new Point((int)projectionPoint1, (int)projectionPoint2);
        }

        /// <summary>
        /// Get projection point to a line
        /// </summary>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <param name="segmentStartPointX"> Line point 1: X coordinate </param>
        /// <param name="segmentStartPointY"> Line point 1: Y coordinate </param>
        /// <param name="segmentEndPointX"> Line point 2: X coordinate </param>
        /// <param name="segmentEndPointY"> Line point 2: Y coordinate </param>
        /// <param name="projectionPointX"> Projection point: X coordinate </param>
        /// <param name="projectionPointY"> Projection point: Y coordinate </param>
        public static void GetProjectionToSegment(double pointX, double pointY, double segmentStartPointX, double segmentStartPointY, double segmentEndPointX, double segmentEndPointY,
                                                  out double projectionPointX, out double projectionPointY)
        {
            GetProjectionToLine(pointX, pointY, segmentStartPointX, segmentStartPointY, segmentEndPointX, segmentEndPointY, out projectionPointX, out projectionPointY);
        }

        /// <summary>
        /// Check if three points are collinear
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="point3"> Point 3 </param>
        /// <returns> Flag, if points are collinear </returns>
        public static bool IsCollinear(this PointF point1, PointF point2, PointF point3)
        {
            return IsCollinear(point1.X, point1.Y, point2.X, point2.Y, point3.X, point3.Y);
        }

        /// <summary>
        /// Check if three points are collinear
        /// </summary>
        /// <param name="point1"> Point 1 </param>
        /// <param name="point2"> Point 2 </param>
        /// <param name="point3"> Point 3 </param>
        /// <returns> Flag, if points are collinear </returns>
        public static bool IsCollinear(this Point point1, Point point2, Point point3)
        {
            return IsCollinear(point1.X, point1.Y, point2.X, point2.Y, point3.X, point3.Y);
        }

        /// <summary>
        /// Check if three points are collinear
        /// </summary>
        /// <param name="point1X"> Point 1: X coordinate </param>
        /// <param name="point1Y"> Point 1: Y coordinate </param>
        /// <param name="point2X"> Point 2: X coordinate </param>
        /// <param name="point2Y"> Point 2: Y coordinate </param>
        /// <param name="point3X"> Point 3: X coordinate </param>
        /// <param name="point3Y"> Point 3: Y coordinate </param>
        /// <returns> Flag, if points are collinear </returns>
        public static bool IsCollinear(double point1X, double point1Y, double point2X, double point2Y, double point3X, double point3Y)
        {
            return GeoPlanarNet.AboutEquals((point3Y - point2Y) * (point2X - point1X), (point2Y - point1Y) * (point3X - point2X));
        }
    }
}
