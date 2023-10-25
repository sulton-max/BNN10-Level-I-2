using Microsoft.AspNetCore.Mvc;
using N63.Rest.Services;

namespace N63.Rest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderProcessingService _orderProcessingService;

    public OrdersController(OrderProcessingService orderProcessingService)
    {
        _orderProcessingService = orderProcessingService;
    }

    [HttpPost("error")]
    public async Task<IActionResult> CreateOrderA([FromBody] IList<Guid> productsId)
    {
        var result = await _orderProcessingService.CreateOrderAsync(productsId, Guid.NewGuid());
        return Ok(result);
    }

    [HttpPost("fault")]
    public async Task<IActionResult> CreateOrderB([FromBody] IList<Guid> productsId)
    {
        var result = await _orderProcessingService.CreateOrderAsync(productsId, Guid.NewGuid());
        return Ok(result);
    }
}