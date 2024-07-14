namespace ShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
public interface IAccountClient {
    public async Task<ObjectResult> TestService()
    {
	return new ObjectResult("test");
    }
    public async Task<string> GetAccount(int userId)
    {
	return "Test";
    }
}
