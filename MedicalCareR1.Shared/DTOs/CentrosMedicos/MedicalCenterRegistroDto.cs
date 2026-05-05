
using System.ComponentModel.DataAnnotations;

namespace MedicalCareR1.Shared.DTOs.CentrosMedicos;
public class MedicalCenterRegistroDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
