using GeekStore.Model.Components;

namespace GeekStore.Factory
{
    public class PowerUnitFactory
    {
        public static PSU CreatePSU()
        {
            return new PSU("Corsair", "CX500", 500, 33.0);
        }

        public static PSU CreatePSU(string manufacturer, string model, int output, double price)
        {
            return new PSU(manufacturer, model, output, price);
        }

        public static Battery CreateBattery()
        {
            return new Battery(45);
        }

        public static Battery CreateBattery(int output)
        {
            return new Battery(output);
        }
    }
}
