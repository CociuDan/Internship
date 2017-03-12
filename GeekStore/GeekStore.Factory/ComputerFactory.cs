using GeekStore.Warehouse.Model.Components;
using GeekStore.Warehouse.Model.PCs;

namespace GeekStore.Factory
{
    public class ComputerFactory
    {
        public static Desktop BuildDesktop()
        {
            return new Desktop(CoolerFactory.BuildCooler(), CPUFactory.BuildDesktopCPU(), DiskFactory.BuildDisk(), GPUFactory.BuildDesktopGPU(),
                               MotherboardFactory.BuildDesktopMotherboard(), PowerUnitFactory.BuildPSU(), RAMFactory.BuildRAM());
        }

        public static Desktop BuildDesktop(Cooler cooler, DesktopCPU cpu, Disk disk, DesktopGPU gpu, DesktopMotherboard motherboard, PSU psu, RAM ram)
        {
            return new Desktop(cooler, cpu, disk, gpu, motherboard, psu, ram);
        }

        public static Laptop BuildLaptop()
        {
            return new Laptop(PowerUnitFactory.BuildBattery(), CPUFactory.BuildLaptopCPU(), DisplayFactory.BuildLaptopDisplay(), DiskFactory.BuildDisk(),
                              GPUFactory.BuildLaptopGPU(), "ASUS", "UX610", MotherboardFactory.BuildLaptopMotherboard(), 800, RAMFactory.BuildRAM());
        }

        public static Laptop BuildLaptop(Battery battery, LaptopCPU cpu, LaptopDisplay display, Disk disk, LaptopGPU gpu, string manufacturer,
                                         string model, LaptopMotherboard motherboard, double price, RAM ram)
        {
            return new Laptop(battery, cpu, display, disk, gpu, manufacturer, model, motherboard, price, ram);
        }
    }
}
