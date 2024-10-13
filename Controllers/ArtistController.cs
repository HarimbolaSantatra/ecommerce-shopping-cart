namespace ShoppingCart.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using ShoppingCart.Models;

using System.Linq;

/// <summary>
/// Artist Controller
/// </summary>
[ApiController]
[Route("/artist")]
public class ArtistController
{

    private readonly AppDbContext _context;

    public ArtistController(AppDbContext context)
    {
	_context = context;
    }

    /// <summary>
    /// Get a artist by id
    /// </summary>
    /// <param name="artistId">Id of the artist</param>
    /// <returns>
    /// json with returned artist
    /// </returns>
    [HttpGet("{artistId:int}")]
    public JsonResult GetArtist(int artistId)
    {
	JsonResult json;
	var artists = _context.Artists.ToList().SingleOrDefault(artist => artist.Id == artistId);
	json = new JsonResult(artists);
	json.StatusCode = artists == null ? 404 : 200; 
	return json;
    }

    /// <summary>
    /// Create a new artist
    /// </summary>
    /// <param name="artist">Artist</param>
    /// <returns>
    /// ActionResult: status of the operation
    /// </returns>
    [HttpPost("")]
    public IResult CreateArtist(Artist artist)
    {
	_context.Add(artist);
	_context.SaveChanges();
	return Results.Created();
    }

}
