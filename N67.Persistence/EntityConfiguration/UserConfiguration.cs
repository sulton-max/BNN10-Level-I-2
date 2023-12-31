﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.Domain.Entities;

namespace N67.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // host configuration - dependency and middleware and external config
        
        // db context configuration - db connection
        
        // entity configuration - entity vs database, entity constraint
        
        // builder.ToTable("Accounts");
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(256);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(256);
    }
}