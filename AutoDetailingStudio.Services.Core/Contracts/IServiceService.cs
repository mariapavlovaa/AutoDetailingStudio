using AutoDetailingStudio.Services.Data.Service.Request;
using AutoDetailingStudio.Services.Data.Service.Responce;

namespace AutoDetailingStudio.Services.Core.Contracts;

public interface IServiceService
{
    Task<IEnumerable<ServiceGetAllDto>> GetAllAsync();

    Task<ServiceDetailsDto?> GetByIdAsync(int id);
    
    Task CreateAsync(ServiceCreateDto model);
    Task<bool> EditAsync(ServiceEditDto model);
    Task<bool> DeleteAsync(int id);
}