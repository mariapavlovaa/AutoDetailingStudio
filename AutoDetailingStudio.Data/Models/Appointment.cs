using System.ComponentModel.DataAnnotations;
using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.Data.Models;
using static Common.EntityValidation.Appointment;
public class Appointment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    
    public int CarId { get; set; }
    public virtual Car Car { get; set; } = null!;
    
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; } = null!;   
    
    
    public DateTime StartTime { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
    
    
    [MaxLength(AppointmentNotesMaxLength)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    
}
