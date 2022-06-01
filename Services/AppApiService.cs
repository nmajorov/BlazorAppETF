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

    public async Task<User> GetUser(){
        return await  _http.GetFromJsonAsync<User>("api/account/User");
     ;
    }

    
    public async Task Login(User login)
    {

        string serializedString = System.Text.Json.JsonSerializer.Serialize(login);
        Console.WriteLine($"serialized login: {serializedString}");
        var content = new StringContent(serializedString, System.Text.Encoding.UTF8, "application/json");

        var resp = await _http.PostAsync("api/account/login", content);
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