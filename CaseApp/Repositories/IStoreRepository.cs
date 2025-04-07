using System; 
using Core;
namespace CaseApp.Repositories;



public interface IStoreRepository
{
    IEnumerable<Store> GetStores();
    Store GetById(int id);
    Store AddStore(Store store);
    void UpdateStore(Store store);
    void DeleteStore(int id);
     
}