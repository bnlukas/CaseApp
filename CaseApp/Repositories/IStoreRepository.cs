using System; 
using Core;
namespace CaseApp.Repositories;

using CaseApp.Klasser;

public interface IStoreRepository
{
    IEnumerable<Store> GetStores();
    Store GetById(int id);
    Store AddStore(Store store);
    void UpdateStore(Store store);
    void DeleteStore(int id);
     
}