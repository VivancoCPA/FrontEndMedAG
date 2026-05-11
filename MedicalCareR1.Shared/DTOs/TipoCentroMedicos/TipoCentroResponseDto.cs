
namespace MedicalCareR1.Shared.DTOs.TipoCentroMedicos;

public class TipoCentroResponseDto
{
    public int Id { get; set; }
    public string name { get; set; } = null!;
    public bool isActive { get; set; } = true;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}
