using System;
using System.Drawing;
using GeoPlanarNet.Enums;

namespace GeoPlanarNet
{
    public static class TriangleGeo
    {
        /// <summary>
        /// Get triangle area
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle square </returns>
        public static double Area(PointF apex1, PointF apex2, PointF apex3)
        {
            return Area(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle area
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle square </returns>
        public static double Area(Point apex1, Point apex2, Point apex3)
        {
            return Area(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle area
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Triangle square </returns>
        public static double Area(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            return 0.5d * Math.Abs((apex2X - apex3X) * (apex1Y - apex3Y) - (apex1X - apex3X) * (apex2Y - apex3Y));
        }

        /// <summary>
        /// Get triangle perimeter
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle perimeter </returns>
        public static double Perimeter(PointF apex1, PointF apex2, PointF apex3)
        {
            return Perimeter(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle perimeter
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle perimeter </returns>
        public static double Perimeter(Point apex1, Point apex2, Point apex3)
        {
            return Perimeter(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle perimeter
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Triangle perimeter </returns>
        public static double Perimeter(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            var lengthA = SegmentGeo.Length(apex2X, apex2Y, apex3X, apex3Y);
            var lengthB = SegmentGeo.Length(apex1X, apex1Y, apex3X, apex3Y);
            var lengthC = SegmentGeo.Length(apex1X, apex1Y, apex2X, apex2Y);

            return lengthA + lengthB + lengthC;
        }

        /// <summary>
        /// Get triangle type
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle type </returns>
        public static TriangleType GetTriangleType(PointF apex1, PointF apex2, PointF apex3)
        {
            return GetTriangleType(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle type
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle type </returns>
        public static TriangleType GetTriangleType(Point apex1, Point apex2, Point apex3)
        {
            return GetTriangleType(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle type
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> Triangle type </returns>
        public static TriangleType GetTriangleType(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            var lengthA = SegmentGeo.Length(apex2X, apex2Y, apex3X, apex3Y);
            var lengthB = SegmentGeo.Length(apex1X, apex1Y, apex3X, apex3Y);
            var lengthC = SegmentGeo.Length(apex1X, apex1Y, apex2X, apex2Y);

            if (lengthA.AboutEquals(lengthB) && lengthB.AboutEquals(lengthC))
            {
                return TriangleType.Equilateral;
            }

            if (lengthA.AboutEquals(lengthB) || lengthB.AboutEquals(lengthC) || lengthA.AboutEquals(lengthC))
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }

        /// <summary>
        /// Get triangle area
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="alphaRad"> AB-AC angle </param>
        /// <param name="bettaRad"> BA-BC angle </param>
        /// <param name="gammaRad"> CA-CB angle </param>
        /// <remarks> From Cosine law </remarks>
        public static void GetAngles(PointF apex1, PointF apex2, PointF apex3, out double alphaRad, out double bettaRad, out double gammaRad)
        {
            GetAngles(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out alphaRad, out bettaRad, out gammaRad);
        }

        /// <summary>
        /// Get triangle area
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="alphaRad"> AB-AC angle </param>
        /// <param name="bettaRad"> BA-BC angle </param>
        /// <param name="gammaRad"> CA-CB angle </param>
        /// <remarks> From Cosine law </remarks>
        public static void GetAngles(Point apex1, Point apex2, Point apex3, out double alphaRad, out double bettaRad, out double gammaRad)
        {
            GetAngles(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out alphaRad, out bettaRad, out gammaRad);
        }

        /// <summary>
        /// Get angles of the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="alphaRad"> AB-AC angle </param>
        /// <param name="bettaRad"> BA-BC angle </param>
        /// <param name="gammaRad"> CA-CB angle </param>
        /// <remarks> From Cosine law </remarks>
        public static void GetAngles(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double alphaRad, out double bettaRad, out double gammaRad)
        {
            var lengthASqr = SegmentGeo.LengthSqr(apex2X, apex2Y, apex3X, apex3Y);
            var lengthBSqr = SegmentGeo.LengthSqr(apex1X, apex1Y, apex3X, apex3Y);
            var lengthCSqr = SegmentGeo.LengthSqr(apex1X, apex1Y, apex2X, apex2Y);

            var lengthA = Math.Sqrt(lengthASqr);
            var lengthB = Math.Sqrt(lengthBSqr);
            var lengthC = Math.Sqrt(lengthCSqr);

            alphaRad = Math.Acos((lengthBSqr + lengthCSqr - lengthASqr) / (2 * lengthB * lengthC));
            bettaRad = Math.Acos((lengthASqr + lengthCSqr - lengthBSqr) / (2 * lengthA * lengthC));
            gammaRad = Math.Acos((lengthASqr + lengthBSqr - lengthCSqr) / (2 * lengthA * lengthB));
        }

        /// <summary>
        /// Get the bounding rect of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Bounding box </returns>
        public static RectangleF GetAABB(PointF apex1, PointF apex2, PointF apex3)
        {
            GetAABB(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the bounding rect of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Bounding box </returns>
        public static Rectangle GetAABB(Point apex1, Point apex2, Point apex3)
        {
            GetAABB(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the bounding rect of the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        public static void GetAABB(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double leftTopX, out double leftTopY, out double width, out double height)
        {
            var minX = Math.Min(apex1X, Math.Min(apex2X, apex3X));
            var minY = Math.Min(apex1Y, Math.Min(apex2Y, apex3Y));
            var maxX = Math.Min(apex1X, Math.Min(apex2X, apex3X));
            var maxY = Math.Min(apex1Y, Math.Min(apex2Y, apex3Y));

            leftTopX = minX;
            leftTopY = minY;
            width = maxX - minX;
            height = maxY - minY;
        }

        /// <summary>
        /// Rotate the triangle around the point
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="point"> Point around rotation </param>
        /// <param name="angleRadian"> Angle to rotate </param>
        /// <param name="rotatedApex1"> Rotated apex 1 </param>
        /// <param name="rotatedApex2"> Rotated apex 2 </param>
        /// <param name="rotatedApex3"> Rotated apex 3 </param>
        public static void Rotate(PointF apex1, PointF apex2, PointF apex3, PointF point, double angleRadian, out PointF rotatedApex1, out PointF rotatedApex2, out PointF rotatedApex3)
        {
            Rotate(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, point.X, point.Y, angleRadian,
                out var rotatedApex1X, out var rotatedApex1Y, out var rotatedApex2X, out var rotatedApex2Y, out var rotatedApex3X, out var rotatedApex3Y);

            rotatedApex1 = new PointF((float)rotatedApex1X, (float)rotatedApex1Y);
            rotatedApex2 = new PointF((float)rotatedApex2X, (float)rotatedApex2Y);
            rotatedApex3 = new PointF((float)rotatedApex3X, (float)rotatedApex3Y);
        }

        /// <summary>
        /// Rotate the triangle around the point
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="point"> Point around rotation </param>
        /// <param name="angleRadian"> Angle to rotate </param>
        /// <param name="rotatedApex1"> Rotated apex 1 </param>
        /// <param name="rotatedApex2"> Rotated apex 2 </param>
        /// <param name="rotatedApex3"> Rotated apex 3 </param>
        public static void Rotate(Point apex1, Point apex2, Point apex3, Point point, double angleRadian, out Point rotatedApex1, out Point rotatedApex2, out Point rotatedApex3)
        {
            Rotate(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, point.X, point.Y, angleRadian,
                    out var rotatedApex1X, out var rotatedApex1Y, out var rotatedApex2X, out var rotatedApex2Y, out var rotatedApex3X, out var rotatedApex3Y);

            rotatedApex1 = new Point((int)rotatedApex1X, (int)rotatedApex1Y);
            rotatedApex2 = new Point((int)rotatedApex2X, (int)rotatedApex2Y);
            rotatedApex3 = new Point((int)rotatedApex3X, (int)rotatedApex3Y);
        }

        /// <summary>
        /// Rotate the triangle around the point
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="pointX"> Point to rotate: X coordinate </param>
        /// <param name="pointY"> Point to rotate: X coordinate </param>
        /// <param name="angleRadian"> Angle to rotate </param>
        /// <param name="rotatedApex1X"> Rotated apex 1: X coordinate </param>
        /// <param name="rotatedApex1Y"> Rotated apex 1: Y coordinate </param>
        /// <param name="rotatedApex2X"> Rotated apex 2: X coordinate </param>
        /// <param name="rotatedApex2Y"> Rotated apex 2: Y coordinate </param>
        /// <param name="rotatedApex3X"> Rotated apex 3: X coordinate </param>
        /// <param name="rotatedApex3Y"> Rotated apex 3: Y coordinate </param>
        public static void Rotate(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, double pointX, double pointY, double angleRadian,
                                  out double rotatedApex1X, out double rotatedApex1Y, out double rotatedApex2X, out double rotatedApex2Y, out double rotatedApex3X, out double rotatedApex3Y)
        {
            PointGeo.Rotate(apex1X, apex1Y, pointX, pointY, angleRadian, out rotatedApex1X, out rotatedApex1Y);
            PointGeo.Rotate(apex2X, apex2Y, pointX, pointY, angleRadian, out rotatedApex2X, out rotatedApex2Y);
            PointGeo.Rotate(apex3X, apex3Y, pointX, pointY, angleRadian, out rotatedApex3X, out rotatedApex3Y);

        }

        /// <summary>
        /// Rotate the triangle around the center
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="angleRadian"> Angle to rotate </param>
        /// <param name="rotatedApex1"> Rotated apex 1 </param>
        /// <param name="rotatedApex2"> Rotated apex 2 </param>
        /// <param name="rotatedApex3"> Rotated apex 3 </param>
        public static void Rotate(PointF apex1, PointF apex2, PointF apex3, double angleRadian, out PointF rotatedApex1, out PointF rotatedApex2, out PointF rotatedApex3)
        {
            Rotate(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, angleRadian,
                out var rotatedApex1X, out var rotatedApex1Y, out var rotatedApex2X, out var rotatedApex2Y, out var rotatedApex3X, out var rotatedApex3Y);

            rotatedApex1 = new PointF((float)rotatedApex1X, (float)rotatedApex1Y);
            rotatedApex2 = new PointF((float)rotatedApex2X, (float)rotatedApex2Y);
            rotatedApex3 = new PointF((float)rotatedApex3X, (float)rotatedApex3Y);
        }

        /// <summary>
        /// Rotate the triangle around the center
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="angleRadian"> Angle to rotate </param>
        /// <param name="rotatedApex1"> Rotated apex 1 </param>
        /// <param name="rotatedApex2"> Rotated apex 2 </param>
        /// <param name="rotatedApex3"> Rotated apex 3 </param>
        public static void Rotate(Point apex1, Point apex2, Point apex3, double angleRadian, out Point rotatedApex1, out Point rotatedApex2, out Point rotatedApex3)
        {
            Rotate(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, angleRadian,
                    out var rotatedApex1X, out var rotatedApex1Y, out var rotatedApex2X, out var rotatedApex2Y, out var rotatedApex3X, out var rotatedApex3Y);

            rotatedApex1 = new Point((int)rotatedApex1X, (int)rotatedApex1Y);
            rotatedApex2 = new Point((int)rotatedApex2X, (int)rotatedApex2Y);
            rotatedApex3 = new Point((int)rotatedApex3X, (int)rotatedApex3Y);
        }

        /// <summary>
        /// Rotate the triangle around the center
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="angleRadian"> Angle to rotate </param>
        /// <param name="rotatedApex1X"> Rotated apex 1: X coordinate </param>
        /// <param name="rotatedApex1Y"> Rotated apex 1: Y coordinate </param>
        /// <param name="rotatedApex2X"> Rotated apex 2: X coordinate </param>
        /// <param name="rotatedApex2Y"> Rotated apex 2: Y coordinate </param>
        /// <param name="rotatedApex3X"> Rotated apex 3: X coordinate </param>
        /// <param name="rotatedApex3Y"> Rotated apex 3: Y coordinate </param>
        public static void Rotate(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, double angleRadian,
                                  out double rotatedApex1X, out double rotatedApex1Y, out double rotatedApex2X, out double rotatedApex2Y, out double rotatedApex3X, out double rotatedApex3Y)
        {
            Center(apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y, out var centerX, out var centerY);

            PointGeo.Rotate(apex1X, apex1Y, centerX, centerY, angleRadian, out rotatedApex1X, out rotatedApex1Y);
            PointGeo.Rotate(apex2X, apex2Y, centerX, centerY, angleRadian, out rotatedApex2X, out rotatedApex2Y);
            PointGeo.Rotate(apex3X, apex3Y, centerX, centerY, angleRadian, out rotatedApex3X, out rotatedApex3Y);

        }

        /// <summary>
        /// Get average center of the rectangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Center point </returns>
        public static PointF Center(PointF apex1, PointF apex2, PointF apex3)
        {
            Center(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var centerX, out var centerY);
            return new PointF((float) centerX, (float) centerY);
        }

        /// <summary>
        /// Get average center of the rectangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Center point </returns>
        public static Point Center(Point apex1, Point apex2, Point apex3)
        {
            Center(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var centerX, out var centerY);
            return new Point((int)centerX, (int)centerY);
        }

        /// <summary>
        /// Get average center of the rectangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="centerX"> Center point: X coordinate </param>
        /// <param name="centerY"> Center point: Y coordinate </param>
        public static void Center(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double centerX, out double centerY)
        {
            centerX = (apex1X + apex2X + apex3X) / 3d;
            centerY = (apex1Y + apex2Y + apex3Y) / 3d;
        }
    }
}
