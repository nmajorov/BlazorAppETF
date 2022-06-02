using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{


    private readonly IDataService _dataService;
    private readonly AccountService _accountService;

    public AppAuthenticationStateProvider(IDataService dataService, AccountService accountService)
    {
        _dataService = dataService;
        _accountService = accountService;
    }


    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();

        var currentUser = _dataService.CurrentUser;
        if (currentUser == null || !currentUser.IsAuthenticated)
        {
            //TODO implement?
        }
        else if (currentUser.IsAuthenticated)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, currentUser.UserName) }
                .Concat(currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
            identity = new ClaimsIdentity(claims, "Server authentication");
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));

    }



    public async Task Login(RegisterLoginViewModel model)
    {

        var user = await _accountService.Login(model);
        _dataService.CurrentUser = user;

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    }

    public async Task Register(RegisterLoginViewModel model)
    {
        await _accountService.Register(model);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}

