using DataAccess.Entity;
using Mapster;
using Services.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Register
{
    public class DoctorRegisterModel: RegisterModel
    {
        public string Specialization { get; set; } = null!;
        public override User Create() => this.Adapt<Doctor>();
        public override string GetRole() => Roles.Doctor;
    }
}
