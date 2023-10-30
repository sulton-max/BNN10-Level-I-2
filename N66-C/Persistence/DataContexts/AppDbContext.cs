using Microsoft.EntityFrameworkCore;
using N66_C.Domain.Entities;

namespace N66_C.Persistence.DataContexts;

// Connection string - bu database yoki shunga o'xshash componentlarga ulanish uchun configuration

// { "Server": "localhost", "Database": "SomeAppDb", "UserName": "postgres", "Password": "postgres" }
// Server=localhost;Database=SomeAppDb;User=postgres;Password=postgres

public class AppDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();

    // Database connection configuration
    // 1-usuli - internal configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // write postgres connection string
        // Server=localhost;Database=MyFirstEfCoreApp;User=postgres;Password=postgres - sql server
        // Host=localhost;Port=5432;Database=MyFirstEfCoreApp;Username=postgres;Password=postgres - postgres
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyFirstEfCoreApp;Username=postgres;Password=postgres");
    }

    // Relationship configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // one-to-one relationship
        // modelBuilder.Entity<UserSettings>().HasOne<User>();
        // modelBuilder.Entity<UserSettings>().HasForeignKey(userSettings => userSettings.UserId);

        // one-to-many relationship
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasOne(book => book.Author).WithMany();

    }
}