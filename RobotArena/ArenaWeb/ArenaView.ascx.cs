using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobotArena;
using SVGControls;
using System.Drawing;

namespace ArenaWeb
{
    public partial class ArenaView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Arena Arena { get; set; }

        protected void TimerArena_Tick(object sender, EventArgs e)
        {
            Arena.Update();

            Panel.Controls.Clear();

            foreach(Robot robot in Arena.Robots)
            {
                Polygon robotItem = new Polygon();
                robotItem.X = (float)robot.Location.X * 10 + 100;
                robotItem.Y = 100 - (float)robot.Location.Y * 10;
                robotItem.Rotation = (float)-robot.Location.Heading.Degrees;
                robotItem.Fill = robot.Color;
                robotItem.Points = new List<PointF> { new PointF(0, 0), new PointF(-10, 10), new PointF(20, 0), new PointF(-10, -10) };
                Panel.Controls.Add(robotItem);
            }
        }
    }
}