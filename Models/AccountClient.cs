namespace ShoppingCart.Models;
using System.Net.Http;
public class AccountClient : IAccountClient {

    public readonly HttpClient _client = new HttpClient();
    public static int AccountPort = 5010;
    public static string BaseUrl = $"http://127.0.0.1:{AccountPort}";

    public AccountClient()
    {}

    // Test if the 'Account' service is working
    public async Task<string> TestService()
    {
	HttpResponseMessage response= await _client.GetAsync($"{BaseUrl}/status");
	string jsonResponse = await response.Content.ReadAsStringAsync();
	return jsonResponse;
    }

    public async Task<string> GetAccount(int userId)
    {
	// GET - account/<userId>
	HttpResponseMessage response= await _client.GetAsync($"{BaseUrl}/account/{userId}");
	// response.EnsureSuccessStatusCode().WriteRequestToConsole();
	string jsonResponse = await response.Content.ReadAsStringAsync();
	Console.WriteLine($"{jsonResponse}\n");
	return jsonResponse;
    }

}
