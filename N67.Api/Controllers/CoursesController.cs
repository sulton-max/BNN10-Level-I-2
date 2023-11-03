using Microsoft.AspNetCore.Mvc;
using N67.Application.Courses.Services;

namespace N67.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseProcessingService _courseProcessingService;

    public CoursesController(ICourseProcessingService courseProcessingService)
    {
        _courseProcessingService = courseProcessingService;
    }

    [HttpPost("{courseId:guid}/students/{studentId:guid}")]
    public async ValueTask<IActionResult> AddStudent([FromRoute] Guid courseId, [FromRoute] Guid studentId)
    {
        var result = await _courseProcessingService.AddStudent(courseId, studentId);
        return result ? Ok() : BadRequest();
    }
}