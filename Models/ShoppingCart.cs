namespace ShoppingCart.Models;

using System.Collections.Generic;
using System.Linq;

public class ShoppingCart
{

    private readonly HashSet<ShoppingCartItem> items = new();

    public int UserId { get; }

    public IEnumerable<ShoppingCartItem> Items => this.items;

    // Constructor
    public ShoppingCart(int userId)
    {
	this.UserId = userId;
    }

    public void AddItem(ShoppingCartItem shoppingCartItem)
    {
	this.items.Add(shoppingCartItem);
    }

    public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
    {
	foreach (var item in shoppingCartItems)
	    this.items.Add(item);
    }

    public void RemoveItems(int[] productCatalogueIds) =>
	this.items.RemoveWhere(i => productCatalogueIds.Contains(
		    i.ProductCatalogueId));
}
