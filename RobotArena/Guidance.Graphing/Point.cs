// Point.cs

using System;
using System.Drawing;

namespace Guidance.Drawing
{
    public static class Point_Extension
    {
        public static PointF ToPointF(this Point point) { return new PointF(point.X, point.Y); }
    }
}
