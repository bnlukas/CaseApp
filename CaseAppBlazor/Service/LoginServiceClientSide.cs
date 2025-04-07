namespace CaseAppBlazor.Service.Login;

public class LoginServiceClientSide : ILoginService
{
    private readonly ILocalStorageService localStore;

    public LoginServiceClientSide(ILocalStorageService ls)
    {
        localStore = ls;
    }

    public async Task<User?> GetUserLoggedIn()
    {
        User? res = await localStore.GetItemAsync<User>("user");
        return res;
    }

    public async Task<bool> Login(string username, string password)
    {
        User? u = await Validate(username, password);
        if (u != null)
        {
            u.Password = "validated";
            await localStore.SetItemAsync("user", u);
            return true;
        }
        return false;
    }

    private readonly List<User> user = new()
    {
        new User { Id = 1, Username = "rip", Password = "1234", Role = "Admin" },
        new User { Id = 2, Username = "rap", Password = "4211", Role = "User" },
        new User { Id = 3, Username = "rup", Password = "qweert", Role = "User" }
    };

    protected virtual Task<User?> Validate(string username, string password)
    {
        foreach (User u in user)
        {
            if (username.Equals(u.Username) && password.Equals(u.Password))
                return Task.FromResult<User?>(u);
        }
        return Task.FromResult<User?>(null);
    }
}