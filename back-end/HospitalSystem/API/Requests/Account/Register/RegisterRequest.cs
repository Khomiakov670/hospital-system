using Mapster;
using Services.Models.Register;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account.Register;

public abstract class RegisterRequest
{
    [Required] public string FullName { get; set; } = null!;

    [Required, EmailAddress] public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    protected T CreateModel<T>() => this.Adapt<T>();
    public abstract RegisterModel CreateModel();
}