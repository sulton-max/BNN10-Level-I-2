using N67.Application.Common.Identity.Services;
using N67.Application.Courses.Services;
using N67.Domain.Entities;
using N67.Persistence.DataContexts;

namespace N67.Infrastructure.Courses.Services;

public class  CourseProcessingService : ICourseProcessingService
{
    private readonly AppDbContext _appDbContext;
    private readonly ICourseService _courseService;
    private readonly IUserService _userService;

    public CourseProcessingService(AppDbContext appDbContext, ICourseService courseService, IUserService userService)
    {
        _appDbContext = appDbContext;
        _courseService = courseService;
        _userService = userService;
    }
    
    public async ValueTask<bool> AddStudent(Guid courseId, Guid studentId)
    {
        var course = await _courseService.GetByIdAsync(courseId) ?? throw new InvalidOperationException("");
        // var student = await _userService.GetByIdAsync(studentId) ?? throw new InvalidOperationException("");

        // var test = new CourseStudent
        // {
        //     StudentId = studentId,
        //     CourseId = courseId
        // };
        
        course.CourseStudents.Add(new CourseStudent
        {
            StudentId = studentId,
            CourseId = courseId
        });
        
        await _appDbContext.SaveChangesAsync();

        return true;
    }
}