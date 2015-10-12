using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobotArena;

namespace ArenaWeb
{
    public partial class RobotPage : System.Web.UI.Page
    {
        Robot robot;

        protected void Page_Load(object sender, EventArgs e)
        {
            RobotProperties.Handle = int.Parse(Request.QueryString["robot"]);
            robot = Robot.AllRobots.GetRobot(RobotProperties.Handle);

            bool myRobot = Context.User.Identity.Name == robot.Owner;
            ButtonName.Enabled = myRobot;
            ButtonDelete.Enabled = myRobot;

            if (!IsPostBack)
                TextBoxName.Text = robot.ToString();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            robot.Arena.Delete(robot);
            Response.Redirect(string.Format("Arena.aspx?arena={0}", robot.ArenaHandle));
        }
        protected void ButtonName_Click(object sender, EventArgs e)
        {
            robot.Name = TextBoxName.Text;
        }
    }
}