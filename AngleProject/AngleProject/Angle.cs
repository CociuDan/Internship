using System.Text;

namespace AngleProject
{
    class Angle
    {
        private ulong _seconds;

        public Angle(ulong degree, ulong minutes, ulong seconds)
        {
            ulong tempSec = GetSeconds(degree, minutes, seconds);
            if (tempSec < 0)
            {
                _seconds = tempSec % 1296000 + 1296000;
            }
            else if (tempSec > 1296000)
                _seconds = tempSec % 1296000;
        }

        public Angle(ulong seconds)
        {
            if (seconds < 0)
            {
                _seconds = seconds % 1296000 + 1296000;
            }
            else
            {
                _seconds = seconds % 1296000;
            }

        }

        public ulong Degree { get { return (_seconds / 3600); } }

        public ulong Minutes { get { return (_seconds - (Degree * 3600)) / 60; } }

        public ulong Seconds { get { return _seconds - ((Degree * 3600) + (Minutes * 60)); } }

        public static Angle operator +(Angle a, Angle b)
        {
            if ((a._seconds + b._seconds) > 1296000)
                return new Angle((a._seconds + b._seconds) % 1296000);
            return new Angle(a._seconds + b._seconds);
        }

        public static Angle operator -(Angle a, Angle b)
        {
            if ((a._seconds - b._seconds) < 0)
                return new Angle((a._seconds - b._seconds) + 1296000);
            return new Angle(a._seconds - b._seconds);
        }

        public static bool operator ==(Angle a, Angle b)
        {
            if (a._seconds == b._seconds)
                return true;
            return false;
        }

        public static bool operator !=(Angle a, Angle b)
        {
            if (a._seconds != b._seconds)
                return true;
            return false;
        }

        public static bool operator <(Angle a, Angle b)
        {
            if (a._seconds < b._seconds)
                return true;
            return false;
        }

        public static bool operator >(Angle a, Angle b)
        {
            if (a._seconds > b._seconds)
                return true;
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Degree + "° ");
            sb.Append(Minutes + "\' ");
            sb.Append(Seconds + "\" ");
            return sb.ToString();
        }

        public ulong GetSeconds(ulong degree, ulong minutes, ulong seconds)
        {
            return (seconds + (minutes * 60) + (degree * 3600));
        }
    }
}