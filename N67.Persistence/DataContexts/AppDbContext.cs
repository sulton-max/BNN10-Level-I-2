using Microsoft.EntityFrameworkCore;
using N67.Domain.Entities;
using N67.Persistence.EntityConfiguration;

namespace N67.Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    
    public DbSet<CourseStudent> StudentCourses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Automatic registration of entity configuration - bu narsa hamma entity configurationlarni registratsiya qiladi
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // modelBuilder.ApplyConfiguration(new CourseConfiguration());

        // Manual registration of entity configuration
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}