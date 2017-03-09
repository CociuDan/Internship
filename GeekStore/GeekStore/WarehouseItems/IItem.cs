namespace GeekStore.WarehouseItems
{
    interface IItem
    {
        string Description { get; }
        string Manufacturer { get; }
        string Model { get; }
        double Price { get; }
        int Quantity { get; }
        void AddToWarehouse(int incomingQuantity);
        void SellQuantity(int sellingQuantity);
        void ChangePrice(double newPrice);
    }
}
