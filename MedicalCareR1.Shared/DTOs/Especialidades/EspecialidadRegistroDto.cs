using System.ComponentModel.DataAnnotations;

namespace MedicalCareR1.Shared.DTOs.Especialidades;

public class EspecialidadRegistroDto
{
    public int Id { get; set; }
    [Required]
    public string name { get; set; } = string.Empty;
    public bool isActive { get; set; } = true;
}
