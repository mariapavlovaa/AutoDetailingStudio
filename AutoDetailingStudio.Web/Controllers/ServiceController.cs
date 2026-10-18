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
        
        
        return View();

    }
}