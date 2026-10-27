
using System.ComponentModel.DataAnnotations;
using AutoDetailingStudio.Common;

namespace AutoDetailingStudio.ViewModels.Subscription;
using static EntityValidation.Subscription;
using static AutoDetailingStudio.Common.ErrorMessages.Subscription;
public class SubscriptionCreateViewModel
{
    [Required(ErrorMessage = NameRequired)]
    [StringLength(SubscriptionNameMaxLength,
        MinimumLength = SubscriptionNameMinLength,
        ErrorMessage = NameLength)]
    public string Name { get; set; } = null!;

    [StringLength(SubscriptionDescriptionMaxLength,
        ErrorMessage = DescriptionLength)]
    public string? Description { get; set; }

    [Range(typeof(decimal),
        SubscriptionPriceMinValue,
        SubscriptionPriceMaxValue,
        ParseLimitsInInvariantCulture = true,
        ErrorMessage = PriceRange)]
    public decimal Price { get; set; }

    [Range(typeof(decimal),
        SubscriptionDiscountPercentMinValue,
        SubscriptionDiscountPercentMaxValue,
        ParseLimitsInInvariantCulture = true,
        ErrorMessage = DiscountRange)]
    public decimal DiscountPercent { get; set; }
}
