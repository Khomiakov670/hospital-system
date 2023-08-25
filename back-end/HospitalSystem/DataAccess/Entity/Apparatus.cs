using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entity;

[Owned]
public class Apparatus : Entity
{
    public int SerialNumber { get; set; }
    public int Functiional { get; set; }
}