namespace GeekStore.WarehouseItems.Components
{
    class LaptopGPU : GPU
    {
        public LaptopGPU(int interfaceWidth, string manufacturer, string memoryInterface, string model, int vram)
                  : base(interfaceWidth, manufacturer, memoryInterface, model, vram) { }
    }
}
