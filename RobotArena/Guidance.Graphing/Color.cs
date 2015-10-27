using System;
using System.Drawing;

namespace Guidance.Drawing
{
    public static class Color_Extension
    {
        public static Color Parse(string str)
        {
            if (str.Length > 0 && str[0] == '#')
            {
                switch (str.Length)
                {
                    case 4: // Hex 3 - e.g. #888
                        return Color.FromArgb(Convert.ToInt32(str.Substring(1, 1), 16) * 0x11, Convert.ToInt32(str.Substring(2, 1), 16) * 0x11, Convert.ToInt32(str.Substring(3, 1), 16) * 0x11);
                    case 7: // Hex 6 - e.g. #FF0000
                        return Color.FromArgb(Convert.ToInt32(str.Substring(1, 2), 16), Convert.ToInt32(str.Substring(3, 2), 16), Convert.ToInt32(str.Substring(5, 2), 16));
                    case 9: // Hex 8 - e.g. #80FF0000
                        return Color.FromArgb(Convert.ToInt32(str.Substring(1, 2), 16), Convert.ToInt32(str.Substring(3, 2), 16), Convert.ToInt32(str.Substring(5, 2), 16), Convert.ToInt32(str.Substring(7, 2), 16));
                }
            }

            Color color = Color.FromName(str);
            if (!(color.R == 0 && color.G == 0 && color.B==0 && color.A == 0))
                return color;

            throw new FormatException("Unknown Color");
        }

        public static string ToParseString(this Color color)
        {
            if (color.IsNamedColor)
                return color.Name;
            else
                return string.Format("#{0:X8}", color.ToArgb());
        }
    }
}

