using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns> Triangle area </returns>
        private static double Area(PointF apex1, PointF apex2, PointF apex3)
        {
            return Area(apex1.X, apex1.Y, apex2.X, apex2.Y, apex3.X, apex3.Y);
        }

        /// <summary>
        /// Get triangle area
        /// </summary>
        /// <param name="apex1"> Apex 1 </param>
        /// <param name="apex2"> Apex 2 </param>
        /// <param name="apex3"> Apex 3 </param>
        /// <returns> Triangle area </returns>
        private static double Area(Point apex1, Point apex2, Point apex3)
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
        /// <returns> Triangle area </returns>
        private static float Area(float apex1X, float apex1Y, float apex2X, float apex2Y, float apex3X, float apex3Y)
        {
            return ((apex2X - apex1X) * (apex3Y - apex1Y)) - ((apex2Y - apex1Y) * (apex3X - apex1X));
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
        /// <returns> Triangle area </returns>
        private static double Area(double apex1X, double apex1Y, double apex2X, double apex2Y, double apex3X, double apex3Y)
        {
            return ((apex2X - apex1X) * (apex3Y - apex1Y)) - ((apex2Y - apex1Y) * (apex3X - apex1X));
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
        /// <returns> Triangle area </returns>
        private static int Area(int apex1X, int apex1Y, int apex2X, int apex2Y, int apex3X, int apex3Y)
        {
            return ((apex2X - apex1X) * (apex3Y - apex1Y)) - ((apex2Y - apex1Y) * (apex3X - apex1X));
        }
    }
}
