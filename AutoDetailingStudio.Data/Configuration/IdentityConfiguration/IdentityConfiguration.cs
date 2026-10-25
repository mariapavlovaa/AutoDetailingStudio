using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingStudio.Data.Configuration.IdentityConfiguration;

public class IdentityConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
        {
            Id = "admin-role",
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = "admin-role-stamp"
        });
    }
}