namespace Services.Models;

public class SnapshotsModel: EntityModel
{
    public int ApparatusId { get; set; }
    public DateTime TimeStamp { get; set; }
    public int Pulse { get; set;}
    public int SystolicPressure { get; set;}
    public int DiastolicPressure { get; set;}
}