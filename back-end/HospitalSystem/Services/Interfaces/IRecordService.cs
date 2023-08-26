using FluentResults;
using Services.Models;

namespace Services;

public interface IRecordService
{
    Task<PageModel<RecordModel>> GetHistoryAsync(int page, string patientId);
    Task<PageModel<RecordModel>> GetFilteredRecords(int page, string query, bool isCured = true, bool isApparatus = false);
    Task<PageModel<RecordModel>> GetAsync(int page, string query);
    Task<PageModel<RecordModel>> GetByDateAsync(int page, DateOnly startDate , DateOnly endDate);
    Task<Result> CloseRecordAsync(int page, int recordId);
}