namespace ShoppingCart.Models;

/// <summary>
/// A join class for the many-to-many relationship between Artist and Song
/// </summary>
public class ArtistSong
{
    /// <summary>
    /// The Id of the Artist
    /// </summary>
    public int ArtistId { get; set; }
    /// <summary>
    /// The Id of the Song
    /// </summary>
    public int SongId { get; set; }

}
