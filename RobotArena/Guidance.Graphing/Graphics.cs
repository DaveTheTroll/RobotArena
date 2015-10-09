// Graphics.cs

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Guidance.Drawing
{
    public static class Graphics_Extension
    {
        #region Circle
        public static void FillCircle(this Graphics g, Brush brush, PointF centre, float radius) { g.FillCircle(brush, centre.X, centre.Y, radius); }
        public static void FillCircle(this Graphics g, Brush brush, float x, float y, float radius) { g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2); }
        public static void DrawCircle(this Graphics g, Pen pen, PointF centre, float radius) { g.DrawCircle(pen, centre.X, centre.Y, radius); }
        public static void DrawCircle(this Graphics g, Pen pen, float x, float y, float radius) { g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2); }
        #endregion

        #region Pose
        public static void FillPose(this Graphics g, Brush brush, PointF location, float heading, float length, float width, float indent) { g.FillPose(brush, location.X, location.Y, heading, width, length, indent); }
        public static void FillPose(this Graphics g, Brush brush, float x, float y, float heading, float length, float width, float indent) { g.FillPolygon(brush, PosePoints(x, y, heading, length, width, indent)); }
        public static void DrawPose(this Graphics g, Pen pen, float x, float y, float heading, float length, float width, float indent) { g.DrawPolygon(pen, PosePoints(x, y, heading, length, width, indent)); }
        static PointF[] PosePoints(float x, float y, float heading, float length, float width, float indent)
        {
            PointF[] points = new PointF[4];
            points[0] = new PointF(x, y);
            points[1] = new PointF((float)(x - length * Math.Cos(heading) - width * Math.Sin(heading) / 2), (float)(y - length * Math.Sin(heading) + width * Math.Cos(heading) / 2));
            points[2] = new PointF((float)(x - (length - indent) * Math.Cos(heading)), (float)(y - (length - indent) * Math.Sin(heading)));
            points[3] = new PointF((float)(x - length * Math.Cos(heading) + width * Math.Sin(heading) / 2), (float)(y - length * Math.Sin(heading) - width * Math.Cos(heading) / 2));
            return points;
        }
        public static void FillPose(this Graphics g, Brush brush, float x, float y, float heading, float size) { g.FillPose(brush, x, y, heading, size, size / 2, size / 3); }
        public static void FillPose(this Graphics g, Brush brush, PointF location, float heading, float size) { g.FillPose(brush, location.X, location.Y, heading, size); }
        public static void DrawPose(this Graphics g, Pen pen, float x, float y, float heading, float size) { g.DrawPose(pen, x, y, heading, size, size / 2, size / 3); }
        public static void DrawPose(this Graphics g, Pen pen, PointF location, float heading, float size) { g.DrawPose(pen, location.X, location.Y, heading, size); }
        #endregion

        #region String
        public static void DrawStringFlipped(this Graphics g, string s, Font font, Brush brush, float x, float y)
        {
            GraphicsState gs = g.Save();

            SizeF stringSize = g.MeasureString(s, font);
            PointF[] points = new PointF[] { new PointF(x, y), new PointF(x + stringSize.Width, y), new PointF(x, y - stringSize.Height) };
            g.Transform.TransformPoints(points);
            Matrix flippedTransform = new Matrix(new RectangleF(new PointF(0, 0), stringSize), points);

            g.Transform = flippedTransform;
            g.DrawString(s, font, brush, 0, 0);
            g.Restore(gs);
        }
        #endregion

        #region Line
        public static void DrawLine(this Graphics g, Pen pen, double x1, double y1, double x2, double y2) { g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2); }
        public static void DrawLine(this Graphics g, Pen pen, Guidance.Graphing.LineF line) { g.DrawLine(pen, line.Point0, line.Point1); }
        #endregion
    }
}
