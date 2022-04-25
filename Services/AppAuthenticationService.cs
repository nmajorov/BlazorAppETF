namespace BlazorAppETF.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class AppAuthenticationService :AuthenticationStateProvider
{
    private readonly IAppApiService _appApi; 
    private readonly IDataService _dataService;
    public AppAuthenticationService(IAppApiService beamApi, IDataService dataSerivice)
    {
        _appApi = beamApi;
        _dataService = dataSerivice;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();

            
        var currentUser = _dataService.CurrentUser;
        if (currentUser == null || !currentUser.IsAuthenticated) {
            _dataService.CurrentUser = await _appApi.GetUser();
            currentUser = _dataService.CurrentUser;
        }

        if (currentUser.IsAuthenticated)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, _dataService.CurrentUser.UserName) }.Concat(_dataService.CurrentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
            identity = new ClaimsIdentity(claims, "Server authentication");
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));

    }


    
    
}

