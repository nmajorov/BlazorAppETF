namespace BlazorAppETF.Models.Account;
using Microsoft.AspNetCore.Identity;
/**
 * model for login page
 */
public class User : IdentityUser
{
    public bool RememberMe { get; set; }
    public bool IsAuthenticated { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}