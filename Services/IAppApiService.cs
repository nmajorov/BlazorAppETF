using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;

/// <summary>
/// Internal http calls from web ui to local backend application
/// </summary>
public interface IAppApiService
{
    Task<User> GetUser();
}