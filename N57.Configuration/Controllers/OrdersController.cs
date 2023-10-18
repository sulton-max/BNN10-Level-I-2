using Microsoft.AspNetCore.Mvc;
using N57.Configuration.Models;
using N57.Configuration.Services;

namespace N57.Configuration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> CreateOrder([FromBody] Order order, [FromServices] OrderService orderService)
    {
        await orderService.AddOrder(order);
        return Ok();
    }
}