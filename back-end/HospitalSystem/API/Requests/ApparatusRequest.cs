using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account;

public class ApparatusRequest: IRequestBody
{
    [Required]
    public int SerialNumber { get; set; }
    [Required]
    public int Functional { get; set; }
    [Required]
    public int TenantId { get; set; }
}