using GeekStore.Warehouse.Model.Peripherals;

namespace GeekStore.Factory
{
    public class MouseFactory
    {
        public static Mouse BuildMouse()
        {
            return new Mouse(2500, "Logitech", "G100S", 22.5, Mouse.MouseType.Optical);
        }

        public static Mouse BuildMouse(int dpi, string manufacturer, string model, double price, Mouse.MouseType mouseType)
        {
            return new Mouse(dpi, manufacturer, model, price, mouseType);
        }
    }
}
