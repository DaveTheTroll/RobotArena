using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

using RobotArena;

namespace ArenaWeb
{
    [WebService(Namespace = "http://arena.thetroll.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ArenaService : System.Web.Services.WebService
    {
        static JavaScriptSerializer serializer = new JavaScriptSerializer();

        [WebMethod]
        public string GetTest()
        {
            return "TEST " + (new Random()).Next(100).ToString();
        }

        [WebMethod]
        public int CreateRobot(int arenaHandle)
        {
            Arena arena = Global.Arenas.GetArena(arenaHandle);
            Robot robot = arena.AddRobot();
            return robot.Handle;
        }

        [WebMethod]
        public void SetSpeedDemand(int robotHandle, float speed, float steer)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            robot.SpeedDemand = speed;
            robot.SteerDemand = steer;
        }

        [WebMethod]
        public string GetRobotState(int robotHandle)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            return serializer.Serialize(robot);
        }

        [WebMethod]
        public string GetArenaState(int arenaHandle)
        {
            Arena arena = Global.Arenas.GetArena(arenaHandle);
            return serializer.Serialize(arena);
        }

        [WebMethod]
        public void SetColor(int robotHandle, string color)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            robot.Color = Guidance.Drawing.Color_Extension.Parse(color);
        }

        [WebMethod]
        public void DeleteRobot(int robotHandle)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            robot.Arena.Delete(robot);
        }
    }
}
