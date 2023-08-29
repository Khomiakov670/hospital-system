using System.ComponentModel.DataAnnotations;
using API.Requests.Account;
using DataAccess.Entity;

namespace API.Requests;

public class TenantRequest: IRequestBody
{
    [Required]
    public int WardId { get; set; }
}