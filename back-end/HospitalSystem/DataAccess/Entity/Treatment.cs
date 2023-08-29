using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entity;

[Owned]
public class Treatment
{
    public string? Medicines { get; set; }
    public string? Procedures { get; set; }
    public string? Recommendations { get; set; }
}