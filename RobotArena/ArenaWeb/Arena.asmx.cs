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
    public class SecurityException : Exception { }

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
            Robot robot = arena.AddRobot(WhoAmI());
            return robot.Handle;
        }

        [WebMethod]
        public void SetSpeedDemand(int robotHandle, float speed, float steer)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);

            if (WhoAmI() != robot.Owner)
                throw new SecurityException();

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
        public void SetColorByName(int robotHandle, string color)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            robot.Color = Guidance.Drawing.Color_Extension.Parse(color);
        }

        [WebMethod]
        public void SetColor(int robotHandle, byte a, byte r, byte g, byte b)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            robot.Color = System.Drawing.Color.FromArgb(a, r, g, b);
        }

        struct ARGB
        {
            public ARGB(System.Drawing.Color color)
            {
                A = color.A;
                R = color.R;
                G= color.G;
                B = color.B;
            }
            public byte A;
            public byte R;
            public byte G ;
            public byte B;
        }

        [WebMethod]
        public string GetColor(int robotHandle)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            return serializer.Serialize(new ARGB(robot.Color));
        }

        [WebMethod]
        public void DeleteRobot(int robotHandle)
        {
            Robot robot = Robot.AllRobots.GetRobot(robotHandle);
            if (WhoAmI() != robot.Owner)
                throw new SecurityException();

            robot.Arena.Delete(robot);
        }

        [WebMethod]
        public string WhoAmI()
        {
            return Context.User.Identity.Name;
        }

        [WebMethod]
        public bool Login(string username, string password)
        {
            if (System.Web.Security.Membership.ValidateUser(username, password))
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(username, true);
                return true;
            }
            else
                return false;
        }
    }
}
