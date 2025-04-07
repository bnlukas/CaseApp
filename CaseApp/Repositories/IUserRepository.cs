using System; 
using Core;
using CaseApp.Klasser;

namespace CaseApp.Repositories
{
    public interface IUserRepository
    {
        public interface IInterface
        {
            IEnumerable<User> GetUsers();
            User GetUser(int id);
            void AddUser(User user);
            void DeleteUser(int id);
            void UpdateUser(User user);
        }
    }
}