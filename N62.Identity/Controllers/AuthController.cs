using Microsoft.AspNetCore.Mvc;
using N62.Identity.Models.Dtos;
using N62.Identity.Models.Entities;
using N62.Identity.Service;

namespace N62.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthController(TokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }

    [HttpPost]
    public IActionResult Login([FromBody]LoginDetails loginDetails)
    {
        // get user with email address and password in user service
        var user = new User
        {
            Id = Guid.NewGuid(),
            EmailAddress = loginDetails.EmailAddress,
            Password = loginDetails.Password
        };

        var data = _tokenGeneratorService.GetToken(user);
        return Ok(data);
    }
}