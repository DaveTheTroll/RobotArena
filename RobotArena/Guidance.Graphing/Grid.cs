using System;
using System.Drawing;

namespace Guidance.Graphing
{
    public class Grid
    {
        public Grid(Pen pen, RectangleF bounds, float xTick, float yTick)
        {
            this.Bounds = bounds;
            this.XTick = xTick;
            this.YTick = yTick;
            this.Pen = pen;
        }

        public RectangleF Bounds { get; private set; }
        public float XTick { get; private set; }
        public float YTick { get; private set; }
        public Pen Pen { get; private set; }

        public void Draw(Graphics g)
        {
            float xOrigin = Bounds.Left;
            float xLimit = Bounds.Right;
            float yOrigin = Math.Min(Bounds.Top, Bounds.Bottom);
            float yLimit = Math.Max(Bounds.Top, Bounds.Bottom);

            for (float x = (float)Math.Ceiling(xOrigin / XTick) * XTick; x < xLimit; x += XTick)
                g.DrawLine(Pen, x, yOrigin, x, yLimit);

            for (float y = (float)Math.Ceiling(yOrigin / YTick) * YTick; y < yLimit; y += YTick)
                g.DrawLine(Pen, xOrigin, y, xLimit, y);
        }
    }
}
