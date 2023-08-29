using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class SnapshotsRequest: IRequestBody
{
    [Required]
    public int ApparatusId { get; set; }
    [Required]
    public int Pulse { get; set; }
    [Required]
    public int SystolicPressure { get; set;}
    [Required]
    public int DiastolicPressure { get; set;}
    [Required]
    public DateTime TimeStamp { get; set; }
}