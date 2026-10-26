
using System.ComponentModel.DataAnnotations;
using AutoDetailingStudio.Common;

namespace AutoDetailingStudio.ViewModels.Subscription;
using static EntityValidation.Subscription;
public class SubscriptionCreateViewModel
{
    [Required]
    [StringLength(SubscriptionNameMaxLength,
        MinimumLength = SubscriptionNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(SubscriptionDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Range(typeof(decimal),
        SubscriptionPriceMinValue,
        SubscriptionPriceMaxValue,
        ParseLimitsInInvariantCulture = true)]
    public decimal Price { get; set; }

    [Range(typeof(decimal),
        SubscriptionDiscountPercentMinValue,
        SubscriptionDiscountPercentMaxValue,
        ParseLimitsInInvariantCulture = true)]
    public decimal DiscountPercent { get; set; }
}
