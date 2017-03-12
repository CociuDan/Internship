using GeekStore.Warehouse.Model.Components;

namespace GeekStore.Factory
{
    public class CaseFactory
    {
        public static Case BuildCase()
        {
            return new Case(Case.FormFactorTypes.MidTower, "Corsair", "Graphite Series™ 760T", 200);
        }

        public static Case BuildCase(Case.FormFactorTypes formFactor, string manufacturer, string model, double price)
        {
            return new Case(formFactor, manufacturer, model, price);
        }
    }
}
