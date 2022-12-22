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
    }
}
