namespace ShoppingCart.Models;
public interface IAccountClient {
    public async Task<string> GetAccount(int userId)
    {
	return "Test";
    }
}
