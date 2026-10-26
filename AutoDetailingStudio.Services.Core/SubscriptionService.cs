
using AutoDetailingStudio.Common;
using AutoDetailingStudio.Data;
using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Subscription.Request;
using AutoDetailingStudio.Services.Data.Subscription.Responce;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Services.Core;

public class SubscriptionService : ISubscriptionService
{
    private readonly ApplicationDbContext _context;

    public SubscriptionService(ApplicationDbContext context)
    {
        _context = context;
    }

   
    public async Task<IEnumerable<SubscriptionGetAllDto>> GetAllAsync(
        bool includeInactive = false)
    {
        return await _context.Subscriptions
            .AsNoTracking()
            .Where(s => includeInactive || s.IsActive)
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Price)
            .ThenBy(s => s.Id)
            .Select(s => new SubscriptionGetAllDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                IsActive = s.IsActive
            })
            .Take(ApplicationConstants.EntitiesPerPage)
            .ToListAsync();
    }
    

    public async Task<SubscriptionDetailsDto?> GetByIdAsync(
        int id, bool includeInactive = false)
    {
        return await _context.Subscriptions
            .AsNoTracking()
            .Where(s => s.Id == id && (includeInactive || s.IsActive))
            .Select(s => new SubscriptionDetailsDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description ?? string.Empty,
                Price = s.Price,
                DiscountPercent = s.DiscountPercent,
                IsActive = s.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(SubscriptionCreateDto model)
    {
        Subscription subscription = new Subscription
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            DiscountPercent = model.DiscountPercent,
            IsActive = true
        };

        await _context.Subscriptions.AddAsync(subscription);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EditAsync(SubscriptionEditDto model)
    {
        Subscription? subscription =
            await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Id == model.Id);

        if (subscription is null)
        {
            return false;
        }

        subscription.Name = model.Name;
        subscription.Description = model.Description;
        subscription.Price = model.Price;
        subscription.DiscountPercent = model.DiscountPercent;
        subscription.IsActive = model.IsActive;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Subscription? subscription =
            await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);

        if (subscription is null)
        {
            return false;
        }

        subscription.IsActive = false;

        await _context.SaveChangesAsync();

        return true;
    }
}
    