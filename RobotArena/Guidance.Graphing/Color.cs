using System;
using System.Drawing;

namespace Guidance.Drawing
{
    public static class Color_Extension
    {
        public static Color Parse(string str)
        {
            Color color = Color.FromName(str);
            if (!(color.R == 0 && color.G == 0 && color.B==0 && color.A == 0))
                return color;
            throw new FormatException("Unknown Color");
        }
    }
}

