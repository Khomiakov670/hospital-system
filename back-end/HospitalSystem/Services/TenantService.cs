using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Services.Models;

namespace Services;

public class TenantService : CrudService<TenantModel, Tenant>
{
    public TenantService(ApplicationContext context, UserManager<User> userManager) : base(context, userManager)
    {
    }
    public async Task<PageModel<TenantModel>> GetAsync(int page, int serialNumber, int functional, int wardNumber)
    {
        return await GetAsync(page, x => 
                x.Apparatus.Functiional == functional || 
                x.Apparatus.SerialNumber == serialNumber||
                x.WardId == wardNumber, 
            false, 
            x => x.Apparatus.Functiional);
    }
}