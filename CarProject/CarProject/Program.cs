using System;
using System.Collections;
using System.Collections.Generic;

namespace CarProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] carArray = new Car[3]
            {
                new Car("Ford", 200, "Fiesta"),
                new Car("Ford", 400, "GT"),
                new Car("Ford", 280, "Focus")
            };
            Car.Display(carArray);
            Console.WriteLine();
            Array.Sort(carArray, sortAscendingSpeed());
            Car.Display(carArray);
            Console.ReadKey();
            Console.WriteLine("-------------------------------------------------");
            List<Car> carList = new List<Car>();
            carList.Add(new Car("Ford", 200, "Fiesta"));
            carList.Add(new Car("Ford", 400, "GT"));
            carList.Add(new Car("Ford", 280, "Focus"));
            Car.Diplay(carList);
            Console.WriteLine();
            carList.Sort();
            Car.Diplay(carList);
            Console.ReadKey();
        }
        public static IComparer sortAscendingSpeed()
        {
            return new SortAscendingSpeedHelper();
        }

        public static IComparer sortDescendingSpeed()
        {
            return new SortDescendingSpeedHelper();
        }
    }
}
