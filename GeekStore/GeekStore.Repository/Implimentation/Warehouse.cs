using System.Collections.Generic;
using GeekStore.Warehouse.Model;
using GeekStore.Warehouse.Repository.Interfaces;

namespace GeekStore.Warehouse.Repository.Implimentation
{
    public class Warehouse : IStore<IItem>
    {
        List<IItem> warehouseItems = new List<IItem>();
        public void StoreItem(IItem item)
        {
            warehouseItems.Add(item);
        }
    }
}
