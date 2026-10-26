namespace AutoDetailingStudio.ViewModels.Subscription;

public class SubscriptionDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } 
    public decimal Price { get; set; }

    public decimal DiscountPercent { get; set; }
}