using Services.Interfaces;
using Services.Models;

namespace Services;

public interface ITenantService : ICrudService<TenantModel>
{
    Task<PageModel<TenantModel>> GetAsync(int page, string query);
}