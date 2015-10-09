// Line.cs

using System;
using System.Drawing;

namespace Guidance.Graphing
{
    public class LineF
    {
        public LineF() { }
        public LineF(PointF p0, PointF p1) { Point0 = p0; Point1 = p1; }
        public LineF(float x0, float y0, float x1, float y1) : this(new PointF(x0, y0), new PointF(x1, y1)) {}

        public PointF Point0 { get; set; }
        public PointF Point1 { get; set; }

        public float Gradient { get { return (Point1.Y - Point0.Y) / (Point1.X - Point0.X); } }
        public double Angle { get { return Math.Atan2(Point1.Y - Point0.Y, Point1.X - Point0.X); } }

        public LineF Intersection(RectangleF rc)
        {
            float m = Gradient;
            if (m == 0)
            {
                if (Point0.Y < rc.Bottom && Point0.Y < rc.Top)
                    return null;
                else if (Point0.Y > rc.Bottom && Point0.Y > rc.Top)
                    return null;
                else
                    return new LineF(rc.Left, Point0.Y, rc.Right, Point0.Y);
            }

            float xBottom = Point0.X + (rc.Bottom - Point0.Y) / m;
            float xTop = Point0.X + (rc.Top - Point0.Y) / m;

            float xLeft, xRight, yLeft, yRight;
            if (xBottom < xTop)
            {
                xLeft = xBottom;
                xRight = xTop;
                yLeft = rc.Bottom;
                yRight = rc.Top;
            }
            else
            {
                xLeft = xTop;
                xRight = xBottom;
                yLeft = rc.Top;
                yRight = rc.Bottom;
            }

            PointF left;
            if (xRight < rc.Left || xLeft > rc.Right)  // No intersection
                return null;
            else if (xLeft < rc.Left)  // passes through left edge
                left = new PointF(rc.Left, Point0.Y + (rc.Left - Point0.X) * m);
            else // passes through horizontal edge
                left = new PointF(xLeft, yLeft);

            PointF right;
            if (xRight < rc.Right) // passes through horizontal edge
                right = new PointF(xRight, yRight);
            else // passes through right edge
                right = new PointF(rc.Right, Point0.Y + (rc.Right - Point0.X) * m);

            return new LineF(left, right);
        }
    }
}
