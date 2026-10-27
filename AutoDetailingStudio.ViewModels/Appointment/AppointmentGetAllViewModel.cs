using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.ViewModels.Appointment;

public class AppointmentGetAllViewModel
{
    public int Id { get; set; }

    public string CarBrand { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public AppointmentStatus Status { get; set; }
}