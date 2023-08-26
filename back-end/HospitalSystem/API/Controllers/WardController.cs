using API.Requests;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

public class WardController: CrudController<WardModel, WardRequest>
{
    public WardController(ICrudService<WardModel> service) : base(service)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<WardModel>>> GetAsync(string query, int page = 1)
    {
        var wardService = service as IWardService;
        return await wardService!.GetAsync(page, query);
    }
}