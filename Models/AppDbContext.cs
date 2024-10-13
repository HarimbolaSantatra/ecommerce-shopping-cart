namespace ShoppingCart.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public DbSet<Cart> Carts { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	optionsBuilder.UseMySQL("server=localhost;database=music-stream;user=root;password=root");
    }

    // Configure Data Seeding using FluentAPI
    // Data seeding: put initial data inside the database
    // See https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

	// configure ArtistSong as a join entity for the relationship Artist-Song
	// See https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#basic-many-to-many
	modelBuilder.Entity<Artist>()
        .HasMany(e => e.Songs)
        .WithMany(e => e.Artists)
        .UsingEntity<ArtistSong>();

	modelBuilder.Entity<Account>().HasData(new Account {
		Id = 1,
		Username = "santatra",
		Balance = 5000
		});
	modelBuilder.Entity<Cart>().HasData(new Cart {
		Id = 1,
		AccountId = 1
		});

	Artist theWeeknd = new Artist() { Id = 1, Name = "The Weeknd" };
	Artist deadmau5 = new Artist() { Id = 2, Name = "deadmau5" };

	modelBuilder.Entity<Artist>().HasData(theWeeknd);
	modelBuilder.Entity<Artist>().HasData(deadmau5);

	modelBuilder.Entity<Song>().HasData(new Song {
		Id = 1,
		Title = "Save Your Tears",
		});
	modelBuilder.Entity<Song>().HasData(new Song {
		Id = 2,
		Title = "Strobe",
		});


	modelBuilder.Entity<ArtistSong>().HasData(new ArtistSong(){
		ArtistId = 1, SongId = 1
		});
	modelBuilder.Entity<ArtistSong>().HasData(new ArtistSong(){
		ArtistId = 2, SongId = 2
		});

    }

}
