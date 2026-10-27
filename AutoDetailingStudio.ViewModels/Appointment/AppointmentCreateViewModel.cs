using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoDetailingStudio.ViewModels.Appointment;
using static AutoDetailingStudio.Common.EntityValidation.Appointment;
public class AppointmentCreateViewModel
{
    public int ServiceId { get; set; }

    [ValidateNever]
    public string ServiceName { get; set; } = null!;

    [Required(ErrorMessage = "Please select a car.")]
    public int? CarId { get; set; }

    [Required(ErrorMessage = "Please select a date and time.")]
    public DateTime? StartTime { get; set; }

    [MaxLength(AppointmentNotesMaxLength)]
    public string? Notes { get; set; }

    public IEnumerable<SelectListItem> Cars { get; set; }
        = new List<SelectListItem>();
}