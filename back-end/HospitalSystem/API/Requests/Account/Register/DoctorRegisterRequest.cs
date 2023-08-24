using Services.Models.Register;

namespace API.Requests.Account.Register
{
    public class DoctorRegisterRequest: RegisterRequest
    {
        public override DoctorRegisterModel CreateModel() => CreateModel<DoctorRegisterModel>();
    }
}
