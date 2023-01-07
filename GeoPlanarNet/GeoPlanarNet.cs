using System;

namespace GeoPlanarNet
{
    /// <summary>
    /// Common utils
    /// </summary>
    public static class GeoPlanarNet
    {
        /// <summary>
        /// Customizable epsilon tolerance
        /// </summary>
        public static double Epsilon => 1E-3;

        /// <summary>
        /// Right angle
        /// </summary>
        public const double RightAngle = Math.PI / 2;

        /// <summary>
        /// Check if two floating-point numbers are equal
        /// </summary>
        /// <param name="num1"> Number 1 </param>
        /// <param name="num2"> Number 2 </param>
        /// <returns> True, if equals </returns>
        public static bool AboutEquals(this float num1, float num2)
        {
            return Math.Abs(num1 - num2) < Epsilon;
        }

        /// <summary>
        /// Check if floating-point number is equal to zero
        /// </summary>
        /// <param name="num"> Number </param>
        /// <returns> True, if equal </returns>
        public static bool AboutZero(this float num)
        {
            return Math.Abs(num) < Epsilon;
        }

        /// <summary>
        /// Check if two floating-point numbers are equal
        /// </summary>
        /// <param name="num1"> Number 1 </param>
        /// <param name="num2"> Number 2 </param>
        /// <returns> True, if equals </returns>
        public static bool AboutEquals(this double num1, double num2)
        {
            return Math.Abs(num1 - num2) < Epsilon;
        }

        /// <summary>
        /// Check if floating-point number is equal to zero
        /// </summary>
        /// <param name="num"> Number </param>
        /// <returns> True, if equal </returns>
        public static bool AboutZero(this double num)
        {
            return Math.Abs(num) < Epsilon;
        }
    }
}
