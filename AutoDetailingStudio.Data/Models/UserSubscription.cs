using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Data.Models;
using static Common.EntityValidation.UserSubscription;
public class UserSubscription
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
    
    public int SubscriptionId { get; set; }
    [ForeignKey(nameof(SubscriptionId))]
    public virtual Subscription Subscription { get; set; } = null!;

    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    [Range(SubscriptionDurationMonthMinValue, SubscriptionDurationMonthMaxValue)]
    public int DurationMonths { get; set; }

    [NotMapped] 
    public DateTime EndDate => StartDate.AddMonths(this.DurationMonths);

    //is subscription deactivated
    public bool IsActive { get; set; } = true;
    
    // Indicates whether the subscription period has expired.
    [NotMapped]
    public bool IsCurrentlyActive =>
        DateTime.UtcNow >= StartDate &&
        IsActive && DateTime.UtcNow < EndDate;
    //it will be calculated runtime in service layer 
    [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
    [Precision(TotalPricePrecision, TotalPriceScale)]
    public decimal TotalPricePaid { get; set; }
    
    [NotMapped]
    public decimal MonthlyPayment =>
        DurationMonths > 0
            ? Math.Round(TotalPricePaid / DurationMonths, 2)
            : 0m;



}