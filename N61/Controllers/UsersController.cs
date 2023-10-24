using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using N61.Models;
using N61.Models.CustomExceptions;

namespace N61.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("testA")]
    public IActionResult GetTestA() => throw new EntityNotFoundException(Guid.NewGuid(), typeof(User));

    [HttpGet("testB")]
    public IActionResult GetTestB() => throw new InvalidEntityException("security message");

    [HttpGet("testC")]
    public IActionResult GetTestCs() => throw new EntityConflictException("");

    [HttpGet("{userId:guid}")]
    public IActionResult Get([FromRoute] Guid userId)
    {
        var result = new IdentityResult();
        result.Errors


        var user = null as User;
        return user != null ? Ok(user) : NotFound();
    }
}