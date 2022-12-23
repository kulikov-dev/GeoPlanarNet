using System.Drawing;

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
            return 0.5d * Math.Abs(((apex2X - apex3X) * (apex1Y - apex3Y)) - ((apex1X - apex3X) * (apex2Y - apex3Y)));
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
