#define Release
using System;
using System.Collections.Generic;
using System.Diagnostics;
using GeekStore.Model.Components;
using GeekStore.Model.ModelOperations;
using GeekStore.Model.PCs;
using GeekStore.Model.Peripherals;
using GeekStore.Model;
using GeekStore.Factory;
using GeekStore.Service.Interfaces;
using GeekStore.Service.Implimentation;

namespace GeekStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //DebugFunction();
            //ReleaseFunction();
            IGeekStoreService<IItem> _geekStore_Service = new GeekStoreService();

            _geekStore_Service.StoreItem(CPUFactory.CreateDesktopCPU());
            _geekStore_Service.StoreItem(ComputerFactory.CreateLaptop());            
            _geekStore_Service.StoreItem(GPUFactory.CreateDesktopGPU());

            foreach(var item in _geekStore_Service.GetItems())
            {
                Console.WriteLine(item.Description);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(item.ID);
                Console.WriteLine("-------------------------------------------");
            }
            Console.ReadKey();

            IItem cevav = _geekStore_Service.GetItemByID(2);

            Console.WriteLine(cevav.Description);
            Console.ReadKey();
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
