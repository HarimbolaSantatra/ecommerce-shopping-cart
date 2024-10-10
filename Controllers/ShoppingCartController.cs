namespace ShoppingCart.Controllers;

using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Models;
using ShoppingCart.Utils;

using System.Linq;

[ApiController]
[Route("/")]
public class ShoppingCartController
{

    private readonly AppDbContext _context;
    public IAccountClient _accountClient;

    public ShoppingCartController(AppDbContext context, IAccountClient accountClient)
    {
	_context = context;
	_accountClient = accountClient;
    }


    /// <summary>
    /// Declares the endpoint for handling requests
    /// </summary>
    /// <returns>
    /// Test JSON status
    /// </returns>
    [HttpGet("")]
    public async Task<JsonResult> Index()
    {
	var res = new Dictionary<String, String>();
	res.Add("status", "ShoppingCart microservice is working!");
	ObjectResult objectResult = await _accountClient.TestService();
	res.Add("account_test", objectResult.Value.ToString());

	// Create the JsonResult
	JsonResult jsonResult = new JsonResult(res);
	jsonResult.StatusCode = objectResult.StatusCode;
	return jsonResult;
    }


    /// <summary>
    /// Test the status of the 'Cart' microservice
    /// </summary>
    /// <returns>
    /// string
    /// </returns>
    [HttpGet("status")]
    public string GetStatus()
    {
	return "ShoppingCart microservice is working!";
    }


    /// <summary>
    /// Get a user's cart
    /// </summary>
    /// <returns>
    /// The Cart object
    /// </returns>
    [HttpGet("{userId:int}")]
    public ActionResult GetUserCart(int userId)
    {
	var res = new Dictionary<string, object>();

	// TODO: check if the user exist


	var userCart = _context.Carts
	    .SingleOrDefault(cart => cart.UserId == userId);
	// Check if result is empty
	if (userCart == null)
	{
	    res.Add("status", "empty");
	}
	else
	{
	    res.Add("status", "exist");
	    res.Add("cart", _context.Carts);
	}
	return new JsonResult(res);
    }

    /// <summary>
    /// Add a cart for a user
    /// </summary>
    /// <returns>
    /// The JSON representation of the created Cart object
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///         "Id": 1,
    ///         "UserId": 1
    ///     }
    ///
    /// </remarks>
    [HttpPost("cart")]
    public ActionResult AddCart (Cart cart)
    {

	Dictionary<string, object> res = new Dictionary<string, object>();

	// Get the cart
	var carts = _context.Carts;
	carts.Add(cart);
	_context.SaveChanges();


	res.Add("operation", "updated");
	res.Add("cart", cart.Serialize());

	return new JsonResult(res);
    }


}
