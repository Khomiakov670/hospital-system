using System.Security.Claims;
using FluentResults;
using Services.Interfaces;
using Services.Models;

namespace Services;

public interface IRecordService : ICrudService<RecordModel>
{
    Task<PageModel<RecordModel>> GetAsync(int page, string query,
        bool? isCured,bool? useApparatus, DateOnly? startDate, DateOnly? endDate, string? patientId = null
    );

    Task<PageModel<RecordModel>> GetAsync(int page, string query,
        bool? isCured,bool? useApparatus, DateOnly? startDate, DateOnly? endDate, ClaimsPrincipal patient);

    Task<Result> CloseRecordAsync(int page, int recordId, DateOnly dateOfClose);
}