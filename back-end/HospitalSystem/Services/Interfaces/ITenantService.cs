using Services.Models;

namespace Services;

public interface ITenantService
{
    Task<PageModel<TenantModel>> GetAsync(int page, string query);
}