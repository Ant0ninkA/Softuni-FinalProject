﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartyfyApp.Data.Models;

namespace PartyfyApp.Data.Configuration
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                 .Property(u => u.FirstName)
                 .HasDefaultValue("Test");

            builder
                 .Property(u => u.LastName)
                 .HasDefaultValue("Testov");
        }
    }
}
