using Microsoft.AspNetCore.Mvc;

namespace N62_C.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    public UsersController()
    {
    }

    [HttpGet]
    public IActionResult Get()
    {

        return Ok();
    }
}