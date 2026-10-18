using AutoDetailingStudio.Data;
using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Web.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Web.Controllers;
using static ApplicationConstants;
public class ServiceController : Controller
{
    private readonly ApplicationDbContext _context;

    public ServiceController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<ServiceAllViewModel> allServices = _context.Services
            .AsNoTracking()
            .Where(s => s.IsActive)
            .OrderBy(s=>s.Name)
            .ThenBy(s=>s.Price)
            .ThenBy(s=>s.Id)
            .Select(s => new ServiceAllViewModel()
        {
            Id = s.Id,
            Name = s.Name,
            Price = s.Price,
            ImageUrl = s.ImageUrl
        })
            .Take(EntitiesPerPage)
            .ToList();
        
        return View(allServices);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {

        ServiceDetailsViewModel? model = _context.Services
            .AsNoTracking()
            .Where(s => s.Id == id && s.IsActive)
            .Select(s => new ServiceDetailsViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                DurationMinutes = s.DurationMinutes,
                ImageUrl = s.ImageUrl
            })
            .FirstOrDefault();
        
        if (model is null)
        {
            return NotFound("Service with this Id doesn't exists.");
        }
        return View(model);

    }
}