using DataAccess;
using DataAccess.Entity;
using Services.Models;

namespace Services;

public class TenantService : CrudService<TenantModel, Tenant>, ITenantService
{
    public TenantService(ApplicationContext context) : base(context)
    {
    }
    public async Task<PageModel<TenantModel>> GetAsync(int page, string query)
    {
        return await GetAsync(page, 
            x => x.Apparatus.Functional, false);
    }
}