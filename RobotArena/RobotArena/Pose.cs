using System;

namespace RobotArena
{
    public struct Position
    {
        public Position(double x, double y) { this.x = x; this.y = y; }
        public Position(Position other) : this(other.X, other.Y) { }

        readonly double x;
        readonly double y;
        public double X { get { return x; } }
        public double Y { get { return y; } }

        public override string ToString() { return string.Format("({0:0.000}, {1:0.000})", X, Y); }
    }

    public struct Angle
    {
        public Angle(double radians)
        {
            this.radians = PiWrap(radians);
        }

        public static double PiWrap(double angleRad)
        {
            int numRevs = (int)(angleRad / (2.0 * Math.PI));
            angleRad -= (double)numRevs * 2.0 * Math.PI;
            if (angleRad > Math.PI)
            {
                angleRad -= 2.0 * Math.PI;
            }
            if (angleRad <= -Math.PI)
            {
                angleRad += 2.0 * Math.PI;
            }
            return angleRad;
        }

        double radians;
        [System.Web.Script.Serialization.ScriptIgnore]
        public double Radians { get { return radians; } }
        public double Degrees { get { return radians * 180 / Math.PI; } }

        [System.Web.Script.Serialization.ScriptIgnore]
        public double Cos { get { return Math.Cos(Radians); } }
        [System.Web.Script.Serialization.ScriptIgnore]
        public double Sin { get { return Math.Sin(Radians); } }
        public static Angle operator +(Angle augend, Angle addend) { return new Angle(augend.Radians + addend.Radians); }
        public static Angle operator -(Angle minuend, Angle subtrahead) { return new Angle(minuend.Radians + subtrahead.Radians); }
        public static implicit operator Angle(double radians) {return new Angle(radians);}

        public override string ToString() {return string.Format("{0:0.#}{1}", Degrees, (char)0xB0);}
    }

    public struct Pose
    {
        public Pose(Position position, Angle heading) { this.position = position;  this.heading = heading; }
        public Pose(double x, double y, Angle heading) : this(new Position(x, y), heading) {}

        readonly Position position;
        readonly Angle heading;
        public Position Position { get { return position; } }
        public Angle Heading { get { return heading; } }

        [System.Web.Script.Serialization.ScriptIgnore]
        public double X { get { return Position.X; } }
        [System.Web.Script.Serialization.ScriptIgnore]
        public double Y { get { return Position.Y; } }

        public Position AddRelative(Position delta) { return new Position(X + delta.X * Heading.Cos - delta.Y * Heading.Sin, Y + delta.X * Heading.Sin + delta.Y * Heading.Cos); }
        public Pose AddRelative(Pose delta) { return new Pose(AddRelative(delta.Position), Heading + delta.Heading); }

        public override string ToString() { return string.Format("{0} {1}", Position, Heading); }
    }
}
