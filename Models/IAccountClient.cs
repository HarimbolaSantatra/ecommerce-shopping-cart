namespace ShoppingCart.Models;
public interface IAccountClient {
    public async Task<string> TestService()
    {
	return "test";
    }
    public async Task<string> GetAccount(int userId)
    {
	return "Test";
    }
}
