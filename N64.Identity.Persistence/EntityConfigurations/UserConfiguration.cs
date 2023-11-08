using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);

        builder.HasData(new User
        {
            Id = Guid.Parse("cefdf4ea-215b-45cb-8069-40455d1c8336"),
            FirstName = "Admin",
            LastName = "Admin",
            Age = 0,
            EmailAddress = "",
            PasswordHash = "",
            IsEmailAddressVerified = true,
            RoleId = Guid.Parse("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf")
        });
    }
}