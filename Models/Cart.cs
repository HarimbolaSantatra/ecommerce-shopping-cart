namespace ShoppingCart.Models;

/// <summary>
/// A user's Cart
/// </summary>
public class Cart
{
    public int Id { get; set; }

    // one-to-one relationship
    public int AccountId { get; set; }
    public Account Account { get; set; } = null;

    // Many-to-many relationship
    public List<Song> Songs { get; set; } = [];


    public Cart () {}
}
