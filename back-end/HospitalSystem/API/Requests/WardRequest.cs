using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class WardRequest: IRequestBody
{
    [Required]
    public int Floor { get; set; }
    [Required]
    public string Type { get; set; } = null!;
    [Required]
    public int Capacity { get; set; }
    [Required]
    public int Number { get; set; }
}