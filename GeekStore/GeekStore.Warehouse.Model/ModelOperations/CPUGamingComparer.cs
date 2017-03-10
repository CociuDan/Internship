using GeekStore.Warehouse.Model.Components;
using System.Collections.Generic;

namespace GeekStore.Warehouse.Model.ModelOperations
{
    public class CPUGamingComparer : Comparer<CPU>
    {
        public override int Compare(CPU x, CPU y)
        {
            if (x.Threads == y.Threads && x.BoostFrequency == y.BoostFrequency)
                return 0;

            else if (x.Cores >= CPU.CPUCores.QuadCore && x.Threads >= 4 && x.BoostFrequency > y.BoostFrequency + 0.5)
                return 1;

            else
                return -1;
        }
    }
}
