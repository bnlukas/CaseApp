namespace CaseApp.Repositories;
using Core;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUser(int id);
    void AddUser(User user);
    void DeleteUser(int id);
    void UpdateUser(User user);
}