using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class TreatmentRequest: IRequestBody
{
    [Required]
    public string? Medicines { get; set; }
    [Required]
    public string? Procedures { get; set; }
    [Required]
    public string? Recommendations { get; set; }
}