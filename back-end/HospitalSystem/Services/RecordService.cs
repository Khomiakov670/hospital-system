using DataAccess.Entity;
using DataAccess;
using Services.Models;
using FluentResults;
using Services.Constants;

namespace Services;

public class RecordService : CrudService<RecordModel, Record>, IRecordService
{
    public RecordService(ApplicationContext context) : base(context) { }

    public async Task<PageModel<RecordModel>> GetHistoryAsync(int page, string patientId)
    {
        return await GetAsync(page, 
            x => x.PatientId == patientId && x.IsCured == true && x.DateOfClose != null,
            false,
            x => x.DateOfClose!);
    }

    public async Task<PageModel<RecordModel>> GetAsync(int page, string query) =>
        await base.GetAsync(page: page,
            predicate: x => x.Diagnosis != null && (x.PatientId.Contains(query) ||
                                                    x.Diagnosis.Contains(query) ||
                                                    x.Symptoms.Contains(query)),
            false,
            x => x.Id);

    public async Task<PageModel<RecordModel>> GetFilteredRecords(int page, string query, bool isCured, bool isApparatus)
    {
        return await base.GetAsync(page: page,
            predicate: x => x.Diagnosis != null && (
                x.PatientId.Contains(query) ||
                (isCured && x.IsCured) ||
                (isApparatus && x.UseApparatus) ||
                x.Diagnosis.Contains(query) ||
                x.Symptoms.Contains(query)
            ),
            false,
            x => x.Id);
    }

    
/* To Controller
     startDate ??= DateOnly.MinValue;
     endDate ??= DateOnly.MaxValue;
    */
    public async Task<PageModel<RecordModel>> GetByDateAsync(int page, DateOnly startDate , DateOnly endDate)
    {
        return await GetAsync(page, x =>
                DateInRange(x.DateOfClose, startDate,endDate) ||
                DateInRange(x.DateOfOpen, startDate,endDate),
                false,
                x => x.Id);
    }
    
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
    
    private static bool DateInRange(DateOnly? dateToCheck, DateOnly startDate, DateOnly endDate)
    {
        return dateToCheck == null || dateToCheck >= startDate && dateToCheck < endDate;
    }
}