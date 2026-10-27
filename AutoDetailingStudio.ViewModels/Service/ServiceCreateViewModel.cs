using System.ComponentModel.DataAnnotations;
namespace AutoDetailingStudio.ViewModels.Service;
using static AutoDetailingStudio.Common.EntityValidation.Service;
using static AutoDetailingStudio.Common.ErrorMessages.Service;
public class ServiceCreateViewModel
{
    [Required(ErrorMessage = NameRequired)]
    [StringLength(ServiceNameMaxLength,
        MinimumLength = ServiceNameMinlength,
        ErrorMessage = NameLength)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = DescriptionRequired)]
    [StringLength(ServiceDescriptionMaxLength,
        MinimumLength = ServiceDescriptionMinLength,
        ErrorMessage = DescriptionLength)]
    public string Description { get; set; } = null!;

    [Range(typeof(decimal),
        ServicePriceMinValue,
        ServicePriceMaxValue,
        ParseLimitsInInvariantCulture = true,
        ErrorMessage = PriceRange)]
    public decimal Price { get; set; }

    [Range(DurationMinutesMinValue,
        DurationMinutesMaxValue,
        ErrorMessage = DurationRange)]
    public int DurationMinutes { get; set; }

    [StringLength(ImageUrlMaxLength,
        ErrorMessage = ImageUrlLength)]
    public string? ImageUrl { get; set; }
}