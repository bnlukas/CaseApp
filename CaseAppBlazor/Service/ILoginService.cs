using Core;
using CaseAppBlazor; 
namespace CaseAppBlazor.Service;

public interface ILoginService
{
    // if user is logged in, the user will be returned
    // if no user is loogin in, null wil be returned
    Task<User?> GetUserLoggedIn();
    
    // if user is valid the function will return true and the 
    // is set to be logged in 
    
    Task<bool> Login(string username, string password);
}