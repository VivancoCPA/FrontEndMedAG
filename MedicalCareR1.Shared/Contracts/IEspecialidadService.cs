
using MedicalCareR1.Shared.DTOs.Especialidades;
using MedicalCareR1.Shared.DTOs.Shared;

namespace MedicalCareR1.Shared.Contracts;

public interface IEspecialidadService
{
    Task<IEnumerable<EspecialidadResponseDto>> GetAllEspecialidadesAsync();
    Task<PaginatedResultDto<EspecialidadResponseDto>> GetEspecialidadPaged(ListedPagedDto paginacion);
    Task<EspecialidadResponseDto> GetEspecialidadByIdAsync(int id);
    Task<EspecialidadResponseDto> CreateEspecialidadAsync(EspecialidadRegistroDto request);
    Task<ApiResponse<EspecialidadResponseDto>> UpdateEspecialidadAsync(int id, EspecialidadRegistroDto request);
    Task<ApiResponse<bool>> ToggleEspecialidadAsync(int id);
}
