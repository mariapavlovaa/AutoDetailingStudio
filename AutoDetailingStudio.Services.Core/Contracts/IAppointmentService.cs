using AutoDetailingStudio.Data.Models.Enums;
using AutoDetailingStudio.Services.Data.Appointment.Request;
using AutoDetailingStudio.Services.Data.Appointment.Responce;

namespace AutoDetailingStudio.Services.Core.Contracts;

public interface IAppointmentService
{
    // Customer - Read
    Task<IEnumerable<AppointmentGetAllDto>> GetAllAsync(string userId);

    Task<AppointmentDetailsDto?> GetByIdAsync(int id, string userId);

    // Customer - Create
    Task<bool> CreateAsync(AppointmentCreateDto model, string userId);

    // Customer - Edit
    //Task<bool> EditAsync(AppointmentEditDto model, string userId);

    // Customer - Cancel
    Task<bool> CancelAsync(int id, string userId);

    // Admin - Read
    Task<IEnumerable<AppointmentGetAllDto>> GetAllForAdminAsync();

    //Task<IEnumerable<AppointmentGetAllDto>> GetPendingAsync();

    Task<AppointmentDetailsDto?> GetByIdForAdminAsync(int id);

    // Admin - Status Management
    Task<bool> ChangeStatusAsync(int id, AppointmentStatus status);
    
    //Admin-Delete
    Task<bool> DeleteAsync(int id);
}