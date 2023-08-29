namespace DataAccess.Entity;

public class Snapshots: Entity
{
    public virtual Apparatus Apparatus { get;set;} = null!;
    public DateTime TimeStamp { get; set; }
    public int ApparatusId { get;set;}
    public int Pulse { get; set; }
    public int SystolicPressure { get; set;}
    public int DiastolicPressure { get;set; }

}