using GeekStore.Model.Components;
using GeekStore.Model.PCs;

namespace GeekStore.Factory
{
    public class ComputerFactory
    {
        public static Desktop CreateDesktop()
        {
            return new Desktop(CoolerFactory.CreateCooler(), CPUFactory.CreateDesktopCPU(), DiskFactory.CreateDisk(), GPUFactory.CreateDesktopGPU(),
                               MotherboardFactory.CreateDesktopMotherboard(), PowerUnitFactory.CreatePSU(), RAMFactory.CreateRAM());
        }

        public static Desktop CreateDesktop(Cooler cooler, DesktopCPU cpu, Disk disk, DesktopGPU gpu, DesktopMotherboard motherboard, PSU psu, RAM ram)
        {
            return new Desktop(cooler, cpu, disk, gpu, motherboard, psu, ram);
        }

        public static Laptop CreateLaptop()
        {
            return new Laptop(PowerUnitFactory.CreateBattery(), CPUFactory.CreateLaptopCPU(), DisplayFactory.CreateLaptopDisplay(), DiskFactory.CreateDisk(),
                              GPUFactory.CreateLaptopGPU(), "ASUS", "UX610", MotherboardFactory.CreateLaptopMotherboard(), 800, RAMFactory.CreateRAM());
        }

        public static Laptop CreateLaptop(Battery battery, LaptopCPU cpu, LaptopDisplay display, Disk disk, LaptopGPU gpu, string manufacturer,
                                         string model, LaptopMotherboard motherboard, double price, RAM ram)
        {
            return new Laptop(battery, cpu, display, disk, gpu, manufacturer, model, motherboard, price, ram);
        }
    }
}
