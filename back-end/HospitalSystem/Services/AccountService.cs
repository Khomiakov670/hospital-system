using BusinessLogicLayer.Services;
using DataAccess;
using DataAccess.Entity;
using FluentResults;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PasswordGenerator;
using Services.Constants;
using Services.Models;
using Services.Models.Register;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.Encodings.Web;
namespace Services
{
    public class AccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationContext context;
        private readonly IEmailService emailService;
        private readonly IConfiguration configuration;

        public AccountService(UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           RoleManager<IdentityRole> roleManager,
                           IConfiguration configuration,
                           ApplicationContext context,
                           IEmailService emailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            InitializeAsync(userManager, roleManager, configuration).Wait();
            this.emailService = emailService;
            this.configuration = configuration;
        }

        public async Task<Result> ChangePasswordAsync(string oldPassword, string newPassword, ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            var result = await userManager.ChangePasswordAsync(user!, oldPassword, newPassword);
            return HandleResult(result);
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
                return Result.Fail(Errors.NotFound);
            var result = await userManager.DeleteAsync(user);
            return HandleResult(result);
        }

        

        public async Task<Result> LoginAsync(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, true, false);
            return result.Succeeded ? Result.Ok() : Result.Fail(Errors.InvalidCredentials);
        }

        public async Task LogoutAsync() => await signInManager.SignOutAsync();

        public async Task<Result<TModel>> RegisterAsync<TModel>(RegisterModel model)
            where TModel : UserModel
        {
            var user = model.Create();
            var password = new Password(12).IncludeNumeric().IncludeLowercase().IncludeUppercase().Next();
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                result = await userManager.AddToRoleAsync(user, model.GetRole());
                _ = emailService.SendEmailAsync(user.Email!, "Registration", $"Hi! Your password is: {password}");
                return Result.Ok(user.Adapt<TModel>());
            }
            return HandleResult(result);
        }

        public async Task<UserModel?> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            return user!.Adapt<UserModel?>();
        }
        public async Task<string?> GetRole(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            IList<string> roles = await userManager.GetRolesAsync(user!);
            return roles.FirstOrDefault();
        }

        private static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            string adminEmail = configuration["Admin:Email"]!;
            string adminPassword = configuration["Admin:Password"]!;
            await AddRole(roleManager, Roles.Admin);
            await AddRole(roleManager, Roles.Doctor);
            await AddRole(roleManager, Roles.Patient);
            if (await userManager.FindByEmailAsync(adminEmail) is null)
            {
                var admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FullName = Roles.Admin
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

        public string? GetUserId(ClaimsPrincipal principal) => userManager.GetUserId(principal);

        public Task<PageModel<UserModel>> GetPatientsAsync(int page, string query) => GetUsers<UserModel,Patient>(page, query);

        public Task<PageModel<DoctorModel>> GetDoctorsAsync(int page, string query, string? specialization = null)
        {
            Expression<Func<Doctor, bool>>? predicate = specialization is null ? null : x => x.Specialization == specialization;
            return GetUsers<DoctorModel,Doctor>(page,query,predicate);
        }

        private async Task<PageModel<TModel>> GetUsers<TModel, TEntity>(int page, string query, Expression<Func<TEntity, bool>>? predicate = null)
            where TModel : UserModel
            where TEntity : User
        {
            var users = context.Set<TEntity>().Where(x => x.FullName.Contains(query) || x.Email.Contains(query));
            var itemsPerPage = Convert.ToInt32(configuration["ItemsPerPage"]);
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
}