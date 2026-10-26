namespace AutoDetailingStudio.Services.Data.Subscription.Request;

public class SubscriptionEditDto:SubscriptionCreateDto
{
    public int Id { get; set; }

    public bool IsActive { get; set; }
}