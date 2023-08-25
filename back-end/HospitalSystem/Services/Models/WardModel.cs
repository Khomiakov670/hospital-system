namespace Services.Models;

public class WardModel : EntityModel
{
    public int Floor { get; set; }
    public string Type { get; set; } = null!;
    public int Capacity { get; set; }
}