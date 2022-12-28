using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GeoPlanarNet
{
    public static class EllipseGeo
    {
        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(float radiusX, float radiusY)
        {
            return Math.PI * radiusX * radiusY;
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(int radiusX, int radiusY)
        {
            return Math.PI * radiusX * radiusY;
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(double radiusX, double radiusY)
        {
            return Math.PI * radiusX * radiusY;
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double Eccentricity(float radiusX, float radiusY)
        {
            var semiMajor = radiusX * radiusX;
            var semiMinor = radiusY * radiusY;

            return Math.Sqrt(1 - semiMinor / semiMajor);
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double Eccentricity(int radiusX, int radiusY)
        {
            var semiMajor = radiusX * radiusX;
            var semiMinor = radiusY * radiusY;

            return Math.Sqrt(1 - semiMinor / semiMajor);
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double Eccentricity(double radiusX, double radiusY)
        {
            var semiMajor = radiusX * radiusX;
            var semiMinor = radiusY * radiusY;

            return Math.Sqrt(1 - semiMinor / semiMajor);
        }
    }
}
