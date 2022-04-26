using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;

public class DataService :IDataService
{
    public User? CurrentUser { get; set; }
}