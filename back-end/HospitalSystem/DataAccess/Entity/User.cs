using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entity
{
    public class User:IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
