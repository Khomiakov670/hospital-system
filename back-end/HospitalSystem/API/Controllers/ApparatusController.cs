using API.Requests.Account;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

public class ApparatusController: CrudController<ApparatusModel,ApparatusRequest>
{
    public ApparatusController(ICrudService<ApparatusModel> service) : base(service)
    {
    }
}