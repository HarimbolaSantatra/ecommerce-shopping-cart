namespace ShoppingCart.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public DbSet<Cart> Carts { get; set; }
    public DbSet<Item> Items { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	optionsBuilder.UseMySQL("server=localhost;database=music-stream;user=root;password=root");
    }

}
