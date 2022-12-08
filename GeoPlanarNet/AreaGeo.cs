using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoPlanarNet
{
    public static class AreaGeo
    {
        /// <summary>
        /// Get area square
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Square </returns>
        public static double Square(PointF[] points)
        {
            double sum = 0;
            for (var i = 1; i < points.Length; i++)
            {
                sum += (points[i - 1].X * points[i].Y) - (points[i].X * points[i - 1].Y);
            }

            return Math.Abs(sum / 2);
        }

        /// <summary>
        /// Get area square
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Square </returns>
        public static double Square(Point[] points)
        {
            double sum = 0;
            for (var i = 1; i < points.Length; i++)
            {
                sum += (points[i - 1].X * points[i].Y) - (points[i].X * points[i - 1].Y);
            }

            return Math.Abs(sum / 2);
        }
    }
}
