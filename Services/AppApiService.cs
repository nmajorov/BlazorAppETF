using BlazorAppETF.Models.Account;

namespace BlazorAppETF.Services;

public class AppApiService: IAppApiService
{
    private HttpClient _http;

    public AppApiService(HttpClient httpClient)
    {
        _http = httpClient;
    }


    public void SetBaseUrl(String url)
    {
        _http.BaseAddress = new Uri(url);
    }

    public Task<User> GetUser(){
        return _http.GetFromJsonAsync<User>("api/User");
     ;
    }

    
    public async Task Login(User login)
    {
        var resp = await _http.PostAsJsonAsync("api/auth/login", login);
        if (!resp.IsSuccessStatusCode)
            throw new Exception(await resp.Content.ReadAsStringAsync());
    }

    public Task Register(User login)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }
}