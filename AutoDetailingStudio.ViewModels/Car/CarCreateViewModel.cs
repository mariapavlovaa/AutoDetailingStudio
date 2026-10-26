using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.ViewModels.Car;

public class CarCreateViewModel
{
    public string Brand { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public VehicleType VehicleType { get; set; }
}