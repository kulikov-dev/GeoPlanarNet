using GeoPlanarNet.Enums;
using System;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the triangle
    /// </summary>
    public static class TriangleGeo
    {
        /// <summary>
        /// Get the triangle area
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
        /// Get the triangle area
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
        /// Get the triangle area
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
        /// Get the triangle perimeter
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
        /// Get the triangle perimeter
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
        /// Get the triangle perimeter
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
        /// Get the triangle type
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
        /// Get the triangle type
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
        /// Get the triangle type
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
        /// Get the triangle angles
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
        /// Get the triangle angles
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
        /// Get the triangle angles
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

            alphaRad = Math.Acos((lengthBSqr + lengthCSqr - lengthASqr) / (2d * lengthB * lengthC));
            bettaRad = Math.Acos((lengthASqr + lengthCSqr - lengthBSqr) / (2d * lengthA * lengthC));
            gammaRad = Math.Acos((lengthASqr + lengthBSqr - lengthCSqr) / (2d * lengthA * lengthB));
        }

        /// <summary>
        /// Check if one angle is equal 90 degrees
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> One angle is equal to 90 degrees </returns>
        public static bool IsRight(PointF apex1, PointF apex2, PointF apex3)
        {
            return IsRight(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if one angle is equal 90 degrees
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> One angle is equal to 90 degrees </returns>
        public static bool IsRight(Point apex1, Point apex2, Point apex3)
        {
            return IsRight(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if one angle is equal 90 degrees
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> One angle is equal to 90 degrees </returns>
        public static bool IsRight(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            GetAngles(apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y, out var alpha, out var betta, out var gamma);

            return alpha.AboutEquals(GeoPlanarNet.RightAngle) || betta.AboutEquals(GeoPlanarNet.RightAngle) || gamma.AboutEquals(GeoPlanarNet.RightAngle);
        }

        /// <summary>
        /// Check if one angle is greater than 90 degrees
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> One angle is greater than 90 degrees </returns>
        public static bool IsObtuse(PointF apex1, PointF apex2, PointF apex3)
        {
            return IsObtuse(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if one angle is greater than 90 degrees
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> One angle is greater than 90 degrees </returns>
        public static bool IsObtuse(Point apex1, Point apex2, Point apex3)
        {
            return IsObtuse(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if one angle is greater than 90 degrees
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> One angle is greater than 90 degrees </returns>
        public static bool IsObtuse(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            GetAngles(apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y, out var alpha, out var betta, out var gamma);

            return alpha > GeoPlanarNet.RightAngle || betta > GeoPlanarNet.RightAngle || gamma > GeoPlanarNet.RightAngle;
        }

        /// <summary>
        /// Check if all angles are less than 90 degrees
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> All angles are less than 90 degrees </returns>
        public static bool IsAcute(PointF apex1, PointF apex2, PointF apex3)
        {
            return IsAcute(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if all angles are less than 90 degrees
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> All angles are less than 90 degrees </returns>
        public static bool IsAcute(Point apex1, Point apex2, Point apex3)
        {
            return IsAcute(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Check if all angles are less than 90 degrees
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <returns> All angles are less than 90 degrees </returns>
        public static bool IsAcute(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            GetAngles(apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y, out var alpha, out var betta, out var gamma);

            return alpha < GeoPlanarNet.RightAngle & betta < GeoPlanarNet.RightAngle && gamma < GeoPlanarNet.RightAngle;
        }

        /// <summary>
        /// Get the AABB rect of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> AABB rect </returns>
        public static RectangleF GetAABB(PointF apex1, PointF apex2, PointF apex3)
        {
            GetAABB(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new RectangleF((float)leftTopX, (float)leftTopY, (float)width, (float)height);
        }

        /// <summary>
        /// Get the AABB rect of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> AABB rect </returns>
        public static Rectangle GetAABB(Point apex1, Point apex2, Point apex3)
        {
            GetAABB(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var leftTopX, out var leftTopY, out var width, out var height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the AABB rect of the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="leftTopX"> AABB left top: X coordinate </param>
        /// <param name="leftTopY"> AABB left top: Y coordinate </param>
        /// <param name="width"> Width </param>
        /// <param name="height"> Height </param>
        public static void GetAABB(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double leftTopX, out double leftTopY, out double width, out double height)
        {
            var minX = Math.Min(apex1X, Math.Min(apex2X, apex3X));
            var minY = Math.Min(apex1Y, Math.Min(apex2Y, apex3Y));
            var maxX = Math.Max(apex1X, Math.Max(apex2X, apex3X));
            var maxY = Math.Max(apex1Y, Math.Max(apex2Y, apex3Y));

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
            GetCenter(apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y, out var centerX, out var centerY);

            PointGeo.Rotate(apex1X, apex1Y, centerX, centerY, angleRadian, out rotatedApex1X, out rotatedApex1Y);
            PointGeo.Rotate(apex2X, apex2Y, centerX, centerY, angleRadian, out rotatedApex2X, out rotatedApex2Y);
            PointGeo.Rotate(apex3X, apex3Y, centerX, centerY, angleRadian, out rotatedApex3X, out rotatedApex3Y);

        }

        /// <summary>
        /// Get average center of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Center point </returns>
        public static PointF GetCenter(PointF apex1, PointF apex2, PointF apex3)
        {
            GetCenter(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var centerX, out var centerY);
            return new PointF((float)centerX, (float)centerY);
        }

        /// <summary>
        /// Get average center of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Center point </returns>
        public static Point GetCenter(Point apex1, Point apex2, Point apex3)
        {
            GetCenter(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out var centerX, out var centerY);
            return new Point((int)centerX, (int)centerY);
        }

        /// <summary>
        /// Get average center of the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="centerX"> Center point: X coordinate </param>
        /// <param name="centerY"> Center point: Y coordinate </param>
        public static void GetCenter(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double centerX, out double centerY)
        {
            centerX = (apex1X + apex2X + apex3X) / 3d;
            centerY = (apex1Y + apex2Y + apex3Y) / 3d;
        }

        /// <summary>
        /// Get shortest distance from the point to the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance from the point to the triangle</returns>
        public static double DistanceToPoint(PointF apex1, PointF apex2, PointF apex3, PointF point)
        {
            return point.DistanceToTriangle(apex1, apex2, apex3);
        }

        /// <summary>
        /// Get shortest distance from the point to the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance from the point to the triangle </returns>
        public static double DistanceToPoint(Point apex1, Point apex2, Point apex3, Point point)
        {
            return point.DistanceToTriangle(apex1, apex2, apex3);
        }

        /// <summary>
        /// Get shortest distance from the point to the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> Distance from the point to the triangle </returns>
        public static double DistanceToPoint(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, double pointX, double pointY)
        {
            return PointGeo.DistanceToTriangle(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y);
        }

        /// <summary>
        /// Get shortest distance from the circle to the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="circleRadius"> Radius </param>
        /// <returns> Distance from the circle to the triangle</returns>
        public static double DistanceToCircle(PointF apex1, PointF apex2, PointF apex3, PointF circleCenter, float circleRadius)
        {
            return DistanceToCircle(circleCenter.X, circleCenter.Y, circleRadius, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distance from the circle to the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="circleCenter"> Center point </param>
        /// <param name="circleRadius"> Radius </param>
        /// <returns> Distance from the circle to the triangle </returns>
        public static double DistanceToCircle(Point apex1, Point apex2, Point apex3, Point circleCenter, float circleRadius)
        {
            return DistanceToCircle(circleCenter.X, circleCenter.Y, circleRadius, apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get shortest distance from the circle to the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="circleCenterX"> Center point: X coordinate </param>
        /// <param name="circleCenterY"> Center point: Y coordinate </param>
        /// <param name="radius"> Radius </param>
        /// <returns> Distance from the circle to the triangle </returns>
        public static double DistanceToCircle(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, double circleCenterX, double circleCenterY, double radius)
        {
            return CircleGeo.DistanceToTriangle(circleCenterX, circleCenterY, radius, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool HasSegmentIntersection(PointF apex1, PointF apex2, PointF apex3, PointF segmentStart, PointF segmentEnd)
        {
            return SegmentGeo.HasTriangleIntersection(segmentStart, segmentEnd, apex1, apex2, apex3);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool HasSegmentIntersection(PointF apex1, PointF apex2, PointF apex3, Point segmentStart, Point segmentEnd)
        {
            return SegmentGeo.HasTriangleIntersection(segmentStart, segmentEnd, apex1, apex2, apex3);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool FindSegmentIntersection(PointF apex1, PointF apex2, PointF apex3, PointF segmentStart, PointF segmentEnd, out PointF intersection1, out PointF intersection2)
        {
            return SegmentGeo.FindTriangleIntersection(segmentStart, segmentEnd, apex1, apex2, apex3, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="segmentStart"> Line point 1 </param>
        /// <param name="segmentEnd"> Line point 2 </param>
        /// <param name="intersection1"> Intersection point 1 </param>
        /// <param name="intersection2"> Intersection point 2 </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool FindSegmentIntersection(PointF apex1, PointF apex2, PointF apex3, Point segmentStart, Point segmentEnd, out Point intersection1, out Point intersection2)
        {
            return SegmentGeo.FindTriangleIntersection(segmentStart, segmentEnd, apex1, apex2, apex3, out intersection1, out intersection2);
        }

        /// <summary>
        /// Find intersection between the segment and the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="segmentStartX"> Line point 1: X coordinate </param>
        /// <param name="segmentStartY"> Line point 1: Y coordinate </param>
        /// <param name="segmentEndX"> Line point 2: X coordinate </param>
        /// <param name="segmentEndY"> Line point 2: Y coordinate </param>
        /// <param name="intersection1X"> Intersection point 1: X coordinate </param>
        /// <param name="intersection1Y"> Intersection point 1: Y coordinate </param>
        /// <param name="intersection2X"> Intersection point 2: X coordinate </param>
        /// <param name="intersection2Y"> Intersection point 2: Y coordinate </param>
        /// <returns> True if the segment and the triangle has intersection </returns>
        public static bool FindSegmentIntersection(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, double segmentStartX, double segmentStartY, double segmentEndX, double segmentEndY,
                                                out double intersection1X, out double intersection1Y, out double intersection2X, out double intersection2Y)
        {
            return SegmentGeo.FindTriangleIntersection(segmentStartX, segmentStartY, segmentEndX, segmentEndY, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y,
                                                       out intersection1X, out intersection1Y, out intersection2X, out intersection2Y);
        }

        /// <summary>
        /// Get the segment location relative to the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationSegment(PointF apex1, PointF apex2, PointF apex3, PointF linePoint1, PointF linePoint2)
        {
            return SegmentGeo.GetRelativeLocationTriangle(linePoint1, linePoint2, apex1, apex2, apex3);
        }

        /// <summary>
        /// Get the segment location relative to the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <param name="linePoint1"> Line point 1 </param>
        /// <param name="linePoint2"> Line point 2 </param>
        /// <returns> Relative location </returns>
        public static PointAgainstFigureLocation GetRelativeLocationSegment(PointF apex1, PointF apex2, PointF apex3, Point linePoint1, Point linePoint2)
        {
            return SegmentGeo.GetRelativeLocationTriangle(linePoint1, linePoint2, apex1, apex2, apex3);
        }

        /// <summary>
        /// Get the segment location relative to the triangle
        /// </summary>
        /// <param name="apex1X"> Apex 1: X coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y coordinate </param>
        /// <param name="apex2X"> Apex 2: X coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y coordinate </param>
        /// <param name="apex3X"> Apex 3: X coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y coordinate </param>
        /// <param name="linePoint1X"> Line point 1: X </param>
        /// <param name="linePoint1Y"> Line point 1: Y </param>
        /// <param name="linePoint2X"> Line point 2: X </param>
        /// <param name="linePoint2Y"> Line point 2: Y </param>
        /// <returns> Point location </returns>
        /// <remarks> Return 'inside' if has two intersections </remarks>
        public static PointAgainstFigureLocation GetRelativeLocationSegment(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y)
        {
            return SegmentGeo.GetRelativeLocationTriangle(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y);
        }

        /// <summary>
        /// Check if the triangle contains the point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Triangle apex 1 </param>
        /// <param name="apex2"> Triangle apex 2 </param>
        /// <param name="apex3"> Triangle apex 3 </param>
        /// <returns> True, if the triangle contains the point </returns>
        public static bool Contains(this PointF point, PointF apex1, PointF apex2, PointF apex3)
        {
            return point.BelongsToTriangle(apex1, apex2, apex3);
        }

        /// <summary>
        /// Check if the triangle contains the point
        /// </summary>
        /// <param name="point"> Point </param>
        /// <param name="apex1"> Triangle apex 1 </param>
        /// <param name="apex2"> Triangle apex 2 </param>
        /// <param name="apex3"> Triangle apex 3 </param>
        /// <returns> True, if the triangle contains the point </returns>
        public static bool Contains(this Point point, Point apex1, Point apex2, Point apex3)
        {
            return point.BelongsToTriangle(apex1, apex2, apex3);
        }

        /// <summary>
        /// Check if the triangle contains the point
        /// </summary>
        /// <param name="pointX"> Point: X Coordinate </param>
        /// <param name="pointY"> Point: Y Coordinate </param>
        /// <param name="apex1X"> Apex 1: X Coordinate </param>
        /// <param name="apex1Y"> Apex 1: Y Coordinate </param>
        /// <param name="apex2X"> Apex 2: X Coordinate </param>
        /// <param name="apex2Y"> Apex 2: Y Coordinate </param>
        /// <param name="apex3X"> Apex 3: X Coordinate </param>
        /// <param name="apex3Y"> Apex 3: Y Coordinate </param>
        /// <returns> True, if the triangle contains the point </returns>
        public static bool Contains(double pointX, double pointY, double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            return PointGeo.BelongsToTriangle(pointX, pointY, apex1X, apex1Y, apex2X, apex2Y, apex3X, apex3Y);
        }
    }
}
