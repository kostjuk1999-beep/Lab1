using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public class LissajousModel
    {
        public List<Point> Calculate(double ax, double ay, double fx, double fy, double phiX, double phiY, double step)
        {
            var points = new List<Point>();

            double radX = phiX * Math.PI / 180.0;
            double radY = phiY * Math.PI / 180.0;
            double tMax = 10.0;

            for (double t = 0; t <= tMax; t += step)
            {
                double x = ax * Math.Sin(2 * Math.PI * fx * t + radX);
                double y = ay * Math.Sin(2 * Math.PI * fy * t + radY);

                points.Add(new Point(x + 200, y + 150));
            }
            return points;
        }
    }
}