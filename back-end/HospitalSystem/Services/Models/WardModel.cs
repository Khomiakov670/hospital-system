namespace Services.Models;

public class WardModel : EntityModel
{
    public List<TenantModel> Tenants { get; set; }
    public int Floor { get; set; }
    public string Type { get; set; } = null!;
    public int Capacity { get; set; }
    public int Number { get; set; }
}