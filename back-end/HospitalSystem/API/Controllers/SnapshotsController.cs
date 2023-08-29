using API.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

[ApiController]
[Route(Routes.CrudRoute)]
[AllowAnonymous]
public class SnapshotsController: CrudController<SnapshotsModel, SnapshotsRequest>
{
    public SnapshotsController(ISnapshotsService service) : base(service)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<SnapshotsModel>>> GetAsync(int page = 1)
    {
        var snapshotsService = service as ISnapshotsService;
        return await snapshotsService!.GetAsync(page);
    }
    
}