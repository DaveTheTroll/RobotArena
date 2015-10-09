using System;
using System.Drawing;
using System.Collections.Generic;

namespace Guidance.Graphing
{
    public static class PlotLine
    {
        public static void Plot(this Graphics g, Pen pen, float[] x, float[] y)
        {
            List<PointF> points = MakePointList(x, y);
            if (points.Count > 1)
                g.DrawLines(pen, points.ToArray());
        }

        static List<PointF> MakePointList(float[] x, float[] y)
        {
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < x.Length; i++)
                points.Add(new PointF(x[i], y[i]));
            return points;
        }
    }
}
