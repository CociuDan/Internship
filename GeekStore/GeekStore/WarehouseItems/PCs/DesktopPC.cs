using System;
using GeekStore.WarehouseItems.Components;
using GeekStore.WarehouseItems.Peripherals;

namespace GeekStore.WarehouseItems.PCs
{
    class DesktopPC : IComputer
    {
        private double _price;
        private CPU _cpu;
        private Disk _disk;
        private GPU _gpu;
        private RAM _ram;

        public DesktopPC(Cooler cooler, CPU cpu, Disk drive, GPU gpu, Motherboard motherboard, PSU psu, RAM ram)
        {
            Cooler = cooler;
            _cpu = cpu;
            _disk = drive;
            _gpu = gpu;
            Motherboard = motherboard;
            PSU = psu;
            _ram = ram;
        }

        public Case Case { get; set; }
        public Cooler Cooler { get; set; }
        public Display Display { get; set; }
        public Headphones Headphones { get; set; }
        public Keyboard Keyboard { get; set; }
        public Motherboard Motherboard { get; set; }
        public Mouse Mouse { get; set; }
        public PSU PSU { get; set; }
        public Speakers Speakers { get; set; }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Price { get { return CalculatePCPrice(); } }

        public string CPU
        {
            get
            {
                return string.Format("{0} {1} {2}/{3} @{4}-{5}", _cpu.Manufacturer, _cpu.Model, _cpu.Cores, _cpu.Threads, _cpu.BaseFrequency, _cpu.BoostFrequency);
            }
            set { _cpu = (CPU)value; }
        }

        public string Drive
        {
            get
            {
                //return string.Format("", _disk.Capacity, _disk.)
            }
            set { _disk = (Disk)value; }
        }

        public string GPU
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                { _gpu = (GPU)value; }
            }
        }

        public string RAM
        {
            get
            {
                throw new NotImplementedException();
            }
            set { _ram = (RAM)value; }
        }

        public double CalculatePCPrice()
        {
            double price = Cooler.Price + _cpu.Price + _disk.Price + _gpu.Price + Motherboard.Price + PSU.Price + _ram.Price;
            if (Case != null)
            {
                price += Case.Price;
            }
            if (Display != null)
            {
                price += Display.Price;
            }
            if (Headphones != null)
            {
                price += Headphones.Price;
            }
            if (Keyboard != null)
            {
                price += Keyboard.Price;
            }
            if (Mouse != null)
            {
                price += Mouse.Price;
            }
            return price;
        }
    }
}
