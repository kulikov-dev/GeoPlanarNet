using System;

namespace GeoPlanarNet
{
    /// <summary>
    /// Implement global constants
    /// </summary>
    public static class GeoPlanarNet
    {
        /// <summary>
        /// Customizable epsilon tolerance
        /// </summary>
        public static double Epsilon
        {
            get
            {
                return 1E-3;
            }
        }

        public static bool AboutEquals(this float a, float b)
        {
            return Math.Abs(a - b) < Epsilon;
        }

        public static bool AboutZero(this float a)
        {
            return Math.Abs(a) < Epsilon;
        }

        public static bool AboutEquals(this double a, double b)
        {
            return Math.Abs(a - b) < Epsilon;
        }

        public static bool AboutZero(this double a)
        {
            return Math.Abs(a) < Epsilon;
        }
    }
}
