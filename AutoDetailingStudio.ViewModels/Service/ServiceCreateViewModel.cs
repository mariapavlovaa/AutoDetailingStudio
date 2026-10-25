using System.ComponentModel.DataAnnotations;
namespace AutoDetailingStudio.ViewModels.Service;
using static AutoDetailingStudio.Common.EntityValidation.Service;
public class ServiceCreateViewModel
{
    [Required]
    [StringLength(ServiceNameMaxLength, MinimumLength = ServiceNameMinlength)]
    public string Name { get; set; } = null!;

    
    [Required]
    [StringLength(ServiceDescriptionMaxLength, MinimumLength = ServiceDescriptionMinLength)]
    public string Description { get; set; } = null!;

    
    [Range(typeof(decimal), ServicePriceMinValue, ServicePriceMaxValue, ParseLimitsInInvariantCulture = true)]
    public decimal Price { get; set; }

    [Range(DurationMinutesMinValue, DurationMinutesMaxValue)]
    public int DurationMinutes { get; set; }

    
    [StringLength(ImageUrlMaxLength)]
    public string? ImageUrl { get; set; }
}