// RectangeF.cs

using System;
using System.Drawing;

namespace Guidance.Drawing
{
    public static class RectangleF_Extension
    {
        public static RectangleF NaN { get { return new RectangleF(float.NaN, float.NaN, float.NaN, float.NaN); } }

        public static RectangleF InflatedToContain(this RectangleF rectangle, double x, double y)
        {
            return rectangle.InflatedToContain(new PointF((float)x, (float)y));
        }

        public static RectangleF InflatedToContain(this RectangleF rectangle, PointF point)
        {
            if (float.IsNaN(rectangle.X))
                rectangle.X = point.X;
            else if (float.IsNaN(rectangle.Width))
            {
                if (rectangle.X < point.X)
                    rectangle = rectangle.SetRight(point.X);
                else
                {
                    rectangle.Width = rectangle.X - point.X;
                    rectangle.X = point.X;
                }
            }
            else if (point.X < rectangle.Left)
                rectangle = rectangle.SetLeft(point.X);
            else if (point.X > rectangle.Right)
                rectangle = rectangle.SetRight(point.X);

            if (float.IsNaN(rectangle.Y))
                rectangle.Y = point.Y;
            else if (float.IsNaN(rectangle.Height))
            {
                if (rectangle.Y < point.Y)
                    rectangle = rectangle.SetBottom(point.Y);
                else
                {
                    rectangle.Height = rectangle.Y - point.Y;
                    rectangle.Y = point.Y;
                }
            }
            else if (point.Y < rectangle.Top)
                rectangle = rectangle.SetTop(point.Y);
            else if (point.Y > rectangle.Bottom)
                rectangle = rectangle.SetBottom(point.Y);

            return rectangle;
        }

        public static RectangleF SetLeft(this RectangleF rectangle, float value)
        {
            rectangle.Width = rectangle.Right - value;
            rectangle.X = value;
            return rectangle;
        }

        public static RectangleF SetRight(this RectangleF rectangle, float value)
        {
            rectangle.Width = value - rectangle.Left;
            return rectangle;
        }

        public static RectangleF SetTop(this RectangleF rectangle, float value)
        {
            rectangle.Height = rectangle.Bottom - value;
            rectangle.Y = value;
            return rectangle;
        }

        public static RectangleF SetBottom(this RectangleF rectangle, float value)
        {
            rectangle.Height = value - rectangle.Top;
            return rectangle;
        }

        public static bool IsNaN(this RectangleF rectangle) { return float.IsNaN(rectangle.X) || float.IsNaN(rectangle.Y) || float.IsNaN(rectangle.Width) || float.IsNaN(rectangle.Height); }

        public static PointF GetCenter(this RectangleF rectangle) { return new PointF(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2); }

        public static PointF GetBottomRight(this RectangleF rectangle) { return new PointF(rectangle.Right, rectangle.Bottom); }
    }
}
