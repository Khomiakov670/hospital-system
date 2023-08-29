using API.Options;
using DataAccess;
using DataAccess.Entity;
using FluentResults;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PasswordGenerator;
using Services.Configs;
using Services.Constants;
using Services.Interfaces;
using Services.Models;
using Services.Models.Register;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationContext _context;
    private readonly IEmailService _emailService;
    private readonly PaginationOptions _configuration;


    public AccountService(UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<PaginationOptions> configuration,
        ApplicationContext context,
        IOptions<AdminOptions> adminConfig,
        IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        InitializeAsync(userManager, roleManager, adminConfig.Value).Wait();
        _emailService = emailService;
        _configuration = configuration.Value;
    }

    public async Task<Result> ChangePasswordAsync(string oldPassword, string newPassword, ClaimsPrincipal principal)
    {
        var user = await _userManager.GetUserAsync(principal);
        var result = await _userManager.ChangePasswordAsync(user!, oldPassword, newPassword);
        return HandleResult(result);
    }

    public async Task<Result> DeleteAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
            return Result.Fail(Errors.NotFound);
        var result = await _userManager.DeleteAsync(user);
        return HandleResult(result);
    }


    public async Task<Result> LoginAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
        return result.Succeeded ? Result.Ok() : Result.Fail(Errors.InvalidCredentials);
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    public async Task<Result<TModel>> RegisterAsync<TModel>(RegisterModel model)
        where TModel : UserModel
    {
        var user = model.Create();
        var password = new Password(12).IncludeNumeric().IncludeLowercase().IncludeUppercase().Next();
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded) return HandleResult(result);
        result = await _userManager.AddToRoleAsync(user, model.GetRole());
        if (!result.Succeeded) return HandleResult(result);
        _ = _emailService.SendEmailAsync(user.Email!, "Registration", $"Hi! Your password is: {password}");
        return Result.Ok(user.Adapt<TModel>());
    }

    public async Task<UserModel?> GetUser(ClaimsPrincipal principal)
    {
        var user = await _userManager.GetUserAsync(principal);
        return user!.Adapt<UserModel?>();
    }

    public async Task<string?> GetRole(ClaimsPrincipal principal)
    {
        var user = await _userManager.GetUserAsync(principal);
        IList<string> roles = await _userManager.GetRolesAsync(user!);
        return roles.FirstOrDefault();
    }

    private static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
        AdminOptions configuration)
    {
        var adminEmail = configuration.Email;
        var adminPassword = configuration.Password;
        await AddRole(roleManager, Roles.Admin);
        await AddRole(roleManager, Roles.Doctor);
        await AddRole(roleManager, Roles.Patient);
        if (await userManager.FindByEmailAsync(adminEmail) is null)
        {
            var admin = new User
            {
                Email = adminEmail,
                UserName = adminEmail,
                FullName = Roles.Admin,
                DateOfBirth = DateOnly.MinValue,
                Gender = Roles.Admin,
            };
            var result = await userManager.CreateAsync(admin, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, Roles.Admin);
            }
        }

        static async Task AddRole(RoleManager<IdentityRole> roleManager, string role)
        {
            if (await roleManager.FindByNameAsync(role) is null)
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    public string? GetUserId(ClaimsPrincipal principal) => _userManager.GetUserId(principal);

    public Task<PageModel<UserModel>> GetPatientsAsync(int page, string query) =>
        GetUsers<UserModel, Patient>(page, query);

    public Task<PageModel<DoctorModel>> GetDoctorsAsync(int page, string query, string? specialization)
    {
        Expression<Func<Doctor, bool>>? predicate =
            specialization is null ? null : x => x.Specialization == specialization;
        return GetUsers<DoctorModel, Doctor>(page, query, predicate);
    }

    private async Task<PageModel<TModel>> GetUsers<TModel, TEntity>(int page, string query,
        Expression<Func<TEntity, bool>>? predicate = null)
        where TModel : UserModel
        where TEntity : User
    {
        var users = _context.Set<TEntity>().Where(x => x.Email != null && (x.FullName.Contains(query) || x.Email.Contains(query)));
        var itemsPerPage = Convert.ToInt32(_configuration.ItemsPerPage);
        if (predicate is not null)
            users = users.Where(predicate);
        var entities = await users.OrderByDescending(x => x.FullName)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
        var models = entities.Adapt<List<TModel>>();

        return new PageModel<TModel>(models, users.Count());
    }

    public static Result HandleResult(IdentityResult result) => result.Succeeded
        ? Result.Ok()
        : Result.Fail(result.Errors.Select(e => e.Description));
}