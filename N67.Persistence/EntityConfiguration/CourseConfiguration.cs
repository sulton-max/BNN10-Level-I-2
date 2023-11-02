using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.Domain.Entities;

namespace N67.Persistence.EntityConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // One-to-One - HasOne WithOne
        // One-to-Many - HasMany WithOne yoki HasOne WithMany
        // Many-to-Many - HasMany WithMany

        builder.HasOne(course => course.Teacher)
            .WithMany(user => user.TeacherCourses)
            .HasForeignKey(course => course.TeacherId);

        builder.HasMany(course => course.Students)
            .WithMany(student => student.StudentCourses)
            .Use
            .UsingEntity<Dictionary<string, object>>(
                "StudentCourses", // The name of the join table
                j => j.HasOne<Course>().WithMany().HasForeignKey("CustomCourseId"), // Configure the Course foreign key
                j => j.HasOne<User>().WithMany().HasForeignKey("CustomStudentId") // Configure the Student foreign key
            );
            // .UsingEntity<>()
            // .UsingEntity(j =>
            // {
            //     j.ToTable("CourseStudents");
            //     j.HasOne(typeof(User)).WithMany().HasForeignKey("CourseId");
            //     j.HasOne(typeof(Course)).WithMany().HasForeignKey("StudentId");
            //     // j.HasKey( "StudentId", "CourseId");
            // });
    }
}