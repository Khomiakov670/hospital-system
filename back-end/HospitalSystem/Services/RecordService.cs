using DataAccess.Entity;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Services.Models;
using API.Options;

namespace Services;

public class RecordService : CrudService<RecordModel, Record>
{
    public RecordService(ApplicationContext context, UserManager<User> userManager) : base(context, userManager) { }

    public async Task<PageModel<RecordModel>> GetHistoryAsync(string patientId, int page)
    {
        return await GetAsync(page, x => x.PatientId == patientId && x.IsCured == true && x.DateOfClose != null, false,
            x => x.DateOfClose!);
        /*var enumerable = _context.Set<Record>()
            .Where(x => x.PatientId == patientId && x.IsCured == true)
            .OrderBy(x => x.DateOfClose);
        var entities = await enumerable.Skip((page - 1) * _config.ItemsPerPage)
            .Take(_config.ItemsPerPage)
            .ToListAsync();
        var models = entities.Adapt<List<RecordModel>>();
        return new PageModel<RecordModel>(models, enumerable.Count());*/
    }
    public async Task<PageModel<TenantModel>> GetAsync(int page, string patientId, DateOnly dateStart, DateOnly dateEnd, bool isCured, bool isApparatus)
    {
        return await GetAsync(page, x => 
                x.PatientId == patientId || 
                x.DateOfClose < dateStart||
                x.WardId == wardNumber, 
            false, 
            x => x.Apparatus.Functiional);
    }
}