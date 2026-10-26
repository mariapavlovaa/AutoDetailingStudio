using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Car.Request;
using AutoDetailingStudio.Services.Data.Car.Responce;
using AutoDetailingStudio.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingStudio.Web.Controllers;

[Authorize]
public class CarController : Controller
{
    
    private readonly ICarService _carService;
    private readonly UserManager<User> _userManager;

    public CarController(
        ICarService carService,
        UserManager<User> userManager)
    {
        _carService = carService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }
        string? userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        IEnumerable<CarGetAllDto> cars =
            await _carService.GetAllAsync(userId);

        IEnumerable<CarAllViewModel> model = cars
            .Select(c => new CarAllViewModel
            {
                Id = c.Id,
                Brand = c.Brand,
                RegistrationNumber = c.RegistrationNumber,
                VehicleType = c.VehicleType
            });

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }
        string? userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        CarDetailsDto? car =
            await _carService.GetByIdAsync(id, userId);

        if (car == null)
        {
            return NotFound();
        }

        CarDetailsViewModel model = new CarDetailsViewModel
        {
            Id = car.Id,
            Brand = car.Brand,
            RegistrationNumber = car.RegistrationNumber,
            VehicleType = car.VehicleType
        };

        return View(model);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CarCreateViewModel model)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string? userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        CarCreateDto dto = new CarCreateDto
        {
            Brand = model.Brand,
            RegistrationNumber = model.RegistrationNumber,
            VehicleType = model.VehicleType
        };

        await _carService.CreateAsync(dto, userId);

        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        string? userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        CarDetailsDto? car = await _carService.GetByIdAsync(id, userId);

        if (car == null)
        {
            return NotFound();
        }

        CarEditViewModel model = new CarEditViewModel
        {
            Id = car.Id,
            Brand = car.Brand,
            RegistrationNumber = car.RegistrationNumber,
            VehicleType = car.VehicleType
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CarEditViewModel model)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string? userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        CarEditDto dto = new CarEditDto
        {
            Id = model.Id,
            Brand = model.Brand,
            RegistrationNumber = model.RegistrationNumber,
            VehicleType = model.VehicleType
        };

        bool isEdited = await _carService.EditAsync(dto, userId);

        if (!isEdited)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (User.IsInRole("Admin"))
        {
            return Forbid();
        }

        string? userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        bool isDeleted = await _carService.DeleteAsync(id, userId);

        if (!isDeleted)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
    
}