using DataAccess.Entity;
using Mapster;
using Services.Constants;

namespace Services.Models.Register
{
    public class RegisterModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName => Email;
        public virtual User Create() => this.Adapt<Patient>();
        public virtual string GetRole() => Roles.Patient;
    }
}