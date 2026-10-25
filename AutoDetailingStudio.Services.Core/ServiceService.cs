
using AutoDetailingStudio.Data;
using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Service.Request;
using AutoDetailingStudio.Services.Data.Service.Responce;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Services.Core;
using static AutoDetailingStudio.Common.ApplicationConstants;
public class ServiceService:IServiceService
{
    private readonly ApplicationDbContext _context;
    public ServiceService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ServiceGetAllDto>> GetAllAsync()
    {
        IEnumerable<ServiceGetAllDto> allServices = await _context.Services
            .AsNoTracking()
            .Where(s => s.IsActive)
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Price)
            .ThenBy(s => s.Id)
            .Select(s => new ServiceGetAllDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                ImageUrl = s.ImageUrl
            })
            .Take(EntitiesPerPage)
            .ToListAsync();
        return  allServices;
    }

    public async Task<ServiceDetailsDto?> GetByIdAsync(int id)
    {
        ServiceDetailsDto ?service = await _context.Services
            .AsNoTracking()
            .Where(s => s.Id == id && s.IsActive)
            .Select(s => new ServiceDetailsDto()
            {
                Description = s.Description,
                DurationMinutes = s.DurationMinutes,
                ImageUrl = s.ImageUrl,
                Id = s.Id,
                Price = s.Price,
                Name = s.Name
            }).FirstOrDefaultAsync();

        return service;
    }

    public async Task CreateAsync(ServiceCreateDto model)
    {
       Service service = new Service
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            DurationMinutes = model.DurationMinutes,
            ImageUrl = model.ImageUrl,
            IsActive = true
        };

        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }
    
    
    public async Task<bool> EditAsync(ServiceEditDto model)
    {
        Service ?service = await _context.Services
            .FirstOrDefaultAsync(s => s.Id == model.Id && s.IsActive);

        if (service == null)
        {
            return false;
        }

        service.Name = model.Name;
        service.Description = model.Description;
        service.Price = model.Price;
        service.DurationMinutes = model.DurationMinutes;
        service.ImageUrl = model.ImageUrl;

        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        Service? service = await _context.Services
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);

        if (service is null)
        {
            return false;
        }

        service.IsActive = false;

        await _context.SaveChangesAsync();

        return true;
    }

    
}