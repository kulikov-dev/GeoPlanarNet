﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace GeoPlanarNet
{
    /// <summary>
    /// Class for manipulations with the surface
    /// </summary>
    public static class SurfaceGeo
    {
        /// <summary>
        /// Get the surface area
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Area </returns>
        public static float GetArea(PointF[] surface)
        {
            var sum = 0f;

            for (var i = 1; i < surface.Length; i++)
            {
                sum += surface[i - 1].X * surface[i].Y - surface[i].X * surface[i - 1].Y;
            }

            return Math.Abs(sum * 0.5f);
        }

        /// <summary>
        /// Get the surface area
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Area </returns>
        public static double GetArea(Point[] surface)
        {
            double sum = 0;

            for (var i = 1; i < surface.Length; i++)
            {
                sum += surface[i - 1].X * surface[i].Y - surface[i].X * surface[i - 1].Y;
            }

            return Math.Abs(sum / 2);
        }

        /// <summary>
        /// Get the minimum point of the surface
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Minimum point </returns>
        public static PointF GetMinPoint(PointF[] surface)
        {
            if (surface.Length == 0)
            {
                return PointF.Empty;
            }

            var result = new PointF(surface[0].X, surface[0].Y);

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];

                if (prevPoint.X < result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y < result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = surface[i];

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
        /// Get the maximum point of the surface
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Maximum point </returns>
        public static PointF GetMaxPoint(PointF[] surface)
        {
            if (surface.Length == 0)
            {
                return PointF.Empty;
            }

            var result = new PointF(surface[0].X, surface[0].Y);

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];

                if (prevPoint.X > result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y > result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = surface[i];

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
        /// Get the minimum point of the surface
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Minimum point </returns>
        public static Point GetMinPoint(Point[] surface)
        {
            if (surface.Length == 0)
            {
                return Point.Empty;
            }

            var result = new Point(surface[0].X, surface[0].Y);

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];

                if (prevPoint.X < result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y < result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = surface[i];

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
        /// Get the maximum point of the surface
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Maximum point </returns>
        public static Point GetMaxPoint(Point[] surface)
        {
            if (surface.Length == 0)
            {
                return Point.Empty;
            }

            var result = new Point(surface[0].X, surface[0].Y);

            for (var i = 1; i < surface.Length; i++)
            {
                var prevPoint = surface[i - 1];

                if (prevPoint.X > result.X)
                {
                    result.X = prevPoint.X;
                }

                if (prevPoint.Y > result.Y)
                {
                    result.Y = prevPoint.Y;
                }

                var currentPoint = surface[i];

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
        /// Get the surface center point
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Center point </returns>
        public static PointF GetCenterPoint(PointF[] surface)
        {
            if (surface.Length == 0)
            {
                return PointF.Empty;
            }

            var centerPoint = new PointF();
            var maxPoint = GetMaxPoint(surface);

            var sumSquare = 0f;

            for (var i = 0; i < surface.Length; i++)
            {
                var currentSquare = (float)TriangleGeo.Area(maxPoint.X, maxPoint.Y, surface[i].X, surface[i].Y, surface[(i + 1) % surface.Length].X, surface[(i + 1) % surface.Length].Y);

                centerPoint.X += currentSquare * (maxPoint.X + surface[i].X + surface[(i + 1) % surface.Length].X) / 3;
                centerPoint.Y += currentSquare * (maxPoint.Y + surface[i].Y + surface[(i + 1) % surface.Length].Y) / 3;
                sumSquare += currentSquare;
            }

            if (sumSquare.AboutZero())
            {
                return PointF.Empty;
            }

            centerPoint.X /= sumSquare;
            centerPoint.Y /= sumSquare;

            return centerPoint;
        }

        /// <summary>
        /// Get the surface center point
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Center point </returns>
        public static Point GetCenterPoint(Point[] surface)
        {
            if (surface.Length == 0)
            {
                return Point.Empty;
            }

            var centerPoint = new Point();
            var maxPoint = GetMaxPoint(surface);

            var sumSquare = 0;

            for (var i = 0; i < surface.Length; i++)
            {
                var currentSquare = (int)TriangleGeo.Area(maxPoint.X, maxPoint.Y, surface[i].X, surface[i].Y, surface[(i + 1) % surface.Length].X, surface[(i + 1) % surface.Length].Y);

                centerPoint.X += currentSquare * (maxPoint.X + surface[i].X + surface[(i + 1) % surface.Length].X) / 3;
                centerPoint.Y += currentSquare * (maxPoint.Y + surface[i].Y + surface[(i + 1) % surface.Length].Y) / 3;
                sumSquare += currentSquare;
            }

            if (sumSquare == 0)
            {
                return Point.Empty;
            }

            centerPoint.X /= sumSquare;
            centerPoint.Y /= sumSquare;

            return centerPoint;
        }

        /// <summary>
        /// Get the rectangle covering the entire surface
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Rectangle </returns>
        public static RectangleF GetAABB(PointF[] surface)
        {
            var xMin = float.MaxValue;
            var xMax = -float.MaxValue;
            var yMin = float.MaxValue;
            var yMax = -float.MaxValue;

            foreach (var point in surface)
            {
                xMin = Math.Min(xMin, point.X);
                xMax = Math.Max(xMax, point.X);
                yMin = Math.Min(yMin, point.Y);
                yMax = Math.Max(yMax, point.Y);
            }

            return new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin);
        }

        /// <summary>
        /// Get the rectangle covering the entire surface
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <returns> Rectangle </returns>
        public static Rectangle GetAABB(Point[] surface)
        {
            var xMin = int.MaxValue;
            var xMax = -int.MaxValue;
            var yMin = int.MaxValue;
            var yMax = -int.MaxValue;

            foreach (var point in surface)
            {
                xMin = Math.Min(xMin, point.X);
                xMax = Math.Max(xMax, point.X);
                yMin = Math.Min(yMin, point.Y);
                yMax = Math.Max(yMax, point.Y);
            }

            return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
        }

        /// <summary>
        /// Get shortest distance from the surface to the point
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance to the point </returns>
        public static double DistanceToPoint(PointF[] surface, PointF point)
        {
            return point.DistanceToSurface(surface);
        }

        /// <summary>
        /// Get shortest distance from the surface to the point
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <param name="point"> Point </param>
        /// <returns> Distance to the point </returns>
        public static double DistanceToPoint(Point[] surface, Point point)
        {
            return point.DistanceToSurface(surface);
        }

        /// <summary>
        /// Check if the surface contains the point
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the surface contains the point </returns>
        public static bool Contains(IList<PointF> surface, PointF point)
        {
            return point.BelongsToSurface(surface);
        }

        /// <summary>
        /// Check if the surface contains the point
        /// </summary>
        /// <param name="surface"> Surface </param>
        /// <param name="point"> Point </param>
        /// <returns> True, if the surface contains the point </returns>
        public static bool Contains(IList<Point> surface, Point point)
        {
           return point.BelongsToSurface(surface);
        }
    }
}
