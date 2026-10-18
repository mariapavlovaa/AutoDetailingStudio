using AutoDetailingStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingStudio.Data.Configuration;

public class ServiceConfiguration:IEntityTypeConfiguration<Service>
{
    private readonly List<Service> services = new List<Service>
    {
        new Service
        {
            Id = 1,
            Name = "Exterior Wash",
            Description = "Professional exterior wash, wheel cleaning and drying.",
            Price = 30.00m,
            DurationMinutes = 30,
            IsActive = true
        },
        new Service
        {
            Id = 2,
            Name = "Interior Cleaning",
            Description = "Vacuuming, dashboard cleaning and interior surface treatment.",
            Price = 50.00m,
            DurationMinutes = 60,
            IsActive = true
        },
        new Service
        {
            Id = 3,
            Name = "Full Car Wash",
            Description = "Complete exterior and interior vehicle cleaning.",
            Price = 75.00m,
            DurationMinutes = 90,
            IsActive = true
        },
        new Service
        {
            Id = 4,
            Name = "Interior Detailing",
            Description = "Deep cleaning of seats, carpets and upholstery.",
            Price = 180.00m,
            DurationMinutes = 180,
            IsActive = true
        },
        new Service
        {
            Id = 5,
            Name = "Paint Polishing",
            Description = "Machine polishing to reduce scratches and restore paint gloss.",
            Price = 350.00m,
            DurationMinutes = 300,
            IsActive = true
        },
        new Service
        {
            Id = 6,
            Name = "Ceramic Coating",
            Description = "Application of protective ceramic coating for long-lasting paint protection.",
            Price = 650.00m,
            DurationMinutes = 480,
            IsActive = true
        }
    };
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasData(services);
    }
}