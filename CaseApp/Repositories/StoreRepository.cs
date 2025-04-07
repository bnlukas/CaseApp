using System; 
using Core;

namespace CaseApp.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly List<Store> _stores;

    public StoreRepository()
    {
        _stores = new List<Store>
        {
            new Store
            {
                Id = 1,
                Category = "Hoodie",
                Color = "Blue",
                PhoneNumber = 50312021,
                Brand = "Samsø Samsø",
                Price = 4955,
                Description = "Used"
            }
        };
    }

    public IEnumerable<Store> GetStores()
    {
        return _stores;
    }

    public Store GetById(int id)
    {
        return _stores.FirstOrDefault(s => s.Id == id);
    }

    public Store AddStore(Store store)
    {
        store.Id = _stores.Max(s => s.Id) + 1;
        _stores.Add(store);
        return store;
    }

    public void UpdateStore(Store store)
    {
        var index = _stores.FindIndex(s => s.Id == store.Id);
        if (index != -1)
        {
            _stores[index] = store;
        }
    }

    public void DeleteStore(int id)
    {
        var store = GetById(id);
        if (store != null)
        {
            _stores.Remove(store);
        }
    }
}