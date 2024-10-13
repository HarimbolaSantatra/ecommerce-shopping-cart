namespace ShoppingCart.Models;

/// <summary>
/// A user's account
/// </summary>
public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int Balance { get; set; }

    // one-to-one relationship
    public Cart? Cart { get; set; }

    public Account() {}

    /// Check if an account has a cart
    public bool HasCart()
    {
	return Cart != null;
    }

}
