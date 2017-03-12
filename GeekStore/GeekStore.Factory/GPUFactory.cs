using GeekStore.Warehouse.Model.Components;

namespace GeekStore.Factory
{
    public class GPUFactory
    {
        public static DesktopGPU BuildDesktopGPU()
        {
            return new DesktopGPU("Maxwell", 128, "MSI", "GDDR5", "750Ti OC", 110, 60, 2);
        }

        public static DesktopGPU BuildDesktopGPU(string architecture, int interfaceWidth, string manufacturer, string memoryInterface, string model, double price, int tdp, int vram)
        {
            return new DesktopGPU(architecture, interfaceWidth, manufacturer, memoryInterface, model, price, tdp, vram);
        }

        public static LaptopGPU BuildLaptopGPU()
        {
            return new LaptopGPU(128, "nVidia", "GDDR5", "1050Ti", 4096);
        }

        public static LaptopGPU BuildLaptopGPU(int interfaceWidth, string manufacturer, string memoryInterface, string model, int vram)
        {
            return new LaptopGPU(interfaceWidth, manufacturer, memoryInterface, model, vram);
        }
    }
}
