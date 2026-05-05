namespace MedicalCareR1.Shared.DTOs.CentrosMedicos;

public class MedicalCenterResponseDto
{
    public Guid Id { get; set; }
    public string name { get; set; } = string.Empty;
    public string type { get; set; } = string.Empty;
    public string? address { get; set; }
    public string? phone { get; set; }
    public bool isActive { get; set; } = true;
    public double? latitude { get; set; }
    public double? longitude { get; set; }
}
