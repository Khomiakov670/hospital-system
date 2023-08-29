using API.Options;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services;
using Services.Configs;
using Services.Interfaces;
using Services.Models;
using Services.Options;

namespace API.Extensions;

public static class ServiceCollectionExtensions     
{
     public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
        return services;
    }

    public static IServiceCollection AddServicesOptions(this IServiceCollection services, IConfiguration configuration) =>
        services
            .Configure<EmailOptions>(configuration.GetSection(EmailOptions.Section))
            .Configure<AdminOptions>(configuration.GetSection(AdminOptions.Section))
            .Configure<PaginationOptions>(configuration.GetSection(PaginationOptions.Section));

    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services) =>
        services
            .AddTransient<IEmailService, EmailService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IRecordService, RecordService>()
            .AddScoped<ITenantService, TenantService>()
            .AddScoped<IWardService, WardService>()
            .AddScoped<ISnapshotsService, SnapshotsService>()
            .AddScoped<ICrudService<ApparatusModel>, CrudService<ApparatusModel,Apparatus>>();
}