using System;
using System.Web.UI;
using System.Drawing;

namespace Web.Extensions
{
    public static class HtmlTextWriter_Extension
    {
        public static void AddAttribute(this HtmlTextWriter writer, string key, object value) { writer.AddAttribute(key, value.ToString()); }
        public static void AddAttribute(this HtmlTextWriter writer, string key, Color value) { writer.AddAttribute(key, HexColor(value)); }

        static string HexColor(Color color) { return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B); }
    }
}
