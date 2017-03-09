using System;
using System.Collections;
using System.Collections.Generic;

namespace CarProject
{
    class Car : IComparable
    {
        private readonly string _manufacturer;
        private int _maxSpeed;
        private readonly string _model;

        public Car(string manufacturer, int maxSpeed, string model)
        {
            _manufacturer = manufacturer;
            _maxSpeed = maxSpeed;
            _model = model;
        }

        public string Manufacturer { get { return _manufacturer; } }

        public int MaxSpeed { get { return _maxSpeed; } }

        public string Model { get { return _model; } }

        public int CompareTo(object obj)
        {
            Car secondCar = (Car)obj;
            if (this.MaxSpeed > secondCar.MaxSpeed)
                return 1;
            else if (this.MaxSpeed < secondCar.MaxSpeed)
                return -1;
            else return 0;
        }

        public void Tuning(int newMaxSpeed)
        {
            _maxSpeed = newMaxSpeed;
        }

        public static void Display(Car[] carArray)
        {
            for (int i = 0; i < carArray.Length; i++)
            {
                Console.WriteLine(carArray[i].MaxSpeed);
            }
        }

        public static void Diplay(List<Car> carList)
        {
            foreach(Car car in carList)
            {
                Console.WriteLine(car.MaxSpeed);
            }
        }
    }
}
