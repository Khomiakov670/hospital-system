using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class RecordRequest: IRequestBody
{
    [Required]
    public string Symptoms { get; set; } = null!;
    [Required]
    public string? Diagnosis { get; set; }
    [Required]
    public DateOnly DateOfOpen { get; set; }
    [Required]
    public DateOnly? DateOfClose { get; set; }
    [Required]
    public bool UseApparatus { get; set; }
    [Required]
    public bool IsCured { get; set; }
}