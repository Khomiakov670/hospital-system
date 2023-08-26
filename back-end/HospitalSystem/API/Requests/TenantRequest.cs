using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class TenantRequest: IRequestBody
{
    [Required]
    public int WardNumber { get; set; }
    [Required]
    public int SerialNumber { get; set; }
    [Required]
    public int Functional { get; set; }
}