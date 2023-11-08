using Microsoft.EntityFrameworkCore;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Persistence.DataContexts;

public class IdentityDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
        var users = Users.ToList();

        // var user = new User();

        // Users.Add(user);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}