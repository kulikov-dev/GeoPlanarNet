namespace GeoPlanarNet
{
    /// <summary>
    /// Supporting methods for library
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Convert radian to degree
        /// </summary>
        /// <param name="angleRadian"> Angle in radians </param>
        /// <returns> Angle in radians </returns>
        public static double ConvertRadianToDegree(double angleRadian)
        {
            return angleRadian * 180 / Math.PI;
        }

        /// <summary>
        /// Convert degree to rad
        /// </summary>
        /// <param name="angleDegree"> Angle in degree </param>
        /// <returns> Angle in degree </returns>
        public static double ConvertDegreeToRad(double angleDegree)
        {
            return angleDegree * Math.PI / 180;
        }
    }
}
