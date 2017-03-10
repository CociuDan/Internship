#define Release
using System;
using System.Collections.Generic;
using System.Diagnostics;
using GeekStore.Warehouse.Model.Components;
using GeekStore.Warehouse.Model.ModelOperations;
using GeekStore.Warehouse.Model.PCs;
using GeekStore.Warehouse.Model.Peripherals;
using GeekStore.Warehouse.Model;
using GeekStore.Warehouse.Repository.Interfaces;

namespace GeekStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //DebugFunction();
            //ReleaseFunction();

            Case pcCase = new Case(Case.FormFactorTypes.MiniTower, "Deepcool", "Smarter", 30, 1);
            Cooler cooler = new Cooler("Deepcool", "Gammaxx 200", 22.5, 1, "LGA1150, LGA1155, LGA1156, AM2, AM2+, AM3, AM3+", 100);
            DesktopCPU cpu = new DesktopCPU(3.40, 3.80, CPU.CPUCores.QuadCore, "Intel", "i7 2600", 330, 1, "LGA1155", 95, 8);
            Monitor display = new Monitor("16:9", "ASUS", 165, "ROG Swift PG279Q", 500, 1, "2560x1440");
            Disk disk = new Disk(240, Disk.DiskType.SSD, "Crucial", "BX100", 70.0, 1, 550, 0, 530);
            DesktopGPU gpu = new DesktopGPU("Maxwell", 128, "MSI", "GDDR5", "750Ti OC", 110, 1, 60, 2);
            Keyboard keyboard = new Keyboard(true, "Corsair", "K70 RGB", 35.0, 1, Keyboard.KeyboardType.Mechanical);
            DesktopMotherboard motherboard = new DesktopMotherboard("Intel Q65 Express", "DELL", "0J3C2F", 2, 20.0, 1, 4, "LGA1155");
            Mouse mouse = new Mouse(2500, "Logitech", "G100S", 22.5, 1, Mouse.MouseType.Optical);
            PSU psu = new PSU("Corsair", "CX500", 500, 33.0, 1);
            RAM ram = new RAM(4096, 1600, RAM.RAMGeneration.DDR3, "Corsair", "Vengeance", 17.5, 4);

            List<IItem> components = new List<IItem>();
            components.Add(pcCase);
            components.Add(cooler);
            components.Add(cpu);
            components.Add(display);
            components.Add(disk);
            components.Add(gpu);
            components.Add(keyboard);
            components.Add(motherboard);
            components.Add(mouse);
            components.Add(psu);
            components.Add(ram);

            //foreach (IItem item in components)
            //{
            //    Console.WriteLine(item.Description);
            //    Console.WriteLine("-------------------------------------------");
            //}

            //Console.ReadKey();

            List<DesktopCPU> cpus = new List<DesktopCPU>();
            cpus.Add(new DesktopCPU(3.40, 3.80, CPU.CPUCores.QuadCore, "Intel", "i7 2600", 330, 1, "LGA1155", 95, 8));
            cpus.Add(new DesktopCPU(4.20, 4.50, CPU.CPUCores.QuadCore, "Intel", "i7 7700k", 370, 1, "LGA1151", 95, 8));
            cpus.Add(new DesktopCPU(3.00, 3.50, CPU.CPUCores.DecaCore, "Intel", "i7 6590x", 1700, 1, "LGA2011-v3", 140, 20));
            cpus.Add(new DesktopCPU(3.00, 3.00, CPU.CPUCores.QuadCore, "Intel", "Xeon E5450", 20, 1, "LGA771", 65, 4));
            cpus.Sort(new CPUGamingComparer());
            foreach(var ceva in cpus)
            {
                Console.WriteLine(ceva.Description);
                Console.WriteLine("-------------------------------------------");
            }
            Console.ReadKey();
            //LaptopCPU noteCpu = new LaptopCPU(2.8, 3.8, CPU.CPUCores.QuadCore, "Intel", "i7 7700HQ", 35, 8);
            //LaptopGPU noteGpu = new LaptopGPU(128, "nVidia", "GDDR5", "1050Ti", 4096);
            //LaptopDisplay noteDisplay = new LaptopDisplay("16:9", 60, "1920x1080");
            //Laptop notebook = new Laptop(noteCpu, noteDisplay, disk, noteGpu, "ASUS", "UX610", 500.0, 1, ram);
            //Console.WriteLine(notebook.Description);
            //Console.ReadKey();
        }

        //[Conditional("Release")]
        //private static void ReleaseFunction()
        //{
        //    Console.WriteLine("Release Mode Active");
        //}

        //[Conditional("Debug")]
        //private static void DebugFunction()
        //{
        //    Console.WriteLine("Debug Mode Active");
        //}
    }
}
