using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoDetailingStudio.Data.Models;


namespace AutoDetailingStudio.Data.Configuration;

public class SubscriptionConfiguration:IEntityTypeConfiguration<Subscription>
{
    private readonly List<Subscription> subscriptions = new List<Subscription>
    {
        new Subscription
        {
            Id = 1,
            Name = "Basic",
            Description = "Basic car care subscription with a 5% discount on all services.",
            Price = 29.99m, 
            DiscountPercent = 5.00m,
            IsActive = true
        },
        new Subscription
        {
            Id = 2,
            Name = "Premium",
            Description = "Premium car care subscription with a 10% discount on all services.",
            Price = 59.99m,
            DiscountPercent = 10.00m,
            IsActive = true
        },
        new Subscription
        {
            Id = 3,
            Name = "VIP",
            Description = "VIP car care subscription with a 20% discount on all services.",
            Price = 99.99m,
            DiscountPercent = 20.00m,
            IsActive = true
        }
    };
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasData(subscriptions);
    }
}