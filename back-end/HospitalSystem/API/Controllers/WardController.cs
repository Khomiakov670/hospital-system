using API.Requests;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

public class WardController: CrudController<WardModel, WardRequest>
{
    public WardController(IWardService service) : base(service)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModel<WardModel>>> GetAsync(int? floor = null,int? capacity = null,int? number = null, string type = "", int page = 1)
    {
        var wardService = service as IWardService;
        return await wardService!.GetAsync(page, type, floor, capacity, number);
    }
}