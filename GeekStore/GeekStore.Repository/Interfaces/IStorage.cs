using GeekStore.Model;
using System.Collections.Generic;

namespace GeekStore.Repository.Interfaces
{
    public interface IStorage<T> where T : IItem
    {
        IEnumerable<T> GetItems();

        T GetItemByID(int itemID);

        void DeleteItemByID(int itemID);

        void StoreItem(T item);
    }
}
