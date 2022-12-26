using System;

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

        /// <summary>
        /// Check if a dot located between an interval
        /// </summary>
        /// <param name="dot"> Dot </param>
        /// <param name="intervalStart"> Left point of the interval </param>
        /// <param name="intervalEnd"> Right point of the interval </param>
        /// <returns> Flag if dot between interval </returns>
        public static bool CheckDotBetweenInterval(double dot, double intervalStart, double intervalEnd)
        {
            if (intervalStart < intervalEnd)
            {
                return dot >= intervalStart && dot <= intervalEnd;
            }

            return dot <= intervalStart && dot >= intervalEnd;
        }
    }
}
