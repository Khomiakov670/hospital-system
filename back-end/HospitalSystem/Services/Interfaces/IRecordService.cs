using System.Security.Claims;
using FluentResults;
using Services.Models;

namespace Services;

public interface IRecordService
{
    Task<Result> CloseRecordAsync(int page, int recordId);

    Task<PageModel<RecordModel>> GetAsync(int page, string query,
        bool? isCured,bool? useApparatus, DateOnly? startDate, DateOnly? endDate, string? patientId = null
    );

    Task<PageModel<RecordModel>> GetAsync(int page, string query,
        bool? isCured,bool? useApparatus, DateOnly? startDate, DateOnly? endDate, ClaimsPrincipal patient);
}