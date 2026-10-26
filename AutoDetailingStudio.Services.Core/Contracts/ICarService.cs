using AutoDetailingStudio.Services.Data.Car.Request;
using AutoDetailingStudio.Services.Data.Car.Responce;

namespace AutoDetailingStudio.Services.Core.Contracts;

public interface ICarService
{
    Task<IEnumerable<CarGetAllDto>> GetAllAsync(string userId);

    Task<CarDetailsDto?> GetByIdAsync(int id, string userId);
    
    Task CreateAsync(CarCreateDto model, string userId);

    Task<bool> EditAsync(CarEditDto model, string userId);

    Task<bool> DeleteAsync(int id, string userId);
}