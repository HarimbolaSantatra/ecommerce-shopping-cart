WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ShoppingCart.ShoppingCart.IShoppingCartStore, ShoppingCart.ShoppingCart.ShoppingCartStore>();

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
