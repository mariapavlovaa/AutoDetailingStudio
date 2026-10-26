using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.Services.Data.Car.Request;

public class CarCreateDto
{
    
    public string Brand { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public VehicleType VehicleType { get; set; }
}