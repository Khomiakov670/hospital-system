using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Services.Models;

namespace Services;

public class WardService: CrudService<WardModel, Ward>, IWardService
{
    public WardService(ApplicationContext context) : base(context)
    {
    }
    public async Task<PageModel<WardModel>> GetAsync(int page, string query) =>
        await base.GetAsync(page: page,
            predicate: x => x.Floor.Equals(query)||
                            x.Capacity.Equals(query) ||
                            x.Type.Contains(query),
                            false,
                            x => x.Id);
}