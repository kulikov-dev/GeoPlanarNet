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

        /// <summary>
        /// Find the minimal distance from a curve to a point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(PointF[] curve, PointF point)
        {
            return MinDistanceToPoint(curve, point, out _);
        }

        /// <summary>
        /// Find the minimal distance from a curve to a point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <param name="nearestPointIndex"> Index of a nearest point in the curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(PointF[] curve, PointF point, out int nearestPointIndex)
        {
            var resultLength = double.MaxValue;
            nearestPointIndex = -1;

            if (curve.Length == 1)
            {
                resultLength = PointGeo.Distance(point.X, point.Y, curve[0].X, curve[0].Y);
            }

            for (var i = 0; i < curve.Length - 1; i++)
            {
                var currentLength = PointGeo.DistanceToSegment(point.X, point.Y, curve[i].X, curve[i].Y, curve[i + 1].X, curve[i + 1].Y);

                if (currentLength < resultLength)
                {
                    resultLength = currentLength;
                    nearestPointIndex = i;
                }
            }

            return resultLength;
        }

        /// <summary>
        /// Find the minimal distance from a curve to a point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(Point[] curve, Point point)
        {
            return MinDistanceToPoint(curve, point, out _);
        }

        /// <summary>
        /// Find the minimal distance from a curve to a point
        /// </summary>
        /// <param name="curve"> Curve </param>
        /// <param name="point"> Point </param>
        /// <param name="nearestPointIndex"> Index of a nearest point in the curve </param>
        /// <returns> Minimal distance </returns>
        public static double MinDistanceToPoint(Point[] curve, Point point, out int nearestPointIndex)
        {
            var resultLength = double.MaxValue;
            nearestPointIndex = -1;

            if (curve.Length == 1)
            {
                resultLength = PointGeo.Distance(point.X, point.Y, curve[0].X, curve[0].Y);
            }

            for (var i = 0; i < curve.Length - 1; i++)
            {
                var currentLength = PointGeo.DistanceToSegment(point.X, point.Y, curve[i].X, curve[i].Y, curve[i + 1].X, curve[i + 1].Y);

                if (currentLength < resultLength)
                {
                    resultLength = currentLength;
                    nearestPointIndex = i;
                }
            }

            return resultLength;
        }
    }
}
