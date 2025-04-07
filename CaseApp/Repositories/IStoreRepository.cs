using CaseApp.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseApp.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetStores();       // Get all stores
        Task<Store> GetById(int id);                // Get store by ID
        Task AddStore(Store store);                 // Add new store
        Task UpdateStore(Store store);              // Update existing store
        Task DeleteStore(int id);                   // Delete store by ID
    }
}
