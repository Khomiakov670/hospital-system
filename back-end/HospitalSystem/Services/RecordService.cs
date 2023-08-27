using System.Linq.Expressions;
using System.Security.Claims;
using DataAccess.Entity;
using DataAccess;
using Services.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Services.Constants;

namespace Services;

public class RecordService : CrudService<RecordModel, Record>, IRecordService
{
    private readonly UserManager<User> _userManager;
    public RecordService(ApplicationContext context, UserManager<User> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public async Task<PageModel<RecordModel>> GetAsync(int page, string query,
        bool? isCured,bool? useApparatus, DateOnly? startDate, DateOnly? endDate, ClaimsPrincipal patient)
    {
        var patientId = _userManager.GetUserId(patient);
        return await GetAsync(page,query,isCured,useApparatus,startDate,endDate,patientId);
    }

   

    public async Task<PageModel<RecordModel>> GetAsync(int page, string query,
        bool? isCured,bool? useApparatus, DateOnly? startDate, DateOnly? endDate, string? patientId = null
        )
    {
        var expressions = new List<Expression<Func<Record, bool>>>()
        {
            x =>
                 x.PatientId.Contains(query) ||
                 x.Diagnosis == null || x.Diagnosis.Contains(query) ||
                 x.Symptoms.Contains(query)
        };
        
        if (isCured is not null)
        {
            expressions.Add(x => isCured == x.IsCured);
        }

        if (useApparatus is not null)
        {
            expressions.Add(x => useApparatus == x.UseApparatus);
        } 
        
        if (startDate is not null)
        {
            expressions.Add(x => x.DateOfClose >= startDate);
        }
        if (endDate is not null)
        {
            expressions.Add(x => x.DateOfClose <= endDate);
        }
        if (patientId is not null)
        {
            expressions.Add(x => x.PatientId == patientId);
        }

        return await base.GetAsync(page: page,
            keySelector: x => x.Id,
            isDesc: false,
            predicates: expressions.ToArray()
        );
    }


/* To Controller
     startDate ??= DateOnly.MinValue;
     endDate ??= DateOnly.MaxValue;
    */
    /*public async Task<PageModel<RecordModel>> GetByDateAsync(int page )
    {
        return await GetAsync(page,
            x => x.Id, false, x =>
                DateInRange(x.DateOfClose, startDate, endDate) ||
                DateInRange(x.DateOfOpen, startDate, endDate));
    }*/

    public async Task<Result> CloseRecordAsync(int page, int recordId)
    {
        var record = await _context.Records.FindAsync(recordId);

        if (record is null)
            return Result.Fail(Errors.NotFound);
        record.IsCured = true;

        _context.Update(record);
        await _context.SaveChangesAsync();
        return Result.Ok();
    }
}