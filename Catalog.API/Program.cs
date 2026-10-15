
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
// Root check to prevent 404 on base URL
app.MapGet("/", () => Results.Ok(new { message = "Catalog API is running" }));
app.MapControllers();
app.Run("http://localhost:5000");
