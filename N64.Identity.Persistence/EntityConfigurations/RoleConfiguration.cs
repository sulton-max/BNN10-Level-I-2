using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N64.Identity.Domain.Entities;
using N64.Identity.Domain.Enums;

namespace N64.Identity.Persistence.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.Type).IsUnique();

        builder.HasData(new Role
            {
                Id = Guid.Parse("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                Type = RoleType.Admin,
                CreatedTime = DateTime.UtcNow,
            },
            new Role
            {
                Id = Guid.Parse("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                Type = RoleType.Guest,
                CreatedTime = DateTime.UtcNow,
            },
            new Role
            {
                Id = Guid.Parse("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                Type = RoleType.Host,
                CreatedTime = DateTime.UtcNow,
            });
    }
}