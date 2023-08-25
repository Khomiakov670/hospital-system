namespace DataAccess.Entity;

public class Record : Entity
{
    public virtual Patient Patient { get; set; } = null!;
    public string PatientId { get; set; } = null!;
    public virtual Doctor Doctor { get; set; } = null!;
    public string DoctorId { get; set; } = null!;
    public virtual Treatment? Treatment { get; set; }
    public virtual Tenant? Tenant { get; set; }
    public int? TenantId { get; set; }

    public string Symptoms { get; set; } = null!;
    public bool IsCured { get; set; }
    public string? Diagnosis { get; set; }
    public DateOnly DateOfOpen { get; set; }
    public DateOnly? DateOfClose { get; set; }
    public bool UseApparatus { get; set; }
}