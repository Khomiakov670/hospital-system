using FluentResults;
using Services.Models;
using Services.Models.Register;
using System.Security.Claims;

namespace Services.Interfaces;

public interface IAccountService
{
    Task<Result> ChangePasswordAsync(string oldPassword, string newPassword, ClaimsPrincipal principal);
    Task<Result> DeleteAsync(string id);
    Task<PageModel<DoctorModel>> GetDoctorsAsync(int page, string query, string? specialization = null);
    Task<PageModel<UserModel>> GetPatientsAsync(int page, string query);
    Task<string?> GetRole(ClaimsPrincipal principal);
    Task<UserModel?> GetUser(ClaimsPrincipal principal);
    string? GetUserId(ClaimsPrincipal principal);
    Task<Result> LoginAsync(string email, string password);
    Task LogoutAsync();
    Task<Result<TModel>> RegisterAsync<TModel>(RegisterModel model) where TModel : UserModel;
}