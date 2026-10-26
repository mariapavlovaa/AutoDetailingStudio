using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.Services.Data.Car.Responce;

public class CarGetAllDto
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public VehicleType VehicleType { get; set; }
}