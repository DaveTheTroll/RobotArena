using System;
using System.Drawing;
using System.Web.Script.Serialization;

namespace RobotArena
{
    public class Robot : IDisposable
    {
        internal Robot(Arena arena)
        {
            this.arena = arena;
            this.Color = Color.White;

            lock (typeof(Robot))
            {
                handle = nextRobot++;
            }

            allRobots.AddRobot(this);
        }
        static int nextRobot = 0;
        int handle;
        public int Handle { get { return handle; } }

        public string Name { get; set; }

        public void Dispose()
        {
            lock (this)
            {
                if (handle != -1)
                {
                    allRobots.RemoveRobot(this);
                    handle = -1;
                }
            }
        }
        ~Robot() { Dispose(); }

        static RobotList allRobots = new RobotList();
        static public RobotList AllRobots { get { return allRobots; } }

        readonly Arena arena;
        [System.Web.Script.Serialization.ScriptIgnore]
        public Arena Arena { get { return arena; } }

        public int ArenaHandle { get { return arena.Handle; } }

        public Pose Location { get; private set; }
        public double Speed { get; private set; }
        public double Steer { get; private set; }

        public double SpeedDemand { get; set; }
        public double SteerDemand { get; set; }
        [ScriptIgnoreAttribute]
        public Color Color { get; set; }

        const double maxAcceleration = 0.1;
        const double maxSpeed = 1;
        const double minSpeed = -1;

        const double maxSteerRate = 0.1;
        const double maxSteer = 1;

        internal void Tick(TimeSpan deltaTime)
        {
            lock (this)
            {
                double deltaSpeed = SpeedDemand - Speed;
                if (Math.Abs(deltaSpeed) > maxAcceleration * deltaTime.TotalSeconds)
                    deltaSpeed = Math.Sign(deltaSpeed) * maxAcceleration * deltaTime.TotalSeconds;
                Speed = Math.Max(Math.Min(Speed + deltaSpeed, maxSpeed), minSpeed);

                double deltaSteer = SteerDemand - Steer;
                if (Math.Abs(deltaSteer) > maxSteerRate * deltaTime.TotalSeconds)
                    deltaSteer = Math.Sign(deltaSteer) * maxSteerRate * deltaTime.TotalSeconds;
                Steer = Math.Max(Math.Min(Steer + deltaSteer, maxSteer), -maxSteer);

                Location = new Pose(Location.X + Speed * deltaTime.TotalSeconds * Location.Heading.Cos,
                    Location.Y + Speed * deltaTime.TotalSeconds * Location.Heading.Sin,
                    Location.Heading + Steer * deltaTime.TotalSeconds);
            }
        }

        public override string ToString() { return Name == null ? string.Format("Robot {0}", Handle) : Name; }
    }
}
