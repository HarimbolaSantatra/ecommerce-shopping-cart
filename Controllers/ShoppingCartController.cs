namespace ShoppingCart.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

[ApiController]
[Route("/shoppingcart")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartStore shoppingCartStore;

    public ShoppingCartController(IShoppingCartStore shoppingCartStore)
    {
	this.shoppingCartStore = shoppingCartStore;
    }

    // Declares the endpoint for handling requests to /shoppingcart/{userid}
    [HttpGet("")]
    public string Index() =>
	"Shopping Cart Microservice is working ...";

    // Get a user's cart
    [HttpGet("{userId:int}")]
    public ShoppingCart GetUserCart(int userId) =>
	this.shoppingCartStore.Get(userId);

    // Add one item to a user shopping cart
    [HttpPost("{userId:int}/item")]
    public void AddItem(int userId, [FromBody] ShoppingCartItem shoppingCartItem)
    {
	Console.WriteLine("userId is " + userId);
	// Get the user's ShoppingCart
	ShoppingCart shoppingCart = GetUserCart(userId);
	// Update the ShoppingCart
	shoppingCart.AddItem(shoppingCartItem);
    }

    // Add multiple items to a user shopping cart
    [HttpPost("{userId:int}/items")]
    public void AddItems(int userId, IEnumerable<ShoppingCartItem> shoppingCartItems)
    {
	// Get the user's ShoppingCart
	ShoppingCart shoppingCart = GetUserCart(userId);
	// Update the ShoppingCart
	shoppingCart.AddItems(shoppingCartItems);
    }

}
