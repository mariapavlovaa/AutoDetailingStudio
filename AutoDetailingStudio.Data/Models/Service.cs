using System.ComponentModel.DataAnnotations;    

namespace AutoDetailingStudio.Data.Models;
using static Common.EntityValidation.Service;
public class Service
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MaxLength(ServiceNameMaxLength)]  
    [MinLength(ServiceNameMinlength)]
    public string Name { get; set; } = null!;

    [Required] 
    [MaxLength(ServiceDescriptionMaxLength)]
    [MinLength(ServiceDescriptionMinLength)]
    public string Description { get; set; } = null!;
    [Range(typeof(decimal), ServicePriceMinValue, ServicePriceMaxValue)]
    public decimal Price { get; set; }
    [Range(DurationMinutesMinValue, DurationMinutesMaxValue)]
    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; }=true;

    
}