using System;
using System.Collections.Generic;
using System.Text;

namespace GeekStore.WarehouseItems.Components
{
    class DesktopCPU : CPU, IItem
    {
        public enum CPUManufacturers { Intel, AMD }
        private readonly double _baseFrequency;
        private readonly double _boostFrequency;
        private readonly int _cores;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly string _socket;
        private readonly int _tdp;
        private readonly int _threads;

        public DesktopCPU(double baseFrequency, double boostFrequency, int cores, CPUManufacturers manufacturer, string model, double price, int quantity, string socket, int tdp, int threads)
        {
            try
            {
                if (baseFrequency <= 0)
                {
                    throw new ArgumentException("CPU Base Frequency cannot be less than 0. Entered value: " + baseFrequency.ToString());
                }
                if (boostFrequency < baseFrequency)
                {
                    throw new ArgumentException("CPU Boost Frequency cannot be less than Base Frequency. Entered value: " + boostFrequency.ToString());
                }
                if (cores != 1 && cores != 2 && cores != 3 && cores != 4 && cores != 6 && cores != 8 && cores != 10)
                {
                    throw new ArgumentException("Number of cores entered is invalid. Entered value: " + cores.ToString());
                }
                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                {
                    throw new ArgumentNullException(model);
                }
                if (price <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());
                }
                if (quantity <= 0)
                {
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());
                }
                if (string.IsNullOrEmpty(socket) || string.IsNullOrWhiteSpace(socket))
                {
                    throw new ArgumentNullException(socket);
                }
                if (tdp <= 0)
                {
                    throw new ArgumentException("TDP cannot be less or equal to 0. Entered value: " + tdp.ToString());
                }
                if (threads != cores && threads != (cores * 2))
                {
                    throw new ArgumentException("Number of Threads have to be equal or double of number of cores. Entered value: " + threads.ToString() + ". Number of cores entered: " + cores.ToString());
                }
                _baseFrequency = baseFrequency;
                _boostFrequency = boostFrequency;
                _cores = cores;
                _manufacturer = manufacturer.ToString();
                _model = model;
                _price = price;
                _quantity = quantity;
                _socket = socket;
                _tdp = tdp;
                _threads = threads;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (ArgumentException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\tManufacturer: " + _manufacturer);
                sb.AppendLine("\tModel: " + _model);
                sb.AppendLine("\tCores: " + _cores);
                sb.AppendLine("\tThreads: " + _threads);
                sb.AppendLine("\tBaseClock: " + _baseFrequency);
                sb.AppendLine("\tBoostClock: " + _boostFrequency);
                sb.AppendLine("\tSocket: " + _socket);
                sb.AppendLine("\tTDP: " + _tdp + "W");
                return sb.ToString();
            }
        }

        public double BaseFrequency { get { return _baseFrequency; } }

        public double BoostFrequency { get { return _boostFrequency; } }

        public int Cores { get { return _cores; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Socket { get { return _socket; } }

        public int Tdp { get { return _tdp; } }

        public int Threads { get { return _threads; } }

        public void AddToWarehouse(int incomingQuantity)
        {
            _quantity += incomingQuantity;
        }

        public void SellQuantity(int sellingQuantity)
        {
            _quantity -= sellingQuantity;
        }

        public void ChangePrice(double newPrice)
        {
            _price = newPrice;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}, {8}, {9}", BaseFrequency, BoostFrequency, Cores, Manufacturer, Model, Price, Quantity, Socket, Tdp, Threads);
        }

        public static explicit operator DesktopCPU(string v)
        {
            string[] cpuInString =  v.Split(' ');
            return new DesktopCPU(double.Parse(cpuInString[0]), double.Parse(cpuInString[1]), int.Parse(cpuInString[2]),
                              (cpuInString[3] == "Intel") ? CPUManufacturers.Intel : CPUManufacturers.AMD, cpuInString[4],
                              double.Parse(cpuInString[5]), int.Parse(cpuInString[6]), cpuInString[7], int.Parse(cpuInString[8]), int.Parse(cpuInString[9]));
        }
    }
}
