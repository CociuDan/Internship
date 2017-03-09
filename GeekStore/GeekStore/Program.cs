#define Release
using GeekStore.WarehouseItems;
using GeekStore.WarehouseItems.Components;
using GeekStore.WarehouseItems.PCs;
using GeekStore.WarehouseItems.Peripherals;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace GeekStore
{
    class Program
    {
        static void Main(string[] args)
        {
            DebugFunction();
            ReleaseFunction();

            Case pcCase = new Case(Case.FormFactorTypes.MiniTower, "Deepcool", "Smarter", 30, 1);
            Cooler cooler = new Cooler("Deepcool", "Gammaxx 200", 22.5, 1, "LGA1150, LGA1155, LGA1156, AM2, AM2+, AM3, AM3+", 100);
            CPU cpu = new CPU(3.40, 3.80, 4, CPU.CPUManufacturers.Intel, "i7 2600", 330, 1, "LGA1155", 95, 8);
            Display display = new Display("16:9", "ASUS", 165, "ROG Swift PG279Q", 500, 1, "2560x1440");
            Disk disk = new Disk(240, Disk.DiskType.SSD, "Crucial", "BX100", 70.0, 1, 550, 0, 530);
            GPU gpu = new GPU("Maxwell", 128, "MSI", "GDDR5", "750Ti OC", 110, 1, 60, 2);
            Keyboard keyboard = new Keyboard(true, "Corsair", "K70 RGB", 35.0, 1, Keyboard.KeyboardType.Mechanical);
            Motherboard motherboard = new Motherboard("Intel Q65 Express", "DELL", "0J3C2F", 2, 20.0, 1, 4, "LGA1155");
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

            foreach (IItem item in components)
            {
                Console.WriteLine(item.Description);
                Console.WriteLine("-------------------------------------------");
            }

            Console.ReadKey();
        }

        [Conditional("Release")]
        private static void ReleaseFunction()
        {
            Console.WriteLine("Release Mode Active");
        }

        [Conditional("Debug")]
        private static void DebugFunction()
        {
            Console.WriteLine("Debug Mode Active");
        }
    }
}
