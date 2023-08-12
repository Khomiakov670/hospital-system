using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<T> Created<T>(T value) => CreatedAtAction(null, value);
        protected ActionResult BadRequest(params string[] errors) => Error(errors, StatusCodes.Status400BadRequest);
        protected new ActionResult Forbid(params string[] errors) => Error(errors, StatusCodes.Status403Forbidden);
        protected ActionResult NotFound(params string[] errors) => Error(errors, StatusCodes.Status404NotFound);
        private ActionResult Error(IEnumerable<string> errors, int statusCode)
        {
            ModelStateDictionary pairs = new();
            foreach (var error in errors)
                pairs.AddModelError(string.Empty, error);
            return ValidationProblem(statusCode: statusCode, modelStateDictionary: pairs);
        }
        protected ActionResult HandleResult(IdentityResult result) => result.Succeeded
            ? Ok()
            : BadRequest(result.Errors.Select(e => e.Description).ToArray());
    }
}
