using System.Net.NetworkInformation;

namespace MedicalCareR1.Shared.DTOs.Especialidades;

public class EspecialidadResponseDto
{
    public int Id { get; set; }
    public string name { get; set; } = string.Empty;
    public bool isActive { get; set; } = true;
    public DateTime createdAt { get; set; }
}
