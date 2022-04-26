using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;

/// <summary>
/// Internal http calls from web ui to local backend application
/// </summary>
public interface IAppApiService
{
    public void SetBaseUrl(String url);
    Task<User?> GetUser();
    Task Login(User login);
    Task Register(User login);
    Task Logout();
}