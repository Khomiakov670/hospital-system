using API.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Constants;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

[ApiController]
[Route(Routes.CrudRoute)]
[Authorize(Roles = Roles.Doctor)]
public class RecordController: CrudController<RecordModel,RecordRequest>
{
    public RecordController(ICrudService<RecordModel> service) : base(service)
    {
    }
    
    [HttpGet("{patientId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<RecordModel>>> GetHistoryAsync(string patientId, int page = 1)
    {
        var recordService = service as IRecordService;
        return await recordService!.GetHistoryAsync(page, patientId);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<RecordModel>>> GetAsync(string query, int page = 1)
    {
        var recordService = service as IRecordService;
        return await recordService!.GetAsync(page, query);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<RecordModel>>> GetFilteredRecords(string query,bool isCured = true, bool isApparatus = false, int page = 1)
    {
        var recordService = service as IRecordService;
        return await recordService!.GetFilteredRecords(page, query, isCured, isApparatus);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<RecordModel>>> GetByDateAsync(DateOnly? startDate = null, DateOnly? endDate = null, int page = 1)
    {
        var recordService = service as IRecordService;
        return await recordService!.GetByDateAsync(page, startDate ?? DateOnly.MinValue, endDate ?? DateOnly.MaxValue);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CloseRecordAsync(int recordId, int page = 1)
    {
        var recordService = service as IRecordService;
        var result = await recordService!.CloseRecordAsync(page, recordId);
        return HandleResult(result);
    }
}