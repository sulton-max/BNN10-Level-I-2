using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.Domain.Entities;

namespace N67.Persistence.EntityConfiguration;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.StudentId });
        
        builder.HasOne(x => x.Course).WithMany(i => i.CourseStudents).HasForeignKey(x => x.CourseId);

        builder.HasOne(c => c.Student).WithMany(u => u.CourseStudents).HasForeignKey(c => c.StudentId);
    }
}