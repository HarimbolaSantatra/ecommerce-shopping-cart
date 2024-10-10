namespace ShoppingCart.Models;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Class <c>account_test</c> is used as a wrapper for everything around the 'Account' service
/// </summary>
public class AccountClient : IAccountClient {

    private readonly HttpClient _client = new HttpClient();

    public static string portEnv = Environment.GetEnvironmentVariable("PORT");
    public static string hostEnv = Environment.GetEnvironmentVariable("HOST");

    private int _accountPort;
    private string _baseUrl;
    private string _accountHost;

    public AccountClient()
    {

	if (!Int32.TryParse(portEnv, out _accountPort))
	{
	    // Use the default port if cannot read the envVar "PORT"
	    _accountPort = 5010;
	}

	_accountHost = String.IsNullOrEmpty(hostEnv) ? "127.0.0.1" : hostEnv;
	_baseUrl = $"http://{_accountHost}:{_accountPort}";

    }

    /// <summary>
    /// Test if the 'Account' service is working
    /// </summary>
    public async Task<ObjectResult> TestService()
    {
	string response;
	int statusCode;
	try
	{
	    response = await _client.GetStringAsync($"{_baseUrl}/status");
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

    /// <summary>
    /// Get the account of a user
    /// <param name="userId">The Id of the user</param>
    /// <returns>
    /// String
    /// </returns>
    /// </summary>
    public async Task<string> GetAccount(int userId)
    {
	// GET - account/<userId>
	string jsonResponse;
	try
	{
	    HttpResponseMessage response= await _client.GetAsync($"{_baseUrl}/account/{userId}");
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
