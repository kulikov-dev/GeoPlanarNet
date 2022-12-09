using System.Drawing;

namespace GeoPlanarNet
{
    public static class AreaGeo
    {
        /// <summary>
        /// Get area square
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Square </returns>
        public static float Square(PointF[] points)
        {
            var sum = 0f;
            for (var i = 1; i < points.Length; i++)
            {
                sum += (points[i - 1].X * points[i].Y) - (points[i].X * points[i - 1].Y);
            }

            return Math.Abs(sum * 0.5f);
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

        /// <summary>
        /// Get a minimum point of an area
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Minumum point </returns>
        public static PointF GetMinPoint(PointF[] points)
        {
            if (points.Length == 0)
            {
                return PointF.Empty;
            }

            var result = new PointF(points[0].X, points[0].Y);

            for (var i = 1; i < points.Length; i++)
            {
                var prevPoint = points[i - 1];
                if (prevPoint.X < result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y < result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = points[i];
                if (currentPoint.X < result.X)
                {
                    result.X = currentPoint.X;
                }
                if (currentPoint.Y < result.Y)
                {
                    result.Y = currentPoint.Y;
                }
            }

            return result;
        }

        /// <summary>
        /// Get a maximum point of an area
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Maximum point </returns>
        public static PointF GetMaxPoint(PointF[] points)
        {
            if (points.Length == 0)
            {
                return PointF.Empty;
            }

            var result = new PointF(points[0].X, points[0].Y);

            for (var i = 1; i < points.Length; i++)
            {
                var prevPoint = points[i - 1];

                if (prevPoint.X > result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y > result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = points[i];

                if (currentPoint.X > result.X)
                {
                    result.X = currentPoint.X;
                }

                if (currentPoint.Y > result.Y)
                {
                    result.Y = currentPoint.Y;
                }
            }

            return result;
        }

        /// <summary>
        /// Get a minimum point of an area
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Minumum point </returns>
        public static Point GetMinPoint(Point[] points)
        {
            if (points.Length == 0)
            {
                return Point.Empty;
            }

            var result = new Point(points[0].X, points[0].Y);

            for (var i = 1; i < points.Length; i++)
            {
                var prevPoint = points[i - 1];
                if (prevPoint.X < result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y < result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = points[i];
                if (currentPoint.X < result.X)
                {
                    result.X = currentPoint.X;
                }
                if (currentPoint.Y < result.Y)
                {
                    result.Y = currentPoint.Y;
                }
            }

            return result;
        }

        /// <summary>
        /// Get a maximum point of an area
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Maximum point </returns>
        public static Point GetMaxPoint(Point[] points)
        {
            if (points.Length == 0)
            {
                return Point.Empty;
            }

            var result = new Point(points[0].X, points[0].Y);

            for (var i = 1; i < points.Length; i++)
            {
                var prevPoint = points[i - 1];

                if (prevPoint.X > result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y > result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = points[i];

                if (currentPoint.X > result.X)
                {
                    result.X = currentPoint.X;
                }

                if (currentPoint.Y > result.Y)
                {
                    result.Y = currentPoint.Y;
                }
            }

            return result;
        }

        /// <summary>
        /// Get area center point
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Center point </returns>
        public static PointF GetCenterPoint(PointF[] points)
        {
            var centerPoint = new PointF();
            var maxPoint = GetMaxPoint(points);

            var sumSquare = 0f;
            for (var i = 0; i < points.Length; i++)
            {
                var currentSquare = (float)TriangleGeo.Square(maxPoint.X, maxPoint.Y, points[i].X, points[i].Y, points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y);

                centerPoint.X += currentSquare * (maxPoint.X + points[i].X + points[(i + 1) % points.Length].X) / 3;
                centerPoint.Y += currentSquare * (maxPoint.Y + points[i].Y + points[(i + 1) % points.Length].Y) / 3;
                sumSquare += currentSquare;
            }

            centerPoint.X /= sumSquare;
            centerPoint.Y /= sumSquare;

            return centerPoint;
        }

        /// <summary>
        /// Get area center point
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Center point </returns>
        public static Point GetCenterPoint(Point[] points)
        {
            var centerPoint = new Point();
            var maxPoint = GetMaxPoint(points);

            var sumSquare = 0;
            for (var i = 0; i < points.Length; i++)
            {
                var currentSquare = (int)TriangleGeo.Square(maxPoint.X, maxPoint.Y, points[i].X, points[i].Y, points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y);

                centerPoint.X += currentSquare * (maxPoint.X + points[i].X + points[(i + 1) % points.Length].X) / 3;
                centerPoint.Y += currentSquare * (maxPoint.Y + points[i].Y + points[(i + 1) % points.Length].Y) / 3;
                sumSquare += currentSquare;
            }

            centerPoint.X /= sumSquare;
            centerPoint.Y /= sumSquare;

            return centerPoint;
        }
        
        /// <summary>
        /// Get a rectangle covering an entire area
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Rectangle </returns>
        public static RectangleF GetRectangle(PointF[] points)
        {
            var xMin = float.MaxValue;
            var xMax = -float.MaxValue;
            var yMin = float.MaxValue;
            var yMax = -float.MaxValue;

            foreach (var point in points)
            {
                xMin = Math.Min(xMin, point.X);
                xMax = Math.Max(xMax, point.X);
                yMin = Math.Min(yMin, point.Y);
                yMax = Math.Max(yMax, point.Y);
            }

            return new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin);
        }

        /// <summary>
        /// Get a rectangle covering an entire area
        /// </summary>
        /// <param name="points"> Area </param>
        /// <returns> Rectangle </returns>
        public static Rectangle GetRectangle(Point[] points)
        {
            var xMin = int.MaxValue;
            var xMax = -int.MaxValue;
            var yMin = int.MaxValue;
            var yMax = -int.MaxValue;

            foreach (var point in points)
            {
                xMin = Math.Min(xMin, point.X);
                xMax = Math.Max(xMax, point.X);
                yMin = Math.Min(yMin, point.Y);
                yMax = Math.Max(yMax, point.Y);
            }

            return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
        }
    }
}
