using System;
using System.Numerics;

namespace AngleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a1 = new Angle(14651451516464, 0, 0);
            Angle a2 = new Angle(0, 0, 0);
            Angle a3 = a1 + a2 - a1 + a1 - a2;
            Console.WriteLine(a1.ToString());
            Console.WriteLine(a2.ToString());
            Console.WriteLine(a1 + a2);
            Console.ReadKey();
        }
    }
}
