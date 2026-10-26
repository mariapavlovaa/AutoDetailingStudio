using AutoDetailingStudio.Data;
using AutoDetailingStudio.Services.Core.Contracts;
using AutoDetailingStudio.Services.Data.Car.Request;
using AutoDetailingStudio.Services.Data.Car.Responce;
using Microsoft.EntityFrameworkCore;

namespace AutoDetailingStudio.Services.Core;
using static AutoDetailingStudio.Common.ApplicationConstants;
public class CarService : ICarService
{
    private readonly ApplicationDbContext _context;

    public CarService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CarGetAllDto>> GetAllAsync(string userId)
    {
        IEnumerable<CarGetAllDto> cars = await _context.Cars
            .AsNoTracking()
            .Where(c => c.UserId == userId)
            .OrderBy(c => c.Brand)
            .ThenBy(c => c.RegistrationNumber)
            .Select(c => new CarGetAllDto
            {
                Id = c.Id,
                Brand = c.Brand,
                RegistrationNumber = c.RegistrationNumber,
                VehicleType = c.VehicleType
            })
            .Take(EntitiesPerPage)
            .ToListAsync();

        return cars;
    }

    public async Task<CarDetailsDto?> GetByIdAsync(int id, string userId)
    {
        CarDetailsDto? car = await _context.Cars
            .AsNoTracking()
            .Where(c => c.Id == id && c.UserId == userId)
            .Select(c => new CarDetailsDto
            {
                Id = c.Id,
                Brand = c.Brand,
                RegistrationNumber = c.RegistrationNumber,
                VehicleType = c.VehicleType
            })
            .FirstOrDefaultAsync();

        return car;
    }
    
    public async Task CreateAsync(CarCreateDto model, string userId)
    {
        Car car = new Car
        {
            UserId = userId,
            Brand = model.Brand,
            RegistrationNumber = model.RegistrationNumber,
            VehicleType = model.VehicleType
        };

        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> EditAsync(CarEditDto model, string userId)
    {
        Car? car = await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == model.Id && c.UserId == userId);

        if (car == null)
        {
            return false;
        }

        car.Brand = model.Brand;
        car.RegistrationNumber = model.RegistrationNumber;
        car.VehicleType = model.VehicleType;

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(int id, string userId)
    {
        Car? car = await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

        if (car == null)
        {
            return false;
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        return true;
    }
    
}