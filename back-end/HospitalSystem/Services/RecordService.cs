using DataAccess.Entity;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BusinessLogicLayer.Services;
using Services.Models;
using System.Security.Claims;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class RecordService : CrudService<RecordModel, Record>
    {
        private readonly UserManager<User> userManager;
        public RecordService(ApplicationContext context, UserManager<User> userManager, IConfiguration configuration) : base(context, userManager)
        {
        }
        public async Task<PageModel<RecordModel>> GetHistoryAsync(string patientId,  int page)
        {
            var enumerable = await _context.Set<Record>()
                .Where(x => x.PatientId == patientId && x.IsCured == true)
                .OrderBy(x => x.DateOfClose)
                .ToListAsync();
            var entities = enumerable.Skip((page - 1) * 10)
                .Take(10)
                .ToList();
            var models = entities.Adapt<List<RecordModel>>();
            return new PageModel<RecordModel>(models, enumerable.Count());
        }
    }
}
