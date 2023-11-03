using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N67.Persistence.DataContexts;

namespace N67.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromServices] AppDbContext dbContext)
    {
        var results = await dbContext.Locations.ToListAsync();
        return Ok(results);
    }
}