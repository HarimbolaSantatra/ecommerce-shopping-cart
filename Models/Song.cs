namespace ShoppingCart.Models;

/// <summary>
/// A song
/// </summary>
public class Song
{
    public int Id { get; set; }
    public String Title { get; set; }
    public List<Artist> Artists { get; set; } = [];
    public List<Cart> Carts { get; set; } = [];

    public Song() {}
}
