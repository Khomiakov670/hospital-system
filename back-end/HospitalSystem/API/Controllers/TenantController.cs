using API.Requests;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

public class TenantController: CrudController<TenantModel, WardRequest>
{
    public TenantController(ICrudService<TenantModel> service) : base(service)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<TenantModel>>> GetAsync(string query, int page = 1)
    {
        var tenantService = service as ITenantService;
        return await tenantService!.GetAsync(page, query);
    }
}