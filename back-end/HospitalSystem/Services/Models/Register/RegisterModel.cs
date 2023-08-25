using DataAccess.Entity;
using Mapster;
using Services.Constants;

namespace Services.Models.Register;

public class RegisterModel
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName => Email;
    public string Gender { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public virtual User Create() => this.Adapt<Patient>();
    public virtual string GetRole() => Roles.Patient;
}