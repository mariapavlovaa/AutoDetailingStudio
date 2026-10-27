using AutoDetailingStudio.Data.Models.Enums;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Appointment.Responce;
using AutoDetailingStudio.ViewModels.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingStudio.Web.Controllers;

public class AdminAppointmentController : Controller
{
    private readonly IAppointmentService _appointmentService;

    public AdminAppointmentController(IAppointmentService service)
    {
        _appointmentService = service;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<AppointmentGetAllDto> appointments =
            await _appointmentService.GetAllForAdminAsync();

        IEnumerable<AppointmentGetAllViewModel> model = appointments
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

        return View("~/Views/Appointment/Index.cshtml", model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
       AppointmentDetailsDto?
           appointment = await _appointmentService.GetByIdForAdminAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        AppointmentDetailsViewModel model = new()
        {
            RegistrationNumber = appointment.RegistrationNumber,
            ServiceName = appointment.ServiceName,
            ServiceDescription = appointment.ServiceDescription,
            StartTime = appointment.StartTime,
            Status = appointment.Status,
            Notes = appointment.Notes,
            CreatedAt = appointment.CreatedAt
        };

        ViewBag.AppointmentId = id;

        return View("~/Views/Appointment/Details.cshtml", model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangeStatus(int id, AppointmentStatus status)
    {
        bool changed = await _appointmentService.ChangeStatusAsync(id, status);

        if (!changed)
        {
            TempData["Error"] = "Unable to change appointment status.";
        }

        return RedirectToAction(nameof(Details), new { id });
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        bool IsDeleted = await _appointmentService.DeleteAsync(id);

        if (!IsDeleted)
        {
            TempData["Error"] = "Unable to delete appointment.";
            return RedirectToAction(nameof(Details), new { id });
        }

        return RedirectToAction(nameof(Index));
    }
}