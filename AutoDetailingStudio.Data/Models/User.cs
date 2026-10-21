using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AutoDetailingStudio.Data.Models;
using static Common.EntityValidation.User;
public class User:IdentityUser
{
    [Required] 
    [MaxLength(FirstNameMaxLength)]
    [MinLength(FirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    
    [Required] 
    [MaxLength(LastNameMaxLength)]
    [MinLength(LastNameMinLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; }= new HashSet<Car>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    public virtual ICollection<UserSubscription> Subscriptions { get; set; } = new HashSet<UserSubscription>();
    

}