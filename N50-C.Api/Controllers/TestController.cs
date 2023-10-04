using Microsoft.AspNetCore.Mvc;
using N50_C.Api.Services;

namespace N50_C.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("singleton")]
    public IActionResult Get([FromServices] SingletonService serviceA, [FromServices] SingletonService serviceB)
    {
        return Ok(new
        {
            serviceAId = serviceA.Id,
            serviceBId = serviceB.Id
        });
    }

    [HttpGet("scoped")]
    public IActionResult Get([FromServices] ScopedService serviceA, [FromServices] ScopedService serviceB)
    {
        return Ok(new
        {
            serviceAId = serviceA.Id,
            serviceBId = serviceB.Id
        });
    }

    [HttpGet("transient")]
    public IActionResult Get([FromServices] TransientService serviceA, [FromServices] TransientService serviceB)
    {
        return Ok(new
        {
            serviceAId = serviceA.Id,
            serviceBId = serviceB.Id
        });
    }
}