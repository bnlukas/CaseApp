using System; 
using Core;

namespace CaseApp.Repositories;

public class UserRepository //  : IUserRepository 
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
        {
            new User
            {
                Name = "John Doe",
                Username = "JohnDoe",
                Password = "123456",
                Age = 21,
                PhoneNumber = 4212141,
                Address = "Main Street"

            };
        }
    }
}