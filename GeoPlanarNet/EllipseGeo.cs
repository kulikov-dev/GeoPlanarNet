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
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(PointF ellipseCenter, float radiusX, float radiusY)
        {
            return Area(ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY);
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(Point ellipseCenter, int radiusX, int radiusY)
        {
            return Area(ellipseCenter.X, ellipseCenter.Y, radiusX, radiusY);
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="radiusX"> Radius on X axis </param>
        /// <param name="radiusY"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double Area(double ellipseCenterX, double ellipseCenterY, double radiusX, double radiusY)
        {
            return Math.PI * radiusX * radiusY;
        }
    }
}
