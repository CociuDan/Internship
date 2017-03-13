using System.Text;
using GeekStore.Model.Components;
using System;
using GeekStore.Model.Infrastucture;

namespace GeekStore.Model.PCs
{
    public class Laptop : IItem, IComputer
    {
        private readonly LaptopCPU _cpu;
        private readonly LaptopDisplay _display;
        private readonly Disk _drive;
        private readonly LaptopGPU _gpu;
        private readonly int _id;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly LaptopMotherboard _motherboard;
        private readonly Battery _battery;
        private double _price;
        private int _quantity;
        private readonly RAM _ram;


        public Laptop(Battery battery, LaptopCPU cpu, LaptopDisplay display, Disk drive, LaptopGPU gpu, string manufacturer, string model, LaptopMotherboard motherboard, double price, RAM ram)
        {
            try
            {
                if(battery == null) throw new ArgumentNullException("battery");
                if(cpu == null) throw new ArgumentNullException("cpu");
                if(display == null) throw new ArgumentNullException("display");
                if(drive == null) throw new ArgumentNullException("drive");
                if(gpu == null) throw new ArgumentNullException("gpu");
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer)) throw new ArgumentNullException("manufacturer");
                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model)) throw new ArgumentNullException("model");
                if(motherboard == null) throw new ArgumentNullException("motherboard");
                if (price < 0) throw new ArgumentException("Laptop price cannot be less than 0. Entered value: " + price);
                if(ram == null) throw new ArgumentNullException("ram");

                _battery = battery;
                _cpu = cpu;
                _display = display;
                _drive = drive;
                _gpu = gpu;
                _id = IDGenerator.NextID();
                _manufacturer = manufacturer;
                _model = model;
                _motherboard = motherboard;
                _price = price;
                _ram = ram;

                AddToWarehouse(1);
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
                sb.AppendLine($"\tManufacturer: {_manufacturer}");
                sb.AppendLine($"\tModel: { _model} ");
                sb.AppendLine($"\tCPU: {_cpu.ToString()}");
                sb.AppendLine($"\tRAM: {_ram.Capacity}MB {_ram.Generation} {_ram.Frequency}Mhz");
                sb.AppendLine($"\tGPU: {_gpu.ToString()}");
                sb.AppendLine($"\tDrive: {_drive.Capacity} {_drive.Type}");
                sb.AppendLine($"\tDisplay: {_display.AspectRatio} {_display.Resolution} @ {_display.MaxRefreshRate}Hz");
                return sb.ToString();
            }
        }

        public CPU CPU { get { return _cpu; } }

        public Display Display { get { return _display; } }

        public Disk Drive { get { return _drive; } }

        public GPU GPU { get { return _gpu; } }

        public int ID { get { return _id; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public RAM RAM { get { return _ram; } }

        public Motherboard Motherboard { get { return _motherboard; } }

        public PowerUnit PowerUnit { get { return _battery; } }

        public void AddToWarehouse(int incomingQuantity)
        {
            if (incomingQuantity <= 0)
                throw new ArgumentException("You cannot add less than one item to warehouse. Enterd value: " + incomingQuantity.ToString());
            _quantity += incomingQuantity;
        }

        public void SellQuantity(int sellingQuantity)
        {
            if (sellingQuantity <= 0)
                throw new ArgumentException("You cannot sell less than one item from warehouse. Enterd value: " + sellingQuantity.ToString());
            _quantity -= sellingQuantity;
        }

        public void ChangePrice(double newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("New Price cannot be less or equal to 0. Entered value: " + newPrice.ToString());
            _price = newPrice;
        }
    }
}
