using GeekStore.Warehouse.Model;

namespace GeekStore.Warehouse.Repository.Interfaces
{
    public interface IStore<T> where T : IItem
    {
        void StoreItem(T item);
    }
}
