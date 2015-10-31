using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobotArena;
using Guidance.Drawing;

namespace ArenaWeb
{
    public partial class RobotProperties : System.Web.UI.UserControl
    {
        public RobotProperties() { }
        public RobotProperties(Robot robot) { this.robot = robot; }

        Robot robot;

        public int Handle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            robot = Robot.AllRobots.GetRobot(Handle);

            bool myRobot = Context.User.Identity.Name == robot.Owner;
            TextBoxSpeedDemand.Enabled = myRobot;
            TextBoxSteerDemand.Enabled = myRobot;
            TextBoxColor.Enabled = myRobot;

            if (!IsPostBack)
            {
                TextBoxSpeedDemand.Text = robot.SpeedDemand.ToString();
                TextBoxSteerDemand.Text = robot.SteerDemand.ToString();
                TextBoxColor.Text = robot.Color.ToParseString();

                HyperLinkArena.Text = robot.Arena.ToString();
                HyperLinkArena.NavigateUrl = string.Format("Arena.aspx?arena={0}", robot.Arena.Handle);

                TimerRobot_Tick(sender, e);
            }
        }

        protected void TimerRobot_Tick(object sender, EventArgs e)
        {
            try
            {
                robot.SpeedDemand = double.Parse(TextBoxSpeedDemand.Text);
                robot.SteerDemand = double.Parse(TextBoxSteerDemand.Text);
                robot.Color = Color_Extension.Parse(TextBoxColor.Text);
            }
            catch { }
            robot.Arena.Update();

            LabelHandle.Text = robot.ToString();
            LabelLocation.Text = robot.Location.Position.ToString();
            LabelHeading.Text = string.Format("{0:0.000}", robot.Location.Heading.Degrees);
            LabelSpeed.Text = string.Format("{0:0.000}", robot.Speed);
            LabelSteer.Text = string.Format("{0:0.000}", robot.Steer);
        }
    }
}