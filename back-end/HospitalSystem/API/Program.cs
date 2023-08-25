    using API.Options;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Configs;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var logging = builder.Logging;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.Configure<PaginationOptions>(configuration.GetSection(PaginationOptions.Section))
        .Configure<AdminOptions>(configuration.GetSection(AdminOptions.Section));


void SetupAction(IdentityOptions options)
{
    options.Password.RequireNonAlphanumeric = false;
}


services.AddIdentity<User, IdentityRole>(SetupAction)
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();

var connectionString = configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));

services.AddTransient<IAccountService, AccountService>()
        .AddTransient<IEmailService, EmailService>();

services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
