using API.Requests.Account;
using API.Requests.Account.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Constants;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAccountService userService;

        public AccountController(IAccountService userService) => this.userService = userService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var result = await userService.LoginAsync(request.Email, request.Password);
            return HandleResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserModel>> RegisterAsync([FromBody] RegisterRequest request) =>
            await RegisterAsync<UserModel>(request);


        [HttpPost]
        [Authorize(Roles = Roles.Doctor)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DoctorModel>> RegisterAsync([FromBody] DoctorRegisterRequest request) =>
            await RegisterAsync<DoctorModel>(request);

        private async Task<ActionResult<TModel>> RegisterAsync<TModel>(RegisterRequest request)
            where TModel : UserModel
        {
            var model = request.CreateModel();
            var result = await userService.RegisterAsync<TModel>(model);
            return HandleCreatedResult(result);
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async void LogoutAsync() => await userService.LogoutAsync();

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserModel?>> InfoAsync() => await userService.GetUser(User);

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string?>> RoleAsync() => await userService.GetRole(User);



        [HttpDelete]
        [Authorize(Roles = Roles.CUSTOMER_SERVICE)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync()
        {
            var result = await userService.DeleteAsync(User);
            return HandleResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Service)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await userService.DeleteAsync(User, id);
            return HandleResult(result);
        }


        11





        [HttpPatch]
        [Authorize(Roles = Roles.CUSTOMER_SERVICE)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest model)
        {
            var result = await userService.ChangePasswordAsync(model.OldPassword, model.NewPassword, User);
            return HandleResult(result);
        }




        [HttpGet]
        [Authorize(Roles = Roles.Service)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PagedArrayModel<EmployeeModel>>> GetEmployees(int cateringId, int page = 1, string query = "") =>
            await userService.GetEmployeesAsync(cateringId, page, query);

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PagedArrayModel<LockableUserModel<ServiceModel>>>> GetServices(string? country, int page = 1, string query = "") =>
            await userService.GetServicesAsync(page, query, country);

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PagedArrayModel<LockableUserModel<UserModel>>>> GetCustomers(int page = 1, string query = "") =>
            await userService.GetCustomersAsync(page, query);


    }
}
