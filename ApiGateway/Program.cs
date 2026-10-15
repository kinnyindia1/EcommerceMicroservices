var builder = WebApplication.CreateBuilder(args);
// Add YARP Reverse Proxy services
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapGet("/", () => Results.Ok("API Gateway is running!"));
// Map YARP reverse proxy routes
app.MapReverseProxy();
app.Run("http://localhost:8000");