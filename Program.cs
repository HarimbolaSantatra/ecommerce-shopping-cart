WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ShoppingCart.Models.IShoppingCartStore, ShoppingCart.Models.ShoppingCartStore>();

// Using Scrutor for DI
// builder.Services.Scan(selector =>
// selector
// .FromAssemblyOf<Program>()
// .AddClasses()
// .AsImplementedInterfaces()
// );

var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
