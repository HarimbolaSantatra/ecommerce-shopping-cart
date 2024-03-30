WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ShoppingCart.Models.IShoppingCartStore, ShoppingCart.Models.ShoppingCartStore>();

// Add logger
builder.Services.AddScoped<ILogger<ShoppingCart.Controllers.ShoppingCartController>, Logger<ShoppingCart.Controllers.ShoppingCartController>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
