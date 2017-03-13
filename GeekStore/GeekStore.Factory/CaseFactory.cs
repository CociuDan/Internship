using GeekStore.Model.Components;

namespace GeekStore.Factory
{
    public class CaseFactory
    {
        public static Case CreateCase()
        {
            return new Case(Case.FormFactorTypes.MidTower, "Corsair", "Graphite Series™ 760T", 200);
        }

        public static Case CreateCase(Case.FormFactorTypes formFactor, string manufacturer, string model, double price)
        {
            return new Case(formFactor, manufacturer, model, price);
        }
    }
}
