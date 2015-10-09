using System;
using System.Drawing;
using Guidance.Drawing;

namespace Guidance.Graphing
{
    public abstract class Marker
    {
        public abstract void Draw(Graphics g, float x, float y);
        public void Draw(Graphics g, float[] x, float[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("Marker.Draw requires equal length arrays");
            for (int i = 0; i < x.Length; i++)
                Draw(g, x[i], y[i]);
        }
    }

    public class CircleMarker : Marker
    {
        public CircleMarker(Color color, float radius)
        {
            brush = new SolidBrush(color);
            Radius = radius;
        }

        SolidBrush brush;

        public Color Color { get { return brush.Color; } }
        public float Radius { get; private set; }

        public override void Draw(Graphics g, float x, float y) { g.FillCircle(brush, x, y, Radius); }
    }

    public class PlusMarker : Marker
    {
        public PlusMarker(Pen pen, float width)
        {
            Pen = pen;
            Width = width;
        }

        public Pen Pen { get; set; }
        public float Width { get; private set; }

        public override void Draw(Graphics g, float x, float y)
        {
            g.DrawLine(Pen, x - Width / 2, y, x + Width / 2, y);
            g.DrawLine(Pen, x, y - Width / 2, x, y + Width / 2);
        }
    }
}
