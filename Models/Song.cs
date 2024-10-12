namespace ShoppingCart.Models;

/// <summary>
/// A song
/// </summary>
public class Song
{
    public int Id { get; set; }
    public String Title { get; set; }
    public Artist Artist { get; set; }

    public Song() {}
}
