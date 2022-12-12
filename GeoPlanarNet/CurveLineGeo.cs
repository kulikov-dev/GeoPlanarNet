using System.Drawing;

namespace GeoPlanarNet
{
    public class CurveLineGeo
    {
        /// <summary>
        /// Get curve length
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <returns> Length </returns>
        public static double Length(List<PointF> curve)
        {
            var length = 0d;

            for (var i = 0; i < curve.Count - 1; ++i)
            {
                length += PointGeo.Distance(curve[i], curve[i + 1]);
            }

            return length;
        }

        /// <summary>
        /// Get curve length
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <returns> Length </returns>
        public static double Length(List<Point> curve)
        {
            var length = 0d;

            for (var i = 0; i < curve.Count - 1; ++i)
            {
                length += PointGeo.Distance(curve[i], curve[i + 1]);
            }

            return length;
        }
    }
}
