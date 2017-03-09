using System;
using GeekStore.WarehouseItems.Components;
using GeekStore.WarehouseItems.Peripherals;

namespace GeekStore.WarehouseItems.PCs
{
    class Desktop : IComputer
    {
        private DesktopCPU _cpu;
        private Disk _disk;
        private DesktopGPU _gpu;
        private RAM _ram;

        public Desktop(Cooler cooler, DesktopCPU cpu, Disk drive, DesktopGPU gpu, Motherboard motherboard, PSU psu, RAM ram)
        {
            try
            {
                if (cooler == null)
                    throw new ArgumentNullException("cooler");
                if (cpu == null)
                    throw new ArgumentNullException("cpu");
                if (drive == null)
                    throw new ArgumentNullException("drive");
                if (gpu == null)
                    throw new ArgumentNullException("gpu");
                if (motherboard == null)
                    throw new ArgumentNullException("motherboard");
                if (psu == null)
                    throw new ArgumentNullException("psu");
                if (ram == null)
                    throw new ArgumentNullException("ram");
                Cooler = cooler;
                _cpu = cpu;
                _disk = drive;
                _gpu = gpu;
                Motherboard = motherboard;
                PSU = psu;
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

        public Case Case { get; set; }
        public Cooler Cooler { get; set; }
        public CPU CPU { get { return _cpu; } set { _cpu = (DesktopCPU)value; } }
        public Monitor Display { get; set; }
        public Disk Drive { get { return _disk; } set { _disk = value; } }
        public GPU GPU { get { return _gpu; } set { _gpu = (DesktopGPU)value; } }
        public Headphones Headphones { get; set; }
        public Keyboard Keyboard { get; set; }
        public Motherboard Motherboard { get; set; }
        public Mouse Mouse { get; set; }
        public double Price { get { return CalculatePCPrice(); } }
        public PSU PSU { get; set; }
        public RAM RAM { get { return _ram; } set { _ram = value; } }
        public Speakers Speakers { get; set; }

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
