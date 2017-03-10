namespace GeekStore.Warehouse.Model.Components
{
    public class LaptopCPU : CPU
    {
        public LaptopCPU(double baseFrequency, double boostFrequency, CPUCores cores, string manufacturer, string model, int tdp, int threads)
                  : base(baseFrequency, boostFrequency, cores, manufacturer, model, tdp, threads) { }
    }
}
