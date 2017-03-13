using GeekStore.Model.Components;

namespace GeekStore.Factory
{
    public class MotherboardFactory
    {
        public static DesktopMotherboard CreateDesktopMotherboard()
        {
            return new DesktopMotherboard("Intel Q65 Express", "DELL", "0J3C2F", 2, 20.0, 4, "LGA1155");
        }

        public static DesktopMotherboard CreateDesktopMotherboard(string chipset, string manufacturer, string model, int pcieSlots, double price, int ramSlots, string socket)
        {
            return new DesktopMotherboard(chipset, manufacturer, model, pcieSlots, price, ramSlots, socket);
        }

        public static LaptopMotherboard CreateLaptopMotherboard()
        {
            return new LaptopMotherboard(2);
        }

        public static LaptopMotherboard CreateLaptopMotherboard(int ramSlots)
        {
            return new LaptopMotherboard(ramSlots);
        }
    }
}
