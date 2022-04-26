using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;


/// <summary>
/// Define operations on database or other application services 
/// </summary>
/// 
public interface IDataService
{   
    /// <summary>
    /// Get current logged user
    /// </summary>
    /// <returns>
    /// The current user from application context
    /// </returns>
    User? CurrentUser { get; set; }
}