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
        public static double Tolerance
        {
            get
            {
                return 1E-3;
            }
        }

        public static bool AboutEquals(this float a, float b)
        {
            return Math.Abs(a - b) < GeoPlanarNet.Tolerance;
        }

        public static bool AboutZero(this float a)
        {
            return Math.Abs(a) < GeoPlanarNet.Tolerance;
        }
    }
}
