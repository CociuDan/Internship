using System;
using System.Collections.Generic;
using GeekStore.Model;
using GeekStore.Repository.Interfaces;

namespace GeekStore.Repository.Implimentation
{
    public class ListStorage : IStorage<IItem>
    {
        private List<IItem> _warehouseItems = new List<IItem>();

        public void StoreItem(IItem item)
        {
            _warehouseItems.Add(item);
        }

        public void DeleteItemByID(int itemID)
        {
            throw new NotImplementedException();
        }

        public IItem GetItemByID(int itemID)
        {
            return _warehouseItems.Find(x => x.ID == itemID);
        }

        public IEnumerable<IItem> GetItems()
        {
            return _warehouseItems;
        }
    }
}
