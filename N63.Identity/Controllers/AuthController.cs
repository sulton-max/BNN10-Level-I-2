using Microsoft.AspNetCore.Mvc;
using N63.Identity.Models.Dtos;
using N63.Identity.Models.Entities;
using N63.Identity.Service;

namespace N63.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        var result = await _authService.RegisterAsync(registrationDetails);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var result = await _authService.LoginAsync(loginDetails);
        return Ok(result);
    }
}