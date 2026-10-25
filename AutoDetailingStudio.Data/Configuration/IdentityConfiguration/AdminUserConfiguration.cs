using AutoDetailingStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingStudio.Data.Configuration.IdentityConfiguration;

public class AdminUserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        User admin = new User()
        {
            Id = "admin-user",
            UserName = "admin@autodetailingstudio.com",
            NormalizedUserName = "ADMIN@AUTODETAILINGSTUDIO.COM",
            Email = "admin@autodetailingstudio.com",
            NormalizedEmail = "ADMIN@AUTODETAILINGSTUDIO.COM",
            EmailConfirmed = true,
            FirstName = "System",
            LastName = "Administrator",
            SecurityStamp = "admin-security-stamp",
            ConcurrencyStamp = "admin-concurrency-stamp", 
            PasswordHash = "AQAAAAIAAYagAAAAECj4mF/MvU2l4sPYabNt6j/1+dfZtBSSs7zbcAmBf47xv1a1uvkb56ixiuOuXppU8Q=="
        };

      
        builder.HasData(admin);
        
        

    }
}