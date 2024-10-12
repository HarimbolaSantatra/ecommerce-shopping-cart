namespace ShoppingCart.Models;

/// <summary>
/// A user's Cart
/// </summary>
public class Cart
{
    public int Id { get; set; }

    // Relationship
    public int AccountId { get; set; }
    public Account Account { get; set; } = null;


    public Cart () {}
}
