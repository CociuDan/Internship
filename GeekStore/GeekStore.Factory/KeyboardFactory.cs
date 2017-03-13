using GeekStore.Model.Peripherals;

namespace GeekStore.Factory
{
    public class KeyboardFactory
    {
        public static Keyboard CreateKeyboard()
        {
            return new Keyboard(true, "Corsair", "K70 RGB", 35.0, Keyboard.KeyboardType.Mechanical);
        }

        public static Keyboard CreateKeyboard(bool backlight, string manufacturer, string model, double price, Keyboard.KeyboardType keyboardType)
        {
            return new Keyboard(backlight, manufacturer, model, price, keyboardType);
        }
    }
}
