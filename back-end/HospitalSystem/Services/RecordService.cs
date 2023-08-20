using DataAccess.Entity;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BusinessLogicLayer.Services;
using Services.Models;
using System.Security.Claims;
using Mapster;

namespace Services
{
    public class RecordService : CrudService<RecordModel, Record>
    {
        private readonly UserManager<User> userManager;
        public RecordService(ApplicationContext context, UserManager<User> userManager) : base(context, userManager)
        {
            this.userManager = userManager;
        }
        /*public async Task<PageModel<RecordModel>> GetPatientHistory(string patientId, int page, string query) =>
            await base.GetAsync(page: page,
                                predicate: x => x.PatientId == patientId
                                                && x.IsCured == true,
                                keySelectors: x => x.Id);*/
        /*public async Task<PageModel<Record>> GetAsync(ClaimsPrincipal principal, int page, string query)
        {
            var patientId = userManager.GetUserId(principal);
            return await GetPatientHistory(patientId!, page, query);
        }*/
    }
}
