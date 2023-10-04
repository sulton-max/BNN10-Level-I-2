using Di.Api.Models.Entities;
using Di.Api.Models.Filters;
using Di.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Di.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    // Injecting IUserService - mana shu dependency ni so'rash
    public UsersController(IUserService userService)
    {
        Console.WriteLine("User controller yaratildi");
        _userService = userService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<IEnumerable<User>>> GetUsers([FromBody]UserFilterModel filterModel)
    {
        var result = await _userService.GetAsync(filterModel);
        return Ok(result);
    }
}