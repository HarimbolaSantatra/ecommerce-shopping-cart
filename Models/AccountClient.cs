namespace ShoppingCart.Models;

using Microsoft.AspNetCore.Mvc;

public class AccountClient : IAccountClient {

    public readonly HttpClient _client = new HttpClient();
    public static int AccountPort = 5010;
    public static string BaseUrl = $"http://127.0.0.1:{AccountPort}";

    public AccountClient()
    {}

    // Test if the 'Account' service is working
    public async Task<ObjectResult> TestService()
    {
	string response;
	int statusCode;
	try
	{
	    response = await _client.GetStringAsync($"{BaseUrl}/status");
	    statusCode = 200;
	}
	catch (HttpRequestException e)
	{
	    response = "Account services not ready!";
	    statusCode = 500;
	}
	ObjectResult res = new ObjectResult(response);
	res.StatusCode = statusCode;
	return res;
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
