using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDetailingStudio.Data.Models;
using static Common.EntityValidation.Subscription;
public class Subscription
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MaxLength(SubscriptionNameMaxLength)]
    [MinLength(SubscriptionNameMinLength)]
    public string Name { get; set; } = null!;
    
    
    [MaxLength(SubscriptionDescriptionMaxLength)]
    public string? Description { get; set; } 
    
    [Range(typeof(decimal),SubscriptionPriceMinValue, SubscriptionPriceMaxValue)]
    public decimal Price { get; set; }
    [Range(typeof(decimal),SubscriptionDiscountPercentMinValue, SubscriptionDiscountPercentMaxValue)]
    public decimal DiscountPercent { get; set; }
    public bool IsActive { get; set; } = true;
    

    


}