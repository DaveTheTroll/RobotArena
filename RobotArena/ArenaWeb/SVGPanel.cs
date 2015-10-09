using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Drawing;
using Web.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SVGControls
{
    public class Panel : Control, INamingContainer
    {
        public Panel()
        {
            Width = 400;
            Height = 300;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute("version", "1.1");
            writer.AddAttribute("id", UniqueID);
            writer.AddAttribute("xmlns", "http://www.w3.org/2000/svg");
            writer.AddAttribute("xmlns:xlink", "http://www.w3.org/1999/xlink");
            writer.AddAttribute("x", "0px");
            writer.AddAttribute("y", "0px");
            writer.AddAttribute("width", string.Format("{0}px", Width));
            writer.AddAttribute("height", string.Format("{0}px", Height));
            writer.AddAttribute("viewBox", string.Format("0 0 {0} {1}", Width, Height));
            writer.AddAttribute("enable-background", string.Format("new 0 0 {0} {1}", Width, Height));
            writer.AddAttribute("xml:space", "preserve");
            writer.RenderBeginTag("svg");

            RenderChildren(writer);

            writer.RenderEndTag();
        }

        [DefaultValue(400)]
        public int Width { get; set; }
        [DefaultValue(300)]
        public int Height { get; set; }
    }

    public abstract class Shape : Control
    {
        public Shape()
            : this(0,0)
        {
        }

        public Shape(float x, float y)
        {
            X = x;
            Y = y;
            Fill = Color.White;
            Stroke = Color.Black;
            Rotation = 0;
            Scale = 1;
        }

        protected virtual void AddAttributes(HtmlTextWriter writer)
        {
            writer.AddAttribute("fill", Fill);
            writer.AddAttribute("stroke", Stroke);

            writer.AddAttribute("transform", string.Format("translate({0}, {1}) scale({2}) rotate({3})", X, Y, Scale, Rotation));

            writer.AddAttribute("ID", ClientID);
        }

        [DefaultValue(0)]
        public float X { get; set; }
        [DefaultValue(0)]
        public float Y { get; set; }

        [DefaultValue(typeof(Color), "White")]
        public Color Fill { get; set; }
        [DefaultValue(typeof(Color), "Black")]
        public Color Stroke { get; set; }

        [DefaultValue(0)]
        public float Rotation { get; set; }
        [DefaultValue(1)]
        public float Scale { get; set; }
    }

    public class Rectangle : Shape
    {
        public Rectangle()
        {
            Width = 100;
            Height = 100;
            StrokeMiterLimit = 10;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributes(writer);
            writer.AddAttribute("width", Width);
            writer.AddAttribute("height", Height);
            writer.AddAttribute("stroke-miterlimit", StrokeMiterLimit);
            writer.RenderBeginTag("rect");
            writer.RenderEndTag();
        }

        [DefaultValue(100)]
        public float Width { get; set; }
        [DefaultValue(100)]
        public float Height { get; set; }
        [DefaultValue(10)]
        public int StrokeMiterLimit { get; set; }
    }

    public class Text : Shape
    {
        public Text()
        {
            FontFamily = FontFamily.GenericSansSerif;
            FontSize = 12;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            // <text font-family="'Consolas'" font-size="12" id="textBlock">TESTING</text>
            AddAttributes(writer);
            writer.AddAttribute("font-family", FontFamily);
            writer.AddAttribute("font-size", FontSize);
            writer.RenderBeginTag("text");
            if (Controls.Count > 0 && Controls[0] is LiteralControl)
                writer.Write(Value);
            writer.RenderEndTag();
        }

        public string Value
        {
            get
            {
                if (Controls.Count > 0 && Controls[0] is LiteralControl)
                    return ((LiteralControl)Controls[0]).Text;
                else
                    return null;
            }
            set
            {
                if (Controls.Count > 0 && Controls[0] is LiteralControl)
                    ((LiteralControl)Controls[0]).Text = value;
                else
                {
                    Controls.Clear();
                    Controls.Add(new LiteralControl(value));
                }
            }
        }

        public FontFamily FontFamily { get; set; }
        [DefaultValue(12)]
        public int FontSize { get; set; }
    }

    public class Circle : Shape
    {
        public Circle(){Radius = 100;}

        public Circle(float x, float y, float r) : base(x, y) { Radius = r; }

        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributes(writer);
            writer.AddAttribute("r", Radius);
            writer.RenderBeginTag("circle");
            writer.RenderEndTag();
        }

        [DefaultValue(100)]
        public float Radius { get; set; }
    }

    public class Polygon : Shape
    {
        public Polygon() { }
        public Polygon(float x, float y, IEnumerable<PointF> points) : base(x, y) { Points = points; }

        public IEnumerable<PointF> Points { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributes(writer);
            writer.AddAttribute("points", string.Join(" ", from point in Points select string.Format("{0}, {1}", point.X, point.Y)));
            writer.RenderBeginTag("polygon");
            writer.RenderEndTag();
        }
    }
}
