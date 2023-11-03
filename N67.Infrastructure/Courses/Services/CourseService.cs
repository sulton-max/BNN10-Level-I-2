using Microsoft.EntityFrameworkCore;
using N67.Application.Courses.Services;
using N67.Domain.Entities;
using N67.Persistence.DataContexts;

namespace N67.Infrastructure.Courses.Services;

public class CourseService : ICourseService
{
    private readonly AppDbContext _appDbContext;

    public CourseService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default)
    {
        var user = await _appDbContext.Courses
            .Include(course => course.CourseStudents)
            .FirstOrDefaultAsync(course => course.Id == courseId, cancellationToken: cancellationToken);

        // user.Include(course => true)

        // .FirstOrDefault()
        // .FindAsync(courseId, cancellationToken);

        return user;
    }
}