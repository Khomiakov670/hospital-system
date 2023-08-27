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
public class RecordController : CrudController<RecordModel, RecordRequest>
{
    public RecordController(ICrudService<RecordModel> service) : base(service)
    {
    }

    [HttpGet("{patientId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<RecordModel>>> GetAsync(string patientId,string query = "", bool? isCured = null, bool? useApparatus = null,
        DateOnly? startDate = null, DateOnly? endDate = null, int page = 1)
    {
        var recordService = service as IRecordService;
        return await recordService!.GetAsync(page, query, isCured, useApparatus, startDate, endDate, patientId);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<RecordModel>>> GetAsync(string query = "", bool? isCured = null, bool? useApparatus = null,
        DateOnly? startDate = null, DateOnly? endDate = null, int page = 1)
    {
        var recordService = service as IRecordService;
        return await recordService!.GetAsync(page, query, isCured, useApparatus, startDate, endDate, User);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CloseRecordAsync(int recordId, int page = 1)
    {
        var recordService = service as IRecordService;
        var result = await recordService!.CloseRecordAsync(page, recordId);
        return HandleResult(result);
    }
}