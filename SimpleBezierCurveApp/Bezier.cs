using System;
using System.Collections.Generic;

namespace SimpleBezierCurveApp
{
    public static class Bezier
    {
        /// <summary>
        /// The method returns an array of Bezier curve points
        /// </summary>
        /// <param name="points">curve control points</param>
        /// <param name="step">step between points</param>
        /// <returns></returns>
        public static Point[] GetCurvePoints(Point[] points, double step = 0.005d)
        {
            if (points == null)
            {
                throw new ArgumentNullException("Points array cannot be null");
            }
            if (points.Length <= 1)
            {
                return points;
            }

            List<Point> result = new List<Point>();
            var n = points.Length;

            for (double t = 0.0; t < 1.0; t += step)
            {
                var x = 0.0;
                var y = 0.0;
                for (int k = 0; k < n; k++)
                {
                    var multi = MathHelper.C(n - 1, k) * Math.Pow(1 - t, n - 1 - k) * Math.Pow(t, k);
                    x += multi * points[k].X;
                    y += multi * points[k].Y;
                }

                result.Add(new Point(x, y));
            }

            return result.ToArray();
        }
    }
}
