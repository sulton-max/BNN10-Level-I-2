using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N64.Identity.Application.Common.Constants;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;

namespace N64.Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDetails registrationDetails, CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(registrationDetails, cancellationToken);
        return result ? Ok() : BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails, CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(loginDetails);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("users/{userId:guid}/roles/{roleType}")]
    public async ValueTask<IActionResult> GrandRole([FromRoute] Guid userId, [FromRoute] string roleType, CancellationToken cancellationToken)
    {
        var actionUserId = Guid.Parse(User.Claims.First(claim => claim.Type.Equals(ClaimConstants.UserId)).Value);
        var result = await _authService.GrandRoleAsync(userId, roleType, actionUserId, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}