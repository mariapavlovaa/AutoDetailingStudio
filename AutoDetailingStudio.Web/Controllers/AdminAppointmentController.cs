    using AutoDetailingStudio.Data.Models.Enums;
    using AutoDetailingStudio.Services.Core.Contracts;
    using AutoDetailingStudio.Services.Data.Appointment.Responce;
    using AutoDetailingStudio.ViewModels.Appointment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    namespace AutoDetailingStudio.Web.Controllers;
    using static AutoDetailingStudio.Common.ErrorMessages.AdminAppointment;

    [Authorize(Roles = "Admin")]
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
            if (!ModelState.IsValid || !Enum.IsDefined(typeof(AppointmentStatus), status))
            {
                TempData["Error"] = InvalidStatus;
                return RedirectToAction(nameof(Details), new { id });
            }
            bool changed = await _appointmentService.ChangeStatusAsync(id, status);

            if (!changed)
            {
                TempData["Error"] = ChangeStatusFailed;
            }

            return RedirectToAction(nameof(Details), new { id });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _appointmentService.DeleteAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = DeleteFailed;
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }