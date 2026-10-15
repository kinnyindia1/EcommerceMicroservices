
using Microsoft.AspNetCore.Mvc;


namespace Orders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public OrdersController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(int productId, int quantity)
    {
        var client = _clientFactory.CreateClient("CatalogService");

        // HTTP Communication between microservices
        var response = await client.GetAsync($"api/products/{productId}");

        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("Product does not exist in Catalog.");
        }

        // Proceed to save order (Simulated)
        var orderId = Guid.NewGuid();
        return Ok(new { OrderId = orderId, Status = "Created", TotalItems = quantity });
    }
}