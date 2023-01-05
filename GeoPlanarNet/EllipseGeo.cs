using System;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the ellipse
    /// </summary>
    public static class EllipseGeo
    {
        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(float semiMajor, float semiMinor)
        {
            return Area((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(int semiMajor, int semiMinor)
        {
            return Area((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(double semiMajor, double semiMinor)
        {
            return Math.PI * semiMajor * semiMinor;
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double Eccentricity(float semiMajor, float semiMinor)
        {
            return Eccentricity((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double Eccentricity(int semiMajor, int semiMinor)
        {
            return Eccentricity((double) semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double Eccentricity(double semiMajor, double semiMinor)
        {
            return Math.Sqrt(1 - semiMinor * semiMinor / (semiMajor * semiMajor));
        }

        /// <summary>
        /// Get the ellipse perimeter
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Perimeter </returns>
        /// <remarks> Ramanujan approximation v3 </remarks>
        public static double Perimeter(float semiMajor, float semiMinor)
        {
            return Perimeter(semiMajor, (double)semiMinor);
        }

        /// <summary>
        /// Get the ellipse perimeter
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Perimeter </returns>
        /// <remarks> Ramanujan approximation v3 </remarks>
        public static double Perimeter(int semiMajor, int semiMinor)
        {
            return Perimeter(semiMajor, (double) semiMinor);
        }

        /// <summary>
        /// Get the ellipse perimeter
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Perimeter </returns>
        /// <remarks> Ramanujan approximation v3 </remarks>
        public static double Perimeter(double semiMajor, double semiMinor)
        {
            var diffMinus = semiMajor - semiMinor;
            var diffPlus = semiMajor + semiMinor;
            var h = diffMinus * diffMinus / (diffPlus * diffPlus);

            return Math.PI * (semiMajor + semiMinor) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
        }
    }
}
