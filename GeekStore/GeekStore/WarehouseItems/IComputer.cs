using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekStore.WarehouseItems
{
    public interface IComputer
    {
        string CPU { get; }
        string Drive { get; }
        string GPU { get; }
        string RAM { get; }


    }
}
