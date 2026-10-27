using System.Security.Claims;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Appointment.Request;
using AutoDetailingStudio.Services.Data.Appointment.Responce;
using AutoDetailingStudio.Services.Data.Car.Responce;
using AutoDetailingStudio.Services.Data.Service.Responce;
using AutoDetailingStudio.ViewModels.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoDetailingStudio.Web.Controllers;
using static AutoDetailingStudio.Common.ErrorMessages.Appointment;
[Authorize]
public class AppointmentController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IServiceService _serviceService;
    private readonly ICarService _carService;

    public AppointmentController(
        IAppointmentService appointmentService,
        IServiceService serviceService,
        ICarService carService)
    {
        _appointmentService = appointmentService;
        _serviceService = serviceService;
        _carService = carService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Challenge();
        }

       IEnumerable<AppointmentGetAllDto> appointmentsDto =
           await _appointmentService.GetAllAsync(userId);

        IEnumerable<AppointmentGetAllViewModel> appointments = appointmentsDto
            .Select(a => new AppointmentGetAllViewModel
            {
                Id = a.Id,
                CarBrand = a.CarBrand,
                RegistrationNumber = a.RegistrationNumber,
                ServiceName = a.ServiceName,
                StartTime = a.StartTime,
                Status = a.Status
            })
            .ToList();

        return View(appointments);
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Challenge();
        }

        var appointmentDto = await _appointmentService.GetByIdAsync(id, userId);

        if (appointmentDto == null)
        {
            return NotFound();
        }

        AppointmentDetailsViewModel appointment = new AppointmentDetailsViewModel
        {
            RegistrationNumber = appointmentDto.RegistrationNumber,
            ServiceName = appointmentDto.ServiceName,
            ServiceDescription = appointmentDto.ServiceDescription,
            StartTime = appointmentDto.StartTime,
            Status = appointmentDto.Status,
            Notes = appointmentDto.Notes,
            CreatedAt = appointmentDto.CreatedAt
        };

        return View(appointment);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Create(int serviceId)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Challenge();
        }

        ServiceDetailsDto? service = await _serviceService.GetByIdAsync(serviceId);

        if (service == null)
        {
            return NotFound();
        }

        IEnumerable<CarGetAllDto> cars = await _carService.GetAllAsync(userId);

        
        AppointmentCreateViewModel model = new()
        {
            ServiceId = serviceId,
            ServiceName = service.Name,
            Cars = cars.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Brand} - {c.RegistrationNumber}"
            }).ToList()
        };

        return View(model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AppointmentCreateViewModel model)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Challenge();
        }

        if (ModelState.IsValid)
        {
            AppointmentCreateDto dto = new()
            {
                ServiceId = model.ServiceId,
                CarId = model.CarId!.Value,
                StartTime = model.StartTime!.Value,
                Notes = model.Notes
            };

            bool created = await _appointmentService.CreateAsync(dto, userId);

            
            if (created)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(
                string.Empty,
                CreateFailed);
        }
        
        

        var service = await _serviceService.GetByIdAsync(model.ServiceId);

        if (service == null)
        {
            return NotFound();
        }

        IEnumerable<CarGetAllDto> cars = await _carService.GetAllAsync(userId);

        model.ServiceName = service.Name;

        model.Cars = cars.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.Brand} - {c.RegistrationNumber}"
        }).ToList();

        return View(model);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Challenge();
        }

        bool cancelled = await _appointmentService.CancelAsync(id, userId);

        if (!cancelled)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
}