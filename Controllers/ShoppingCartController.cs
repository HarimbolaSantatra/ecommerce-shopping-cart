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

    // Declares the endpoint for handling requests to /shoppingcart/{userid}
    [HttpGet("{userId:int}")]
    public ShoppingCart Get(int userId) =>
	this.shoppingCartStore.Get(userId);

    // Add item to a user shopping cart
    [HttpPost("{userId:int}/items")]
    public void AddItem(int userId, IEnumerable<ShoppingCartItem> shoppingCartItems)
    {
	// Get the user's ShoppingCart
	ShoppingCart shoppingCart = Get(userId);
	// Update the ShoppingCart
	shoppingCart.AddItems(shoppingCartItems);
    }

}
