using System;
using System.Collections.Generic;

namespace RobotArena
{
    public class RobotList : IEnumerable<Robot>
    {
        Dictionary<int, Robot> robots = new Dictionary<int, Robot>();

        internal void AddRobot(Robot robot) {robots.Add(robot.Handle, robot);}
        internal void RemoveRobot(Robot robot) {robots.Remove(robot.Handle);}

        public Robot GetRobot(int handle) { return robots[handle]; }

        public IEnumerator<Robot> GetEnumerator() { return robots.Values.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
