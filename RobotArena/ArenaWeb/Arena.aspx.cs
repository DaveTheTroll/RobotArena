using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobotArena;

namespace ArenaWeb
{
    public partial class ArenaPage : System.Web.UI.Page
    {
        Arena arena;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                arena = Global.Arenas.GetArena(int.Parse(Request.QueryString["arena"]));
                ArenaView.Arena = arena;
            }
            catch (Exception)
            {
                Response.Redirect("ArenaList.aspx");
                return;
            }

            if (!IsPostBack)
            {
                UpdateRobotList();
                TextBoxName.Text = arena.ToString();
            }
        }

        void UpdateRobotList()
        {
            BulletedListRobot.Items.Clear();
            foreach (Robot robot in arena.Robots.ToArray())
            {
                try
                {
                    ListItem listItem = new ListItem(robot.ToString(), string.Format("Robot.aspx?robot={0}", robot.Handle));
                    BulletedListRobot.Items.Add(listItem);
                }
                catch { }
            }
        }

        protected void ButtonAddRobot_Click(object sender, EventArgs e)
        {
            Robot robot = arena.AddRobot();
            Response.Redirect(string.Format("Robot.aspx?robot={0}", robot.Handle));
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            arena.Clear();
        }

        protected void Timer_RobotList_Tick(object sender, EventArgs e)
        {
            UpdateRobotList();
        }

        protected void ButtonName_Click(object sender, EventArgs e)
        {
            arena.Name = TextBoxName.Text;
        }
    }
}