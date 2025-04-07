using System.Net.Http.Json;
using Blazored.LocalStorage;
using Core;

namespace CaseAppBlazor.Service.Login;

public class LoginServiceServerSide : LoginServiceClientSide
{
    private readonly HttpClient http;
    private string ServerUrl = "https://localhost:5284";

    public LoginServiceServerSide(ILocalStorageService ls, HttpClient http) : base(ls)
    {
        this.http = http;
    }

    protected override async Task<User?> Validate(string username, string password)
    {
        try
        {
            User? res = await http.GetFromJsonAsync<User>($"{ServerUrl}/api/login/validate?username={username}&password={password}");
            return res;
        }
        catch (Exception)
        {
            return null;
        }
    }
}