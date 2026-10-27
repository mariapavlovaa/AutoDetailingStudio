using System.ComponentModel.DataAnnotations;
using AutoDetailingStudio.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoDetailingStudio.ViewModels.Appointment;
using static AutoDetailingStudio.Common.EntityValidation.Appointment;
using static ErrorMessages.Appointment;
public class AppointmentCreateViewModel
{
    public int ServiceId { get; set; }

    [ValidateNever]
    public string ServiceName { get; set; } = null!;

    [Required(ErrorMessage = CarRequired)]
    public int? CarId { get; set; }

    [Required(ErrorMessage =AppointmentDateRequired)]
    public DateTime? StartTime { get; set; }

    [MaxLength(AppointmentNotesMaxLength)]
    public string? Notes { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem> Cars { get; set; }
        = new List<SelectListItem>();
}