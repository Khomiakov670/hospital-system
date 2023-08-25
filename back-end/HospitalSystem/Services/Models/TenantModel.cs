namespace Services.Models;

public class TenantModel : EntityModel
{
    public int WardNumber { get; set; }
    public ApparatusModel? Apparatus { get; set; }
}