using GeekStore.Warehouse.Model.Components;
using System;
using System.Collections.Generic;

namespace GeekStore.Warehouse.Model.ModelOperations
{
    public class CPUWorkingComparer : Comparer<CPU>
    {
        public override int Compare(CPU x, CPU y)
        {
            if (x.Cores == y.Cores && x.Threads == y.Threads && x.BoostFrequency == y.BoostFrequency)
                return 0;

            else if (x.Cores >= y.Cores && x.Threads > y.Threads && x.BoostFrequency - y.BoostFrequency < 0.5)
                return 1;

            else
                return -1;
        }
    }
}
