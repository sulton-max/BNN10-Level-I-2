namespace N67.Application.Courses.Services;

public interface ICourseProcessingService
{
    ValueTask<bool> AddStudent(Guid courseId, Guid studentId);
}