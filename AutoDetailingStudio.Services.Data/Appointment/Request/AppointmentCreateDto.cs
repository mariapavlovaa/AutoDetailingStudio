namespace AutoDetailingStudio.Services.Data.Appointment.Request;

public class AppointmentCreateDto
{
    public int ServiceId { get; set; }

    public int CarId { get; set; }

    public DateTime StartTime { get; set; }

    public string? Notes { get; set; } 
}