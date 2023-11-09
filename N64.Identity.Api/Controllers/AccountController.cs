using Microsoft.AspNetCore.Mvc;
using N64.Identity.Application.Common.Identity.Services;

namespace N64.Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
    {   
        var result = await _accountService.VerificateAsync(token);
        return Ok(result);
    }
}