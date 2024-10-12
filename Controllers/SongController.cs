namespace ShoppingCart.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using ShoppingCart.Models;

using System.Linq;

/// <summary>
/// Song Controller
/// </summary>
[ApiController]
[Route("/song")]
public class SongController
{

    private readonly AppDbContext _context;

    public SongController(AppDbContext context)
    {
	_context = context;
    }

    /// <summary>
    /// Get a song by Id
    /// </summary>
    /// <param name="songId">Id of the song</param>
    /// <returns>
    /// json with returned song
    /// </returns>
    [HttpGet("{songId:int}")]
    public JsonResult GetSong(int songId)
    {
	JsonResult json;
	var songs = _context.Songs.SingleOrDefault(song => song.Id == songId);
	json = new JsonResult(songs);
	json.StatusCode = songs == null ? 404 : 200; 
	return json;
    }

    /// <summary>
    /// Create a new song
    /// </summary>
    /// <param name="song">Song</param>
    /// <returns>
    /// ActionResult: status of the operation
    /// </returns>
    [HttpPost("")]
    public IResult CreateSong(Song song)
    {
	_context.Add(song);
	_context.SaveChanges();
	return Results.Created();
    }

}
