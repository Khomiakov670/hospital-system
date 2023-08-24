using Services.Models.Register;

namespace API.Requests.Account.Register
{
    public class PatientRegisterRequest: RegisterRequest
    {
        public override PatientRegisterRequest CreateModel() => CreateModel<RegisterModel>();
    }
}
