using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SVGControls;

namespace ArenaWeb
{
    public partial class SVGTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed1_Tick(object sender, EventArgs e)
        {
            int rotation = int.Parse(HiddenFieldRotation.Value);
            rotation++;
            if (rotation > 720)
                rotation -= 720;

            HiddenFieldRotation.Value = rotation.ToString();

            svgRect.Rotation = rotation;
            svgRect2.Rotation = -rotation / 2.0f;
            svgCircle.X = rotation + 20;
            svgText.Value = rotation.ToString();
        }
    }
}