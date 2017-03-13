using GeekStore.Model.Components;

namespace GeekStore.Factory
{
    public class CPUFactory
    {
        public static DesktopCPU CreateDesktopCPU()
        {
            return new DesktopCPU(3.40, 3.80, CPU.CPUCores.QuadCore, "Intel", "i7 2600", 330, "LGA1155", 95, 8);
        }

        public static DesktopCPU CreateDesktopCPU(double baseFrequency, double boostFrequency, CPU.CPUCores cores, string manufacturer, string model, double price, string socket, int tdp, int threads)
        {
            return new DesktopCPU(baseFrequency, boostFrequency, cores, manufacturer, model, price, socket, tdp, threads);
        }

        public static LaptopCPU CreateLaptopCPU()
        {
            return new LaptopCPU(2.8, 3.8, CPU.CPUCores.QuadCore, "Intel", "i7 7700HQ", 35, 8);
        }

        public static LaptopCPU CreateLaptopCPU(double baseFrequency, double boostFrequency, CPU.CPUCores cores, string manufacturer, string model, int tdp, int threads)
        {
            return new LaptopCPU(baseFrequency, boostFrequency, cores, manufacturer, model, tdp, threads);
        }
    }
}
