using GeekStore.WarehouseItems.Components;

namespace GeekStore.WarehouseItems.PCs
{
    public interface IComputer
    {
        CPU CPU { get; }
        Disk Drive { get; }
        GPU GPU { get; }
        RAM RAM { get; }
    }
}
