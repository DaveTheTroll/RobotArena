using System;
using System.Windows.Forms;
using RobotArena;
using Guidance.Drawing;
using System.Drawing;

namespace ArenaForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            robot = arena.AddRobot();
            propertyGridRobot.SelectedObject = robot;

            scalingPanelArena.IncludePoint(-1, -1);
            scalingPanelArena.IncludePoint(1, 1);

            robot.SpeedDemand = 1;
            robot.SteerDemand = 0.5;
        }

        Arena arena = new Arena();
        Robot robot;

        void timerTick_Tick(object sender, EventArgs e)
        {
            arena.Update();
            scalingPanelArena.IncludePoint((float)robot.Location.X, (float)robot.Location.Y);
            scalingPanelArena.Refresh();
        }

        void scalingPanelArena_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPose(Brushes.Green, (float)robot.Location.X, (float)robot.Location.Y, (float)robot.Location.Heading.Radians, 0.3f, 0.2f, 0.1f);
        }
    }
}
