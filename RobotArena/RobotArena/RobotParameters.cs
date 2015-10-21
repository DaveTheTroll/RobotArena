using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotArena
{
    public class RobotParameters
    {
        public RobotParameters()
        {
            this.MaxAcceleration = 0.1;
            this.MaxSpeed = 1;
            this.MinSpeed = -1;

            this.MaxSteerRate = 0.1;
            this.MaxSteer = 1;
        }

        public double MaxAcceleration { get; set; }
        public double MaxSpeed { get; set; }
        public double MinSpeed { get; set; }

        public double MaxSteerRate { get; set; }
        public double MaxSteer { get; set; }
    }
}
