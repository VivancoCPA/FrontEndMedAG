
using System.ComponentModel.DataAnnotations;

namespace MedicalCareR1.Shared.DTOs.Aseguradoras;

public class AseguradoraRegistrotDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PersonInCharge { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    
}
