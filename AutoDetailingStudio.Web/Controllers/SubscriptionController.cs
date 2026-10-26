
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Subscription.Request;
using AutoDetailingStudio.Services.Data.Subscription.Responce;
using AutoDetailingStudio.ViewModels.Subscription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingStudio.Web.Controllers;

public class SubscriptionController : Controller
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        bool isAdmin = User.IsInRole("Admin");

        IEnumerable<SubscriptionGetAllDto> subscriptions =
            await _subscriptionService.GetAllAsync(isAdmin);

        IEnumerable<SubscriptionAllViewModel> model = subscriptions
            .Select(s => new SubscriptionAllViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                IsActive = s.IsActive
            });

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        SubscriptionDetailsDto? subscription =
            await _subscriptionService.GetByIdAsync(id);

        if (subscription is null)
        {
            return NotFound();
        }

        SubscriptionDetailsViewModel model = new SubscriptionDetailsViewModel
        {
            Id = subscription.Id,
            Name = subscription.Name,
            Description = subscription.Description,
            Price = subscription.Price,
            DiscountPercent = subscription.DiscountPercent
        };

        return View(model);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SubscriptionCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        SubscriptionCreateDto dto = new SubscriptionCreateDto
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            DiscountPercent = model.DiscountPercent
        };

        await _subscriptionService.CreateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        SubscriptionDetailsDto? subscription =
            await _subscriptionService.GetByIdAsync(id, true);

        if (subscription is null)
        {
            return NotFound();
        }

        SubscriptionEditViewModel model = new SubscriptionEditViewModel
        {
            Id = subscription.Id,
            Name = subscription.Name,
            Description = subscription.Description,
            Price = subscription.Price,
            DiscountPercent = subscription.DiscountPercent,
            IsActive = subscription.IsActive
        };

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SubscriptionEditViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        SubscriptionEditDto dto = new SubscriptionEditDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            DiscountPercent = model.DiscountPercent,
            IsActive = model.IsActive
        };

        bool isEdited = await _subscriptionService.EditAsync(dto);

        if (!isEdited)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        bool isDeleted = await _subscriptionService.DeleteAsync(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
}
