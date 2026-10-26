using System.Diagnostics;
using AutoDetailingStudio.Common;
using AutoDetailingStudio.Data;
using AutoDetailingStudio.ViewModels;
using AutoDetailingStudio.ViewModels.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Web.Controllers;
using static ApplicationConstants;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}