using System.Reflection.Metadata;
using Microsoft.AspNetCore.Components; 
using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using Core;


namespace CaseAppBlazor.Service.Login;

public class LoginServiceClientSide : ILoginService
{
    private ILocalStorageService localStore {get; set;}

    public LoginServiceClientSide(ILocalStorageService ls)
    {
        localStore = ls;
    }

    public async Task<User?> GetUserLoggedIn()
    {
        User? res = await localStorage.GetItemAsync<User>("user");
        return res;
    }

    public async Task<bool> Login(string username, string password);
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

    private List<User> user = new List<User>()
    {
        new User { Id = 1, UserName = "rip", Password = "1234", Role = "Admin" },
        new User { Id = 2, UserName = "rap", Password = "4211", Role = "User" },
        new User { Id = 3, UserName = "rup", Password = "qweert", Role = "User" }
    };

    protected virtual async Task<User?> Validate(string username, string password)
    {
        foreach (User u in users)
        {
            if (username.Equals(u.UserName) && password.Equals(u.Password))
                return u;

            return null; 
        }
    }
}
