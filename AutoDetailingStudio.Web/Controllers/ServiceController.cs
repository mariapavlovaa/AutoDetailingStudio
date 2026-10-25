using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Service.Request;
using AutoDetailingStudio.Services.Data.Service.Responce;
using AutoDetailingStudio.ViewModels.Service;
using AutoDetailingStudio.Web.Models.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AutoDetailingStudio.Web.Controllers;

public class ServiceController : Controller
{
    private readonly IServiceService _service;

    public ServiceController(IServiceService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<ServiceGetAllDto> allServices = await _service.GetAllAsync();
        IEnumerable<ServiceAllViewModel> models = allServices.Select(s => new ServiceAllViewModel()
        {
            Id = s.Id,
            ImageUrl = s.ImageUrl,
            Name = s.Name,
            Price = s.Price
        });
        
        return View(models);

    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {

        ServiceDetailsDto? service = await _service.GetByIdAsync(id);

        if (service is null)
        {
            return NotFound("Service with this Id doesn't exist.");
        }

        ServiceDetailsViewModel model = new ServiceDetailsViewModel
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Price = service.Price,
            DurationMinutes = service.DurationMinutes,
            ImageUrl = service.ImageUrl
        };

        return View(model);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View(new ServiceCreateViewModel());
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        ServiceCreateDto dto = new ServiceCreateDto
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            DurationMinutes = model.DurationMinutes,
            ImageUrl = model.ImageUrl
        };

        await _service.CreateAsync(dto);

        return RedirectToAction(nameof(Index));
    }
    

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        ServiceDetailsDto? service = await _service.GetByIdAsync(id);

        if (service is null)
        {
            return NotFound("This service does not exist.");
        }

        ServiceEditViewModel model = new ServiceEditViewModel
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Price = service.Price,
            DurationMinutes = service.DurationMinutes,
            ImageUrl = service.ImageUrl
        };

        return View(model);
    }
    
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ServiceEditViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        ServiceEditDto dto = new ServiceEditDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            DurationMinutes = model.DurationMinutes,
            ImageUrl = model.ImageUrl
        };

        bool isEdited = await _service.EditAsync(dto);

        if (!isEdited)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Details), new { id = model.Id });
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        bool isDeleted = await _service.DeleteAsync(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }


}