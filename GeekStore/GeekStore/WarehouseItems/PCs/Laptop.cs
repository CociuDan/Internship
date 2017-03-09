using System.Text;
using GeekStore.WarehouseItems.Components;
using System;

namespace GeekStore.WarehouseItems.PCs
{
    class Laptop : IItem, IComputer
    {
        private readonly CPU _cpu;
        private readonly Display _display;
        private readonly Disk _drive;
        private readonly GPU _gpu;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly RAM _ram;

        public Laptop(LaptopCPU cpu, LaptopDisplay display, Disk drive, GPU gpu, string manufacturer, string model, double price, int quantity, RAM ram)
        {
            try
            {
                if (cpu == null)
                    throw new ArgumentNullException("cpu");
                if (display == null)
                    throw new ArgumentNullException("display");
                if (drive == null)
                    throw new ArgumentNullException("drive");
                if (gpu == null)
                    throw new ArgumentNullException("gpu");
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException("manufacturer");
                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException("model");
                if (price < 0)
                    throw new ArgumentException("Laptop price cannot be less than 0. Entered value: " + price);
                if (quantity < 0)
                    throw new ArgumentException("Laptop quantity cannot be less than 0. Entered value: " + quantity);
                if (ram == null)
                    throw new ArgumentNullException("ram");
                _cpu = cpu;
                _display = display;
                _drive = drive;
                _gpu = gpu;
                _manufacturer = manufacturer;
                _model = model;
                _price = price;
                _quantity = quantity;
                _ram = ram;
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
                sb.AppendLine($"Manufacturer: {_manufacturer}");
                sb.AppendLine($"Model: { _model} ");
                sb.AppendLine($"CPU: {_cpu.ToString()}");
                sb.AppendLine($"RAM: {_ram.Capacity}MB {_ram.Generation} {_ram.Frequency}Mhz");
                sb.AppendLine($"GPU: {_gpu.ToString()}");
                sb.AppendLine($"Drive: {_drive.Capacity} {_drive.Type}");
                sb.AppendLine($"Display: {_display.AspectRatio} {_display.Resolution} @ {_display.MaxRefreshRate}Hz");
                return sb.ToString();
            }
        }

        public CPU CPU { get { return _cpu; } }

        public Display Display { get { return _display; } }

        public Disk Drive { get { return _drive; } }

        public GPU GPU { get { return _gpu; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public RAM RAM { get { return _ram; } }

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
