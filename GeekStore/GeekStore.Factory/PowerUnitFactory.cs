using GeekStore.Warehouse.Model.Components;

namespace GeekStore.Factory
{
    public class PowerUnitFactory
    {
        public static PSU BuildPSU()
        {
            return new PSU("Corsair", "CX500", 500, 33.0);
        }

        public static PSU BuildPSU(string manufacturer, string model, int output, double price)
        {
            return new PSU(manufacturer, model, output, price);
        }

        public static Battery BuildBattery()
        {
            return new Battery(45);
        }

        public static Battery BuildBattery(int output)
        {
            return new Battery(output);
        }
    }
}
