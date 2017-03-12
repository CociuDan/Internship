using GeekStore.Warehouse.Model.Peripherals;

namespace GeekStore.Factory
{
    public class SpeakersFactory
    {
        public static Speakers BuildSpeakers()
        {
            return new Speakers("2.0", "Pioneer", 119, "S-DJ08", 400);
        }

        public static Speakers BuildSpeakers(string configuration, string manufacturer, int maxVolume, string model, double price)
        {
            return new Speakers(configuration, manufacturer, maxVolume, model, price);
        }
    }
}
