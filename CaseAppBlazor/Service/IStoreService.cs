using Core;

namespace CaseApp.Services;

public interface IStoreService
{
    Task<Store[]> GetAllAsync();
    Task<Store[]> GetRentedByUserAsync(User user);
    Task DeleteByIdAsync(int id);
    Task RentItemAsync(int itemId, User renter);
    Task ReturnItemAsync(int itemId);
}