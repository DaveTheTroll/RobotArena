// Panel.cs

using System;
using System.ComponentModel;
using SWF = System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using Guidance.Drawing;
using System.Windows.Forms;

namespace Guidance.Windows.Forms
{
    public class ScalingPanel : SWF.Panel
    {
        public ScalingPanel()
        {
            SetStyle(SWF.ControlStyles.Selectable, true);   // To allow MouseWheel.
            TabStop = true;
            DoubleBuffered = true;
            SmoothingMode = SmoothingMode.AntiAlias;
            InvalidateOnResize = true;
            DrawLimits = RectangleF_Extension.NaN;
            YUp = true;
            DrawBorder = 0;
            Zoomable = true;
            Pannable = true;
        }

        [DefaultValue(true)]
        public new bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        [DefaultValue(typeof(SmoothingMode), "AntiAlias")]
        public SmoothingMode SmoothingMode { get; set; }

        [DefaultValue(true)]
        public bool InvalidateOnResize { get; set; }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (InvalidateOnResize)
                Invalidate();
        }

        public RectangleF DrawLimits { get; set; }

        public void IncludePoint(PointF point) { DrawLimits = DrawLimits.InflatedToContain(point); }
        public void IncludePoint(float x, float y) { IncludePoint(new PointF(x, y)); }

        [DefaultValue(true)]
        public bool YUp { get; set; }

        [DefaultValue(0.0f)]
        public float DrawBorder { get; set; }

        [DefaultValue(true)]
        public bool Zoomable { get; set; }
        [DefaultValue(true)]
        public bool Pannable { get; set; }

        float zoom = 1;
        [DefaultValue(1.0f)]
        public float Zoom
        {
            get { return zoom; }
            set
            {
                if (value > 0 && zoom != value)
                {
                    zoom = value;
                    Invalidate();
                }
            }
        }

