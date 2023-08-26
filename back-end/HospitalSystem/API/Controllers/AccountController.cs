using API.Requests.Account;
using API.Requests.Account.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Constants;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers;

[ApiController]
[Route(Routes.DefaultRoute)]
public class AccountController : BaseController
{
    private readonly IAccountService _userService;

    public AccountController(IAccountService userService) => this._userService = userService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var result = await _userService.LoginAsync(request.Email, request.Password);
        return HandleResult(result);
    }

    [HttpPost(Roles.Patient)]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserModel>> RegisterAsync([FromBody] RegisterRequest request) =>
        await RegisterAsync<UserModel>(request);


    [HttpPost(Roles.Doctor)]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<DoctorModel>> RegisterAsync([FromBody] DoctorRegisterRequest request) =>
        await RegisterAsync<DoctorModel>(request);

    private async Task<ActionResult<TModel>> RegisterAsync<TModel>(RegisterRequest request)
        where TModel : UserModel
    {
        var model = request.CreateModel();
        var result = await _userService.RegisterAsync<TModel>(model);
        return HandleCreatedResult(result);
    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async void LogoutAsync() => await _userService.LogoutAsync();

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserModel?>> InfoAsync() => await _userService.GetUser(User);
    
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserModel?>> GetUserId() => await _userService.GetUser(User);
    

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<string?>> RoleAsync() => await _userService.GetRole(User);



    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await _userService.DeleteAsync(id);
        return HandleResult(result);
    }


    [HttpPatch]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest model)
    {
        var result = await _userService.ChangePasswordAsync(model.OldPassword, model.NewPassword, User);
        return HandleResult(result);
    }


    [HttpGet]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<PageModel<DoctorModel>>> GetDoctors(int page = 1, string query = "", string? specialization = null
        ) =>
        await _userService.GetDoctorsAsync(page, query, specialization);

    [HttpGet]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<PageModel<UserModel>>> GetPatients(int page = 1, string query = "") =>
        await _userService.GetPatientsAsync(page, query);
}