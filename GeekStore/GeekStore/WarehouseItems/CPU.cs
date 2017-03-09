using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekStore.WarehouseItems
{
    abstract class CPU
    {
        public enum CPUManufacturers { Intel, AMD }
        public enum CPUCores { Core1 = 1, Core2 = 2, Core3 = 3, Core4 = 4, Core6 = 6, Core8 = 8 }
        double BaseFrequency;
        double BoostFrequency;
        CPUCores Cores;
        CPUManufacturers Manufacturer;
        string Model;
        string Socket;
        int Tdp;
        int Threads;
    }
}
