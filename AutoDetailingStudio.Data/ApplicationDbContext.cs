using AutoDetailingStudio.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Data;

public class ApplicationDbContext:IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
    {
        
    }

    public virtual DbSet<Appointment> Appointments { get; set; } = null!;
    public virtual DbSet<Car> Cars { get; set; } = null!;
    public virtual DbSet<Service> Services { get; set; } = null!;
    public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Appointment>()
            .HasOne(a => a.Car)
            .WithMany(c => c.Appointments)
            .HasForeignKey(a => a.CarId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}