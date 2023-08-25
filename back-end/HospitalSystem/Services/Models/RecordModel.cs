namespace Services.Models;

public class RecordModel : EntityModel
{
    public string PatientId { get; set; } = null!;
    public string DoctorId { get; set; } = null!;
    public int? TenantId { get; set; }
    public TreatmentModel? Treatment { get; set; }

    public string Symptoms { get; set; } = null!;
    public bool IsCured { get; set; }
    public string? Diagnosis { get; set; }
    public DateOnly DateOfOpen { get; set; }
    public DateOnly? DateOfClose { get; set; }
    public bool UseApparatus { get; set; }
}