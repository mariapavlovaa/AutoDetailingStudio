using System.ComponentModel.DataAnnotations;
using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.ViewModels.Car;
using static AutoDetailingStudio.Common.EntityValidation.Car;
using static AutoDetailingStudio.Common.ErrorMessages.Car;
public class CarCreateViewModel
{
    [Required(ErrorMessage = BrandRequired)]
    [StringLength(CarBrandMaxLength,
        MinimumLength = CarBrandMinLength,
        ErrorMessage = BrandLength)]
    public string Brand { get; set; } = null!;

    [Required(ErrorMessage = RegistrationNumberRequired)]
    [StringLength(RegistrationNumberMaxLength,
        MinimumLength = RegistrationNumberMinLength,
        ErrorMessage = RegistrationNumberLength)]
    public string RegistrationNumber { get; set; } = null!;

    [EnumDataType(typeof(VehicleType),
        ErrorMessage = VehicleTypeInvalid)]
    public VehicleType VehicleType { get; set; }
}