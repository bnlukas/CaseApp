using CaseAppBlazor.Service;
using Core;

namespace CaseApp.Services;
/*
public class StoreService : IStoreService
{
    private readonly  _storeRepository;
    private readonly ILoginService _loginService;

    public StoreService(IStoreService storeRepository, ILoginService loginService)
    {
        _storeRepository = storeRepository;
        _loginService = loginService;
    }

    // Henter alle produkter
    public async Task<Store[]> GetAllAsync()
    {
        return await Task.FromResult(_storeRepository.GetStores().ToArray());
    }

    // Henter produkter, der er lejet af en bestemt bruger
    public async Task<Store[]> GetRentedByUserAsync(User user)
    {
        var allItems = await GetAllAsync();
        return allItems.Where(item => item.RentedBy != null && item.RentedBy.Id == user.Id).ToArray();
    }

    // Sletter et produkt
    public async Task DeleteByIdAsync(int id)
    {
        _storeRepository.DeleteStore(id);
        await Task.CompletedTask;
    }

    // Udlåner et produkt til en bruger
    public async Task RentItemAsync(int itemId, User renter)
    {
        var item = _storeRepository.GetById(itemId);
        if (item != null && !item.Udlånt)
        {
            item.Udlånt = true;
            item.RentedBy = renter;
            _storeRepository.UpdateStore(item);
        }
        await Task.CompletedTask;
    }

    // Returnerer et produkt
    public async Task ReturnItemAsync(int itemId)
    {
        var item = _storeRepository.GetById(itemId);
        if (item != null && item.Udlånt)
        {
            item.Udlånt = false;
            item.RentedBy = null;
            _storeRepository.UpdateStore(item);
        }
        await Task.CompletedTask;
    }
}
*/