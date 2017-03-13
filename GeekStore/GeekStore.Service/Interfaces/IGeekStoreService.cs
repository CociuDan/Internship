using GeekStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekStore.Service.Interfaces
{
    public interface IGeekStoreService<T> where T : IItem
    {
        IEnumerable<T> GetItems();

        T GetItemByID(int itemID);

        void DeleteItemByID(int itemID);

        void StoreItem(T item);
    }
}
