using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class RecordRequest: IRequestBody
{
    [Required]
    public string Symptoms { get; set; } = null!;
    public string? Diagnosis { get; set; }
    [Required]
    public DateOnly DateOfOpen { get; set; }
    public DateOnly? DateOfClose { get; set; }
    [Required]
    public bool UseApparatus { get; set; }
    [Required]
    public bool IsCured { get; set; }
    [Required]
    public string PatientId { get; set; } = null!;
    public int? TenantId { get; set; }
    public TreatmentRequest? Treatment { get; set; }
}   