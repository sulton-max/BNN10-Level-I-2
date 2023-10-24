using Microsoft.AspNetCore.Mvc;
using N62.Identity.Models.Entities;
using N62.Identity.Service;

namespace N62.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTasksController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoTasksController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromQuery]Guid userId, [FromBody]TodoTask todoTask)
    {
        var todo = await _todoService.CreateAsync(todoTask, userId);
        return Ok(todo);
    }
}