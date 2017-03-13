using GeekStore.Model;
using System.Collections.Generic;
using GeekStore.Repository.Interfaces;
using GeekStore.Service.Interfaces;
using GeekStore.Repository.Implimentation;

namespace GeekStore.Service.Implimentation
{
    public class GeekStoreService : IGeekStoreService<IItem>
    {
        private IStorage<IItem> _storage = new ListStorage();

        public void DeleteItemByID(int itemID)
        {
            _storage.DeleteItemByID(itemID);
        }

        public IItem GetItemByID(int itemID)
        {
            return _storage.GetItemByID(itemID);
        }

        public IEnumerable<IItem> GetItems()
        {
            return _storage.GetItems();
        }

        public void StoreItem(IItem item)
        {
            _storage.StoreItem(item);
        }
    }
}
