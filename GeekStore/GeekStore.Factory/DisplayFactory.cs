using GeekStore.Model.Components;
using GeekStore.Model.Peripherals;

namespace GeekStore.Factory
{
    public class DisplayFactory
    {
        public static Monitor CreateMonitor()
        {
            return new Monitor("16:9", "ASUS", 165, "ROG Swift PG279Q", 500, "2560x1440");
        }

        public static Monitor CreateMonitor(string aspectRatio, string manufacturer, int maxRefreshRate, string model, double price, string resolution)
        {
            return new Monitor(aspectRatio, manufacturer, maxRefreshRate, model, price, resolution);
        }

        public static LaptopDisplay CreateLaptopDisplay()
        {
            return new LaptopDisplay("16:9", 60, "1920x1080");
        }

        public static LaptopDisplay CreateLaptopDisplay(string aspectRatio, int maxRefreshRate, string resolution)
        {
            return new LaptopDisplay(aspectRatio, maxRefreshRate, resolution);
        }
    }
}
