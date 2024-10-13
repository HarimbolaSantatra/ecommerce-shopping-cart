namespace ShoppingCart.Controllers;

using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Models;

using System.Linq;

/// <summary>
/// Main Controller
/// </summary>
[ApiController]
[Route("/cart")]
public class CartController
{

    private readonly AppDbContext _context;
    public IAccountClient _accountClient;

    public CartController(AppDbContext context, IAccountClient accountClient)
    {
	_context = context;
	_accountClient = accountClient;
    }


    /// <summary>
    /// Check the health of the service and these which it depends on
    /// </summary>
    /// <returns>
    /// json
    /// </returns>
    [HttpGet("")]
    public async Task<JsonResult> Index()
    {
	var res = new Dictionary<String, String>();
	res.Add("status", "Cart service is working!");
	ObjectResult objectResult = await _accountClient.TestService();
	res.Add("account_test", objectResult.Value.ToString());

	// Create the JsonResult
	JsonResult jsonResult = new JsonResult(res);
	jsonResult.StatusCode = objectResult.StatusCode;
	return jsonResult;
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
	int statusCode;

	// TODO: check if the user exist


	var userCart = _context.Carts
	    .SingleOrDefault(cart => cart.Account.Id == userId);
	// Check if result is empty
	if (userCart == null)
	{
	    res.Add("status", "empty");
	    statusCode = 404;
	}
	else
	{
	    res.Add("status", "exist");
	    res.Add("cart", _context.Carts);
	    statusCode = 200;
	}
	JsonResult json = new JsonResult(res);
	json.StatusCode = statusCode;
	return json;
    }

}
