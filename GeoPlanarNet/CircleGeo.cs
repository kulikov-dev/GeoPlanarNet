namespace GeoPlanarNet
{
    public static class CircleGeo
    {
        /// <summary>
        /// Get the circle area
        /// </summary>
        /// <param name="radius"> Radius </param>
        /// <returns> Area </returns>
        public static double Area(double radius)
        {
            return radius * radius * Math.PI;
        }
    }
}
