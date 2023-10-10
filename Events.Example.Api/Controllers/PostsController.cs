using Events.Example.Api.Models.Entities;
using Events.Example.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Events.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostService _postService;

    public PostsController(PostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] BlogPost post)
    {
        var result = await _postService.Create(post);
        return Ok(result);
    }
}