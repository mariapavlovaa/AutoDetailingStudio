using AutoDetailingStudio.Data;
using AutoDetailingStudio.Web.Models.Subscription;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Web.Controllers;
using static ApplicationConstants;
public class SubscriptionController : Controller
{
    private readonly ApplicationDbContext _context;
    public SubscriptionController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<SubscriptionAllViewModel> allSubscriptions = _context.Subscriptions
            .AsNoTracking()
            .Where(s=>s.IsActive)
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Price)
            .ThenBy(s => s.Id)
            .Select(s =>
                new SubscriptionAllViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price
                })
            .Take(EntitiesPerPage).ToList();
        return View(allSubscriptions);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        SubscriptionDetailsViewModel? model = _context.Subscriptions.AsNoTracking()
            .Where(s => s.Id == id && s.IsActive)
            .Select(s => new SubscriptionDetailsViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                DiscountPercent = s.DiscountPercent
            }).FirstOrDefault();
        if (model is null)
        {
            return NotFound("Subscription with this id doesn't exist.");
        }

        return View(model);

    }
}