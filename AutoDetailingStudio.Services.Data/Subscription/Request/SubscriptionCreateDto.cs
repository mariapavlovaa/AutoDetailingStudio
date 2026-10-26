namespace AutoDetailingStudio.Services.Data.Subscription.Request;

public class SubscriptionCreateDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal DiscountPercent { get; set; }
}