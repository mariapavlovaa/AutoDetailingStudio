using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
    [Precision(SubscriptionPricePrecision, SubscriptionPriceScale)]
    public decimal Price { get; set; }
    [Range(typeof(decimal),SubscriptionDiscountPercentMinValue, SubscriptionDiscountPercentMaxValue)]
    [Precision(DiscountPercentPrecision, DiscountPercentScale)]
    public decimal DiscountPercent { get; set; }
    public bool IsActive { get; set; } = true;
    
    public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
        = new HashSet<UserSubscription>();

    


}