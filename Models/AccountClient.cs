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
	string jsonResponse;
	try
	{
	    HttpResponseMessage response= await _client.GetAsync($"{BaseUrl}/status");
	    jsonResponse = await response.Content.ReadAsStringAsync();
	}
	catch
	{
	    jsonResponse = "Account services not ready!";
	}
	return jsonResponse;
    }

    public async Task<string> GetAccount(int userId)
    {
	// GET - account/<userId>
	string jsonResponse;
	try
	{
	    HttpResponseMessage response= await _client.GetAsync($"{BaseUrl}/account/{userId}");
	    // response.EnsureSuccessStatusCode().WriteRequestToConsole();
	    jsonResponse = await response.Content.ReadAsStringAsync();
	    Console.WriteLine($"{jsonResponse}\n");
	}
	catch (HttpRequestException e)
	{
	    jsonResponse = "Account services not ready!";
	}
	return jsonResponse;
    }

}
