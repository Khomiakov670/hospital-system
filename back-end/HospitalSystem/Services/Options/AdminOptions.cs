using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Configs;

public class AdminOptions
{
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public const string Section = "Admin";
}