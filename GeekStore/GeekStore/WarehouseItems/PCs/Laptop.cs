using System.Text;
using GeekStore.WarehouseItems.Components;
using System;

namespace GeekStore.WarehouseItems.PCs
{
    class Laptop : IItem, IComputer
    {
        private readonly string _cpu;
        private readonly string _ram;
        private readonly string _gpu;
        private readonly string _drive;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;

        public Laptop(CPU.CPUManufacturers cpuManufacturer, string cpuModel, int cpuCores, int cpuThreads, double cpuBaseFrequency, double cpuBoostFrequency, int ramCapacity,
                      RAM.RAMGeneration ramGeneration, string gpuModel, int gpuCapacity, Disk.DiskType diskType, int diskCapacity, string manufacturer, string model)
        {
            try
            {
                if(string.IsNullOrEmpty(cpuModel) || string.IsNullOrWhiteSpace(cpuModel))
                {
                    throw new ArgumentNullException(cpuModel);
                }
                if (cpuCores != 1 && cpuCores != 2 && cpuCores != 3 && cpuCores != 4 && cpuCores != 6 && cpuCores != 8 && cpuCores != 10)
                {
                    throw new ArgumentException("Number of cores entered is invalid. Entered value: " + cpuCores.ToString());
                }
                if (cpuThreads != cpuCores && cpuThreads != (cpuCores * 2))
                {
                    throw new ArgumentException("Number of Threads have to be equal or double of number of cores. Entered value: " + cpuThreads.ToString() + ". Number of cores entered: " + cpuCores.ToString());
                }
                if (cpuBaseFrequency <= 0)
                {
                    throw new ArgumentException("CPU Base Frequency cannot be less than 0. Entered value: " + cpuBaseFrequency.ToString());
                }
                if (cpuBoostFrequency < cpuBaseFrequency)
                {
                    throw new ArgumentException("CPU Boost Frequency cannot be less than Base Frequency. Entered value: " + cpuBoostFrequency.ToString());
                }
                if (ramCapacity != 512 && ramCapacity != 1024 && ramCapacity != 2048 && ramCapacity != 4096 && ramCapacity != 8192 && ramCapacity != 16384)
                {
                    throw new ArgumentException("RAM Capacity cannot be less than 512MB and higher than 16GB(16384MB). Entered value: " + ramCapacity.ToString());
                }
                if (string.IsNullOrEmpty(gpuModel) || string.IsNullOrWhiteSpace(gpuModel))
                {
                    throw new ArgumentNullException(gpuModel);
                }
                if (gpuCapacity <= 0 || gpuCapacity % 2 != 0)
                {
                    throw new ArgumentException("GPU Capacity cannot be less or equal to 0 or not divided by 2. Entered value: " + gpuCapacity);
                }
                if (diskCapacity <= 0)
                {
                    throw new ArgumentException("Disk Capacity cannot be less or equal to 0. Entered value: " + diskCapacity.ToString());
                }
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                {
                    throw new ArgumentNullException(manufacturer);
                }
                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                {
                    throw new ArgumentNullException(model);
                }
                _cpu = string.Format("{0} {1} {2}/{3} @{4}-{5}", cpuManufacturer.ToString(), cpuModel, cpuCores, cpuThreads, cpuBaseFrequency, cpuBoostFrequency);
                _ram = string.Format("{0} {1}", ramCapacity, ramGeneration.ToString());
                _gpu = string.Format("{0} {1}", gpuModel, gpuCapacity);
                _drive = string.Format("{0} {1}", diskCapacity, diskType);
                _manufacturer = manufacturer;
                _model = model;
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
                sb.AppendLine("Manufacturer: " + _manufacturer);
                sb.AppendLine("Model: " + _model);
                sb.AppendLine("CPU: " + _cpu);
                sb.AppendLine("RAM: " + _ram);
                sb.AppendLine("GPU: " + _gpu);
                sb.AppendLine("Drive: " + _drive);
                return sb.ToString();
            }
        }

        public string CPU { get { return _cpu; } }

        public string Drive { get { return _drive; } }

        public string GPU { get { return _gpu; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string RAM { get { return _ram; } }

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
    }
}
