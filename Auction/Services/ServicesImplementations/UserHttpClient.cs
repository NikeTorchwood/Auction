using System.Text;
using Auction.Services.ServicesAbstractions;
using Newtonsoft.Json;

namespace Auction.Services.ServicesImplementations;

public class UserHttpClient
    : IUserHttpClient
{
    private readonly HttpClient _httpClient;
    public UserHttpClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(configuration.GetConnectionString("UsersService"));
    }
    public async Task<bool> CheckReservedEmail(string email)
    {
        using var response = await _httpClient.GetAsync($"CheckReservedEmail/{email}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CheckReservedUsername(string username)
    {
        using var response = await _httpClient.GetAsync($"CheckReservedUsername/{username}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RegisterUser(string username, string email, string passwordHash)
    {
        var requestData = new
        {
            Username = username,
            Email = email,
            PasswordHash = passwordHash
        };

        var json = JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await _httpClient.PostAsync("", content);
        return response.IsSuccessStatusCode;
    }
}