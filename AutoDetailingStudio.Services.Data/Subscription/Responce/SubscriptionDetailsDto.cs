namespace AutoDetailingStudio.Services.Data.Subscription.Responce;

public class SubscriptionDetailsDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal DiscountPercent { get; set; }
    public bool IsActive { get; set; }
}