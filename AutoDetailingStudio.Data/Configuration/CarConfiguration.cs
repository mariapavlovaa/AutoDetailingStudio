using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingStudio.Data.Configuration;

public class CarConfiguration:IEntityTypeConfiguration<Car>
{
   private List<Car> cars = new List<Car>
    {
        new Car
        {
            Id = 1,
            UserId = "user-1",
            Brand = "BMW",
            RegistrationNumber = "PB1234AB",
            VehicleType = VehicleType.Sedan
        },
        new Car
        {
            Id = 2,
            UserId = "user-1",
            Brand = "Mercedes-Benz",
            RegistrationNumber = "CB5678CD",
            VehicleType = VehicleType.Sedan
        },
        new Car
        {
            Id = 3,
            UserId = "user-2",
            Brand = "Audi",
            RegistrationNumber = "PB9012EF",
            VehicleType = VehicleType.Sedan
        },
        new Car
        {
            Id = 4,
            UserId = "user-2",
            Brand = "Toyota",
            RegistrationNumber = "CA3456GH",
            VehicleType = VehicleType.SUV
        },
        new Car
        {
            Id = 5,
            UserId = "user-3",
            Brand = "Volkswagen",
            RegistrationNumber = "PB7890JK",
            VehicleType = VehicleType.Hatchback
        },
        new Car
        {
            Id = 6,
            UserId = "user-3",
            Brand = "Honda",
            RegistrationNumber = "CB2345LM",
            VehicleType = VehicleType.Sedan
        },
        new Car
        {
            Id = 7,
            UserId = "user-4",
            Brand = "Ford",
            RegistrationNumber = "PB6789NP",
            VehicleType = VehicleType.SUV
        },
        new Car
        {
            Id = 8,
            UserId = "user-4",
            Brand = "Skoda",
            RegistrationNumber = "CA1122RS",
            VehicleType = VehicleType.Sedan
        },
        new Car
        {
            Id = 9,
            UserId = "user-5",
            Brand = "Hyundai",
            RegistrationNumber = "PB3344TU",
            VehicleType = VehicleType.Hatchback
        },
        new Car
        {
            Id = 10,
            UserId = "user-5",
            Brand = "Kia",
            RegistrationNumber = "CB5566VW",
            VehicleType = VehicleType.SUV
        }
    };
    public void Configure(EntityTypeBuilder<Car> builder)
    {

        builder.HasData(cars);
    }
}