using N67.Domain.Entities;

namespace N67.Application.Courses.Services;

public interface ICourseService
{
    ValueTask<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default);
}