using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class AppAuthenticationStateProvider :AuthenticationStateProvider
{

     
    private readonly IDataService _dataService;
    private readonly AccountService _accountService;

    public AppAuthenticationStateProvider(IDataService dataService,AccountService accountService)
    {
        _dataService = dataService;
        _accountService =accountService;
    }


    public IAppApiService API{
        get;
        set;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();

        var currentUser = _dataService.CurrentUser;
        if (currentUser == null || !currentUser.IsAuthenticated)
        { 
            Console.WriteLine("API is Null? {0}",(API !=null) );
            if (API != null){
                _dataService.CurrentUser = await API.GetUser();
            }
            
          currentUser = _dataService.CurrentUser;
        }       
        if (currentUser.IsAuthenticated)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, _dataService.CurrentUser.UserName) }.Concat(_dataService.CurrentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
            identity = new ClaimsIdentity(claims, "Server authentication");
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));

    }


    
    public async Task Login(User login)
    {
        
            await _accountService.Login(login);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        
    }
    
}

