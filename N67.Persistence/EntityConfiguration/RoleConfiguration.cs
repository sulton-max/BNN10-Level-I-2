using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.Domain.Entities;

namespace N67.Persistence.EntityConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.UserId);

        builder.HasOne<User>().WithOne();
        // .HasForeignKey<Role>(role => role.UserId)
        // .HasPrincipalKey<Role>(role => role.UserId);
    }
}