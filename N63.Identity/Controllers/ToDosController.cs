using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N63.Identity.Constants;
using N63.Identity.Models.Dtos;
using N63.Identity.Service;

namespace N63.Identity.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ToDosController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;
        return Ok(userId);
    }
}