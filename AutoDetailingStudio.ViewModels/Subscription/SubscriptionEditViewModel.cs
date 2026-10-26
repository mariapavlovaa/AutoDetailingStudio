namespace AutoDetailingStudio.ViewModels.Subscription;

public class SubscriptionEditViewModel:SubscriptionCreateViewModel
{
    public int Id { get; set; }

    public bool IsActive { get; set; }
}