namespace ShoppingCart.Models;

public record ShoppingCartItem(
	int ProductCatalogueId,
	string ProductName,
	string Description,
	int Price)
{

    public virtual bool Equals(ShoppingCartItem? obj) =>
	obj != null && this.ProductCatalogueId.Equals(obj.ProductCatalogueId);

    public override int GetHashCode() =>
	this.ProductCatalogueId.GetHashCode();

}
