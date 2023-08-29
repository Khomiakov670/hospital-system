namespace Services.Models;

public class ApparatusModel:EntityModel
{
    public int SerialNumber { get; set; }
    public int Functional { get; set; }
    public int TenantId { get; set; }
}