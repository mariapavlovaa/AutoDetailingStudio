using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.Services.Data.Appointment.Responce;

public class AppointmentDetailsDto
{
    public string RegistrationNumber { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public string ServiceDescription { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public AppointmentStatus Status { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
}