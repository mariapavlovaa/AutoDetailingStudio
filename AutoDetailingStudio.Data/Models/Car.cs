using System.ComponentModel.DataAnnotations;
using AutoDetailingStudio.Data.Models.Common;
using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.Data.Models;
using static EntityValidation.Car;
public class Car
{
    [Key]
    public int Id { get; set; }

    [Required] 
    public string UserId { get; set; } = null!;
    
    public virtual User User { get; set; } = null!;
    
    [Required]
    [MaxLength(CarBrandMaxLength)]
    [MinLength(CarBrandMinLength)]
    
    public string Brand { get; set; } = null!;
        
    [Required]
    [MaxLength(RegistrationNumberMaxLength)]
    [MinLength(RegistrationNumberMinLength)]
    public string RegistrationNumber { get; set; } = null!;
    
    
    public VehicleType VehicleType { get; set; }


}