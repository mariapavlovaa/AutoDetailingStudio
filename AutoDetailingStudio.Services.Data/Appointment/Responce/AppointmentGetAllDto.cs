using AutoDetailingStudio.Data.Models.Enums;

namespace AutoDetailingStudio.Services.Data.Appointment.Responce;

public class AppointmentGetAllDto
{
    public int Id { get; set; }

    public string CarBrand { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public AppointmentStatus Status { get; set; }
}