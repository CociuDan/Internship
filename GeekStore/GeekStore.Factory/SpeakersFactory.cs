using GeekStore.Model.Peripherals;

namespace GeekStore.Factory
{
    public class SpeakersFactory
    {
        public static Speakers CreateSpeakers()
        {
            return new Speakers("2.0", "Pioneer", 119, "S-DJ08", 400);
        }

        public static Speakers CreateSpeakers(string configuration, string manufacturer, int maxVolume, string model, double price)
        {
            return new Speakers(configuration, manufacturer, maxVolume, model, price);
        }
    }
}
