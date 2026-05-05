using MedicalCareR1.Shared.DTOs.CentrosMedicos;

namespace MedicalCareR1.Shared.Contracts;

public interface IMedicalCenter
{
    Task<MedicalCenterResponseDto?> CreateCentro(MedicalCenterRegistroDto medicalCenterRegistroDto, CancellationToken ct);
    Task DeleteAsync(Guid id, CancellationToken ct);
    Task ToggleStatusAsync(Guid id, CancellationToken ct);
}
