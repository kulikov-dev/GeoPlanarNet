using System;
using System.Drawing;

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
        public static double GetArea(float semiMajor, float semiMinor)
        {
            return GetArea((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double GetArea(int semiMajor, int semiMinor)
        {
            return GetArea((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse area
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Area </returns>
        public static double GetArea(double semiMajor, double semiMinor)
        {
            return Math.PI * semiMajor * semiMinor;
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double GetEccentricity(float semiMajor, float semiMinor)
        {
            return GetEccentricity((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double GetEccentricity(int semiMajor, int semiMinor)
        {
            return GetEccentricity((double)semiMajor, semiMinor);
        }

        /// <summary>
        /// Get the ellipse eccentricity
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Eccentricity </returns>
        public static double GetEccentricity(double semiMajor, double semiMinor)
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
        public static double GetPerimeter(float semiMajor, float semiMinor)
        {
            return GetPerimeter(semiMajor, (double)semiMinor);
        }

        /// <summary>
        /// Get the ellipse perimeter
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Perimeter </returns>
        /// <remarks> Ramanujan approximation v3 </remarks>
        public static double GetPerimeter(int semiMajor, int semiMinor)
        {
            return GetPerimeter(semiMajor, (double)semiMinor);
        }

        /// <summary>
        /// Get the ellipse perimeter
        /// </summary>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <returns> Perimeter </returns>
        /// <remarks> Ramanujan approximation v3 </remarks>
        public static double GetPerimeter(double semiMajor, double semiMinor)
        {
            var diffMinus = semiMajor - semiMinor;
            var diffPlus = semiMajor + semiMinor;
            var h = diffMinus * diffMinus / (diffPlus * diffPlus);

            return Math.PI * (semiMajor + semiMinor) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
        }

        #region Contains

        /// <summary>
        /// Check if the axis-parallel ellipse contains the point
        /// </summary>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the axis-parallel ellipse contains the point </returns>
        public static bool Contains(PointF ellipseCenter, float semiMajor, float semiMinor, PointF point)
        {
            return point.BelongsToEllipse(ellipseCenter, semiMajor, semiMinor);
        }

        /// <summary>
        /// Check if the axis-parallel ellipse contains the point
        /// </summary>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the axis-parallel ellipse contains the point </returns>
        public static bool Contains(Point ellipseCenter, int semiMajor, int semiMinor, Point point)
        {
            return point.BelongsToEllipse(ellipseCenter, semiMajor, semiMinor);
        }

        /// <summary>
        /// Check if the axis-parallel ellipse contains the point
        /// </summary>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the axis-parallel ellipse contains the point </returns>
        public static bool Contains(double ellipseCenterX, double ellipseCenterY, double semiMajor, double semiMinor, double pointX, double pointY)
        {
            return PointGeo.BelongsToEllipse(pointX, pointY, ellipseCenterX, ellipseCenterY, semiMajor, semiMinor);
        }

        /// <summary>
        /// Check if the axis-parallel ellipse sector contains the point
        /// </summary>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the axis-parallel ellipse sector contains the point </returns>
        public static bool Contains(PointF ellipseCenter, float semiMajor, float semiMinor, float sectorStartAngleRad, float sectorEndAngleRad, PointF point)
        {
            return PointGeo.BelongsToEllipseSector(point, ellipseCenter, semiMajor, semiMinor, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the axis-parallel ellipse sector contains the point
        /// </summary>
        /// <param name="ellipseCenter"> Ellipse center </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the axis-parallel ellipse sector contains the point </returns>
        public static bool Contains(Point ellipseCenter, int semiMajor, int semiMinor, int sectorStartAngleRad, int sectorEndAngleRad, Point point)
        {
            return PointGeo.BelongsToEllipseSector(point, ellipseCenter, semiMajor, semiMinor, sectorStartAngleRad, sectorEndAngleRad);
        }

        /// <summary>
        /// Check if the axis-parallel ellipse sector contains the point
        /// </summary>
        /// <param name="ellipseCenterX"> Ellipse center: X coordinate </param>
        /// <param name="ellipseCenterY"> Ellipse center: Y coordinate </param>
        /// <param name="semiMajor"> Radius on X axis </param>
        /// <param name="semiMinor"> Radius on Y axis </param>
        /// <param name="sectorStartAngleRad"> Circle sector start angle (radians) </param>
        /// <param name="sectorEndAngleRad"> Circle sector end angle (radians) </param>
        /// <param name="pointX"> Point: X coordinate </param>
        /// <param name="pointY"> Point: Y coordinate </param>
        /// <returns> True, if the axis-parallel ellipse sector contains the point </returns>
        public static bool Contains(double ellipseCenterX, double ellipseCenterY, double semiMajor, double semiMinor, double sectorStartAngleRad, double sectorEndAngleRad, double pointX, double pointY)
        {
            return PointGeo.BelongsToEllipseSector(pointX, pointY, ellipseCenterX, ellipseCenterY, semiMajor, semiMinor, sectorStartAngleRad, sectorEndAngleRad);
        }

        #endregion
    }
}
