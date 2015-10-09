// PointF.cs

using System;
using System.Drawing;

namespace Guidance.Drawing
{
    public static class PointF_Extension
    {
        public static PointF NaN { get { return new PointF(float.NaN, float.NaN); } }

        public static bool IsNaN(this PointF point) { return float.IsNaN(point.X) || float.IsNaN(point.Y); }

        public static SizeF Difference(PointF a, PointF b) { return new SizeF(a.X - b.X, a.Y - b.Y); }
        public static PointF Sum(PointF a, PointF b) { return new PointF(a.X + b.X, a.Y + b.Y); }
    }
}
