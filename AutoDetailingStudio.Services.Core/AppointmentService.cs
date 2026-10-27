using AutoDetailingStudio.Data;
using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Data.Models.Enums;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Appointment.Request;
using AutoDetailingStudio.Services.Data.Appointment.Responce;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Services.Core;
using static AutoDetailingStudio.Common.ApplicationConstants;
public class AppointmentService:IAppointmentService
{
    private readonly ApplicationDbContext _context;

    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    //за потребители
    public async Task<IEnumerable<AppointmentGetAllDto>> GetAllAsync(string userId)
    {
        IEnumerable<AppointmentGetAllDto> appointments= await _context.Appointments
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartTime)
            .Select(a => new AppointmentGetAllDto
            {
                Id = a.Id,
                CarBrand = a.Car.Brand,
                RegistrationNumber = a.Car.RegistrationNumber,
                ServiceName = a.Service.Name,
                StartTime = a.StartTime,
                Status = a.Status
            })
            .Take(EntitiesPerPage)
            .ToListAsync();

        return appointments;

    }

    public async Task<AppointmentDetailsDto?> GetByIdAsync(int id, string userId)
    {
       AppointmentDetailsDto ?appointment= await _context.Appointments
            .AsNoTracking()
            .Where(a => a.Id == id && a.UserId == userId)
            .Select(a => new AppointmentDetailsDto
            {
                RegistrationNumber = a.Car.RegistrationNumber,
                ServiceName = a.Service.Name,
                ServiceDescription = a.Service.Description,
                StartTime = a.StartTime,
                Status = a.Status,
                Notes = a.Notes,
                CreatedAt = a.CreatedAt
            })
            .FirstOrDefaultAsync();
       return appointment;

    }

    
    

    public async Task<bool> CreateAsync(AppointmentCreateDto model, string userId)
    {
        bool carExists = await _context.Cars
            .AnyAsync(c => c.Id == model.CarId && c.UserId == userId);

        if (!carExists)
        {
            return false;
        }

        bool serviceExists = await _context.Services
            .AnyAsync(s => s.Id == model.ServiceId && s.IsActive);

        if (!serviceExists)
        {
            return false;
        }

        if (model.StartTime <= DateTime.UtcNow)
        {
            return false;
        }

        Appointment appointment = new Appointment
        {
            UserId = userId,
            CarId = model.CarId,
            ServiceId = model.ServiceId,
            StartTime = model.StartTime,
            Notes = model.Notes,
            Status = AppointmentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();

        return true;
    }

    // public Task<bool> EditAsync(AppointmentEditDto model, string userId)
    // {
    //     throw new NotImplementedException();
    // }

    
    public async Task<bool> CancelAsync(int id, string userId)
    {
        Appointment? appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (appointment == null)
        {
            return false;
        }

        if (appointment.Status != AppointmentStatus.Pending)
        {
            return false;
        }

        appointment.Status = AppointmentStatus.Cancelled;

        await _context.SaveChangesAsync();

        return true;
    }
    
    
    //за администратори 
    
    public async Task<IEnumerable<AppointmentGetAllDto>> GetAllForAdminAsync()
    {
        IEnumerable<AppointmentGetAllDto> appointments = await _context.Appointments
            .AsNoTracking()
            .OrderByDescending(a => a.CreatedAt)
            .Select(a => new AppointmentGetAllDto
            {
                Id = a.Id,
                CarBrand = a.Car.Brand,
                RegistrationNumber = a.Car.RegistrationNumber,
                ServiceName = a.Service.Name,
                StartTime = a.StartTime,
                Status = a.Status
            })
            .Take(EntitiesPerPage)
            .ToListAsync();

        return appointments;
    }

    // public Task<IEnumerable<AppointmentGetAllDto>> GetPendingAsync()
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<AppointmentDetailsDto?> GetByIdForAdminAsync(int id)
    {
        return await _context.Appointments
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new AppointmentDetailsDto
            {
                RegistrationNumber = a.Car.RegistrationNumber,
                ServiceName = a.Service.Name,
                ServiceDescription = a.Service.Description,
                StartTime = a.StartTime,
                Status = a.Status,
                Notes = a.Notes,
                CreatedAt = a.CreatedAt
            })
            .Take(EntitiesPerPage)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> ChangeStatusAsync(int id, AppointmentStatus status)
    {
        Appointment? appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == id);

        if (appointment == null)
        {
            return false;
        }

        if (!Enum.IsDefined(typeof(AppointmentStatus), status))
        {
            return false;
        }

        if (appointment.Status == AppointmentStatus.Cancelled ||
            appointment.Status == AppointmentStatus.Completed)
        {
            return false;
        }

        bool validTransition = appointment.Status switch
        {
            AppointmentStatus.Pending =>
                status == AppointmentStatus.Confirmed ||
                status == AppointmentStatus.Cancelled,

            AppointmentStatus.Confirmed =>
                status == AppointmentStatus.InProgress ||
                status == AppointmentStatus.Cancelled,

            AppointmentStatus.InProgress =>
                status == AppointmentStatus.Completed,

            _ => false
        };

        if (!validTransition)
        {
            return false;
        }

        appointment.Status = status;

        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        Appointment? appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == id);

        if (appointment == null)
        {
            return false;
        }

        if (appointment.Status != AppointmentStatus.Cancelled &&
            appointment.Status != AppointmentStatus.Completed)
        {
            return false;
        }

        _context.Appointments.Remove(appointment);

        await _context.SaveChangesAsync();

        return true;
    }
}