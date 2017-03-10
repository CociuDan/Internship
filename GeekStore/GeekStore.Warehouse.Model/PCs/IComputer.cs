using GeekStore.Warehouse.Model.Components;

namespace GeekStore.Warehouse.Model.PCs
{
    public interface IComputer
    {
        CPU CPU { get; }
        Disk Drive { get; }
        GPU GPU { get; }
        Motherboard Motherboard { get; }
        PowerUnit PowerUnit { get; }
        RAM RAM { get; }
    }
}
