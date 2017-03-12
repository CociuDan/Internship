using GeekStore.Warehouse.Model.Components;
using GeekStore.Warehouse.Model.Peripherals;

namespace GeekStore.Factory
{
    public class DisplayFactory
    {
        public static Monitor BuildMonitor()
        {
            return new Monitor("16:9", "ASUS", 165, "ROG Swift PG279Q", 500, "2560x1440");
        }

        public static Monitor BuildMonitor(string aspectRatio, string manufacturer, int maxRefreshRate, string model, double price, string resolution)
        {
            return new Monitor(aspectRatio, manufacturer, maxRefreshRate, model, price, resolution);
        }

        public static LaptopDisplay BuildLaptopDisplay()
        {
            return new LaptopDisplay("16:9", 60, "1920x1080");
        }

        public static LaptopDisplay BuildLaptopDisplay(string aspectRatio, int maxRefreshRate, string resolution)
        {
            return new LaptopDisplay(aspectRatio, maxRefreshRate, resolution);
        }
    }
}
