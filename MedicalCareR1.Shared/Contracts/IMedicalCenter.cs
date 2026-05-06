using MedicalCareR1.Shared.DTOs.CentrosMedicos;
using MedicalCareR1.Shared.DTOs.Shared;

namespace MedicalCareR1.Shared.Contracts;

public interface IMedicalCenter
{
    Task<IEnumerable<MedicalCenterResponseDto?>> GetAllCentros(CancellationToken ct);
    Task<PaginatedResultDto<MedicalCenterResponseDto>> GetCentrosPaged(ListedPagedDto paginacion, CancellationToken ct);
    Task<MedicalCenterResponseDto?> CreateCentro(MedicalCenterRegistroDto medicalCenterRegistroDto, CancellationToken ct);
    Task<MedicalCenterResponseDto?> UpdateCentro(Guid id, MedicalCenterResponseDto medicalCenterResponseDto, CancellationToken ct);
    Task ToggleStatusAsync(Guid id, CancellationToken ct);
}
