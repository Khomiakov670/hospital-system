namespace DataAccess.Entity;

public class Ward : Entity
{
    public virtual List<Tenant> Tenants { get; set; } = null!;
    public int Floor { get; set; }
    public string Type { get; set; } = null!;
    public int Capacity { get; set; }
    public int Number { get; set; } 
}