using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entity;


public class Apparatus: Entity
{
    public int SerialNumber { get; set; }
    public int Functional { get; set; }
    public virtual Tenant Tenant { get; set; }
    public int TenantId { get; set; }
}