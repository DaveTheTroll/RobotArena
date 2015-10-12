using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

namespace RobotArena
{
    public class Arena
    {
        public Arena()
        {
            lock (typeof(Arena))
            {
                handle = nextArena++;
            }

            lastUpdate = DateTime.Now;
        }
        static int nextArena = 0;
        
        int handle;
        public int Handle { get { return handle; } }

        public string Name { get; set; }

        List<Robot> robots = new List<Robot>();
        public Robot AddRobot(string owner)
        {
            Update();
            Robot robot = new Robot(this, owner);
            robots.Add(robot);
            return robot;
        }
        [System.Web.Script.Serialization.ScriptIgnore]
        public IEnumerable<Robot> Robots { get { return robots; } }
        public IEnumerable<int> RobotHandles { get { return robots.Select(r => r.Handle); } }

        public void Delete(Robot robot)
        {
            robots.Remove(robot);
            Robot.AllRobots.RemoveRobot(robot);
        }
        public void Clear()
        {
            foreach (Robot robot in robots.ToArray())
                Delete(robot);
        }

        void Tick(TimeSpan deltaTime)
        {
            lock(this)
            {
                foreach (Robot robot in robots)
                    robot.Tick(deltaTime);
                lastUpdate += deltaTime;
            }
        }

        DateTime lastUpdate;
        static TimeSpan iterationLength = TimeSpan.FromMilliseconds(100);
        public void Update()
        {
            DateTime now = DateTime.Now - iterationLength;
            while (now > lastUpdate)
                Tick(iterationLength);
        }

        public override string ToString() {return Name == null ?  string.Format("Arena {0}", Handle) : Name; }
    }
}
