using GeekStore.Model.Components;

namespace GeekStore.Factory
{
    public class RAMFactory
    {
        public static RAM CreateRAM()
        {
            return new RAM(4096, 1600, RAM.RAMGeneration.DDR3, "Corsair", "Vengeance", 17.5);
        }

        public static RAM CreateRAM(int capacity, int frequency, RAM.RAMGeneration ramGeneration, string manufacturer, string model, double price)
        {
            return new RAM(capacity, frequency, ramGeneration, manufacturer, model, price);
        }
    }
}
