using AutoDetailingStudio.Services.Data.Subscription.Request;
using AutoDetailingStudio.Services.Data.Subscription.Response;

namespace AutoDetailingStudio.Services.Core.Contracts;

public interface ISubscriptionService
{
    Task<IEnumerable<SubscriptionGetAllDto>> GetAllAsync(
        bool includeInactive = false);

    Task<SubscriptionDetailsDto?> GetByIdAsync(
        int id, bool includeInactive = false);

    Task CreateAsync(SubscriptionCreateDto model);

    Task<bool> EditAsync(SubscriptionEditDto model);

    Task<bool> DeleteAsync(int id);
}