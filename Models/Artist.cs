namespace ShoppingCart.Models;

/// <summary>
/// An artist
/// </summary>
public class Artist
{
    public int Id { get; set; }
    public String Name  { get; set; }

    public List<Song> Songs { get; } = [];

    public Artist () {}
}
