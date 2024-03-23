namespace ShoppingCart.Models;
public class ShoppingCartStore : IShoppingCartStore
{
    private static readonly Dictionary<int, ShoppingCart>
	Database = new Dictionary<int, ShoppingCart>();

    // Get what's inside a user's cart
    public ShoppingCart Get(int userId) =>
	Database.ContainsKey(userId) ? Database[userId] : new ShoppingCart(userId);

    // Make a ShoppingCart owned by a User
    public void Save(ShoppingCart shoppingCart) =>
	Database[shoppingCart.UserId] = shoppingCart;

}
