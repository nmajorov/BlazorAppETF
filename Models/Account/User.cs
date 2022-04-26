namespace BlazorAppETF.Models.Account;
using Microsoft.AspNetCore.Identity;

/// <summary>
///  User in the application 
/// </summary>
public class User : IdentityUser
{
    public bool RememberMe { get; set; }
    public bool IsAuthenticated { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}