using CaseApp.Klasser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseApp.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(int id);
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task UpdateUser(User user);
    }
}
