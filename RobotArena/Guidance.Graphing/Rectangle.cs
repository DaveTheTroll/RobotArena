// Rectangle.cs

using System;
using System.Drawing;

namespace Guidance.Drawing
{
    public static class Rectangle_Extension
    {
        public static Point GetCenter(this Rectangle rectangle) { return new Point(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2); }
        public static PointF GetCenterF(this Rectangle rectangle) { return new PointF(rectangle.Left + rectangle.Width / 2.0f, rectangle.Top + rectangle.Height / 2.0f); }
        public static RectangleF ToRectangleF(this Rectangle rectangle) { return new RectangleF(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height); }
    }
}
