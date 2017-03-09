namespace GeekStore.WarehouseItems.Components
{
    class LaptopCPU : CPU
    {
        public LaptopCPU(double baseFrequency, double boostFrequency, int cores, string manufacturer, string model, int tdp, int threads)
                  : base(baseFrequency, boostFrequency, cores, manufacturer, model, tdp, threads) { }
    }
}
