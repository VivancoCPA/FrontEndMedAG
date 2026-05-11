
using System.ComponentModel.DataAnnotations;

namespace MedicalCareR1.Shared.DTOs.TipoCentroMedicos;

public class TipoCentroRegistroDto
{
    public int Id { get; set; }
    [Required]
    public string name { get; set; } = string.Empty;
    public bool isActive { get; set; } = true;
}
