namespace ShoppingCart.Controllers;

using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Models;

using System.Linq;

/// <summary>
/// Main Controller
/// </summary>
[ApiController]
[Route("/")]
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
	    .SingleOrDefault(cart => cart.UserId == userId);
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

    /// Check if a user with id 'userId' have a cart
    public bool UserHasCart (int userId)
    {
	return _context.Carts.Any(cart => cart.UserId == userId);
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
	JsonResult json;

	// check if user already has a cart
	if (UserHasCart(cart.UserId))
	{
	    res.Add("operation", "duplicate cart");
	    json = new JsonResult(res);
	    json.StatusCode = 204;
	    return json;
	}

	// Get the cart
	var carts = _context.Carts;
	carts.Add(cart);
	_context.SaveChanges();


	res.Add("operation", "updated");
	res.Add("cart", cart.Serialize());
	json = new JsonResult(res);
	json.StatusCode = 200;

	return json;
    }


    /// <summary>
    /// Add items to a user's cart
    /// </summary>
    /// <param name="cartId">The id of a Cart object (int)</param>
    /// <param name="itemsIds">A list of Item.Id</param>
    /// <returns>
    /// Json Result
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///         "cartId": 1,
    ///         "items": { 
    ///     }
    ///
    /// </remarks>
    [HttpPost("items")]
    public JsonResult AddItems(int cartId, List<int> itemsIds)
    {
	Dictionary<string, object> res = new Dictionary<string, object>();
	JsonResult json;

	var cart = _context.Carts.SingleOrDefault(cart => cart.Id == cartId);
	if (cart == null)
	{
	    res.Add("status", $"Cart id {cartId} does not exists!");
	    json = new JsonResult(res);
	    json.StatusCode = 404;
	    return json;
	}

	// check if user already has a cart
	if (!UserHasCart(cart.UserId))
	{
	    res.Add("status", "User doesn't have a cart!");
	    json = new JsonResult(res);
	    json.StatusCode = 404;
	    return json;
	}

	List<Item> items = _context.Items.ToList();
	IEnumerable<Item> filteredItem = items.Where(item => itemsIds.Contains(item.Id));

	foreach (Item item in filteredItem)
	{
	    cart.Items.Add(item);
	}
	_context.SaveChanges();
	json = new JsonResult(res);
	return json;
    }

}