        PointF offset = new PointF(0, 0);
        public PointF Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                Invalidate();
            }
        }

        public void CentreOn(PointF pnt)
        {
            PointF drawCenter = BoundLimits.GetCenter();
            offset = new PointF(-pnt.X + drawCenter.X, -pnt.Y + drawCenter.Y);
            Invalidate();
        }

        public RectangleF BoundLimits
        {
            get
            {
                RectangleF limits = DrawLimits;
                limits.Inflate(DrawBorder, DrawBorder);
                return limits;
            }
        }

        public RectangleF PanelLimits
        {
            get
            {
                if (DrawLimits.IsNaN())
                    return BoundLimits;

                Matrix transform = Transform;
                transform.Invert();
                RectangleF rc = ClientRectangle.ToRectangleF();
                PointF[] points = new PointF[] {rc.Location, rc.GetBottomRight()};
                transform.TransformPoints(points);
                return new RectangleF(points[0], PointF_Extension.Difference(points[1], points[0]));
            }
        }

        public float DrawScale { get { return Zoom * Math.Min(Width / BoundLimits.Width, Height / BoundLimits.Height); } }

        protected override void OnPaint(SWF.PaintEventArgs e)
        {
            Matrix defaultTransform = e.Graphics.Transform;
            try
            {
                PrepareGraphics(e.Graphics);
                base.OnPaint(e);
                if (Focused)
                {
                    Matrix transform = e.Graphics.Transform;
                    e.Graphics.Transform = defaultTransform;
                    Rectangle rc = ClientRectangle;
                    rc.Inflate(-2, -2);
                    SWF.ControlPaint.DrawFocusRectangle(e.Graphics, rc);
                    e.Graphics.Transform = transform;
                }
            }
            catch (Exception ex)
            {
                e.Graphics.Transform = defaultTransform;
                e.Graphics.DrawString(ex.ToString(), Font, Brushes.Black, 5, 5);
            }
        }

        Matrix Transform
        {
            get
            {
                float scale = DrawScale;

                PointF drawCenter = BoundLimits.GetCenter();
                PointF panelCenter = new PointF(Width / 2, Height / 2);

                Matrix transform = new Matrix(new RectangleF(drawCenter, new SizeF(1, 1)),
                    new PointF[] { panelCenter, new PointF(panelCenter.X + scale, panelCenter.Y), new PointF(panelCenter.X, panelCenter.Y + (YUp ? -scale : scale)) });
                transform.Translate(offset.X, offset.Y);
                return transform;
            }
        }

        void PrepareGraphics(Graphics g)
        {
            if (!DrawLimits.IsNaN() && DrawLimits.Width > 0 && DrawLimits.Height > 0)
                g.Transform = Transform;

            g.SmoothingMode = SmoothingMode;
        }

        public Pen GetPen(Color color, float pixelWidth) { return new Pen(color, pixelWidth / DrawScale); }

        public PointF PixelToPoint(Point pixel)
        {
            if (DrawLimits.IsNaN())
                return PointF_Extension.NaN;
            else
            {
                Matrix transform = Transform;
                PointF[] points = new PointF[] { pixel.ToPointF() };
                transform.Invert();
                transform.TransformPoints(points);
                return points[0];
            }
        }

        public event CancelEventHandler DraggingStart;

        PointF dragCentre = PointF_Extension.NaN;
        protected override void OnMouseDown(SWF.MouseEventArgs e)
        {
            Focus();
            CancelEventArgs dragging = new CancelEventArgs(false);
            if (DraggingStart != null)
                DraggingStart(this, dragging);

            if (Pannable && !dragging.Cancel)
            {
                dragCentre = PixelToPoint(e.Location);
                HasDragged = false;
            }
            base.OnMouseDown(e);
        }

        public bool IsDragging { get { return !dragCentre.IsNaN(); } }
        public bool HasDragged { get; private set; }

        protected override void OnMouseMove(SWF.MouseEventArgs e)
        {
            if (IsDragging)
            {
                PointF dragNow = PixelToPoint(e.Location);
                if (dragNow != dragCentre)
                {
                    HasDragged = true;
                    Offset = new PointF(Offset.X + dragNow.X - dragCentre.X, Offset.Y + dragNow.Y - dragCentre.Y);
                    dragCentre = PixelToPoint(e.Location);
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(SWF.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragCentre = PointF_Extension.NaN;
        }

        protected override void OnMouseClick(SWF.MouseEventArgs e)
        {
            if (!HasDragged)
                base.OnMouseClick(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Invalidate();
            base.OnLeave(e);
        }

        protected override void OnMouseWheel(SWF.MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (Zoomable)
            {
                PointF locationAtOldZoom = PixelToPoint(e.Location);

                float newZoom = Zoom * (float)Math.Pow(1.25, e.Delta / 120);
                Zoom = Math.Max(newZoom, 1);

                PointF locationAtNewZoom = PixelToPoint(e.Location);

                Offset = new PointF(Offset.X + locationAtNewZoom.X - locationAtOldZoom.X, Offset.Y + locationAtNewZoom.Y - locationAtOldZoom.Y);
            }
        }
        private void ChangeZoom(float delta)
        {
            if (Zoomable)
            {
                PointF locationAtOldZoom = PixelToPoint(new Point(0,0));

                float newZoom = Zoom * (float)Math.Pow(1.25, delta / 120);
                Zoom = Math.Max(newZoom, 1);

                PointF locationAtNewZoom = PixelToPoint(new Point(0, 0));

                Offset = new PointF(Offset.X + locationAtNewZoom.X - locationAtOldZoom.X, Offset.Y + locationAtNewZoom.Y - locationAtOldZoom.Y);
            }
        }
        protected override void OnKeyPress(SWF.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.A )
            {
                ChangeZoom(120);
                e.Handled = true;
            }
            if( e.KeyChar == (char)Keys.Z)
            {
                ChangeZoom(-120);
                e.Handled = true;
            }
        }

        public void DrawGrid(Graphics g, Pen pen, float spacing)
        {
            Graphing.Grid grid = new Graphing.Grid(pen, PanelLimits, spacing, spacing);
            grid.Draw(g);
        }
    }
}
