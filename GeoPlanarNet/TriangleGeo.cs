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
        public static RectangleF GetBoundingRect(PointF apex1, PointF apex2, PointF apex3)
        {
            GetBoundingRect(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out double leftTopX, out double leftTopY, out double width, out double height);
            return new Rectangle((int)leftTopX, (int)leftTopY, (int)width, (int)height);
        }

        /// <summary>
        /// Get the bounding rect of the triangle
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Bounding box </returns>
        public static Rectangle GetBoundingRect(Point apex1, Point apex2, Point apex3)
        {
            GetBoundingRect(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y, out double leftTopX, out double leftTopY, out double width, out double height);
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
        public static void GetBoundingRect(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y, out double leftTopX, out double leftTopY, out double width, out double height)
        {
            var minX = Math.Min(apex1X, Math.Min(apex2X, apex3X));
            var minY = Math.Min(apex1X, Math.Min(apex2X, apex3X));
            var maxX = Math.Min(apex1X, Math.Min(apex2X, apex3X));
            var maxY = Math.Min(apex1X, Math.Min(apex2X, apex3X));

            leftTopX = minX;
            leftTopY = minY;
            width = maxX - minX;
            height = maxY - minY;
        }
    }
}
