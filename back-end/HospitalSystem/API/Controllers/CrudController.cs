using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Services.Interfaces;
using Services.Models;
using API.Requests;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route(Routes.CRUD_ROUTE)]
    public abstract class CrudController<TModel, TRequest> : BaseController
        where TModel : EntityModel
        where TRequest : IRequestBody
    {
        protected readonly ICrudService<TModel> patient;

        protected CrudController(ICrudService<TModel> service) => this.patient = service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TModel>> AddAsync([FromBody] TRequest request)
        {
            var model = request.Adapt<TModel>();
            var result = await patient.AddAsync(model);
            return HandleResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> EditAsync(int id, [FromBody] TRequest request)
        {
            var model = request.Adapt<TModel>();
            model.Id = id;
            var result = await patient.EditAsync(model);
            return HandleResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await patient.DeleteAsync(id);
            return HandleResult(result);
        }
    }
}
