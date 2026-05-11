using MedicalCareR1.Shared.DTOs.Shared;
using MedicalCareR1.Shared.DTOs.TipoCentroMedicos;

namespace MedicalCareR1.Shared.Contracts;

public interface ITipoCentroService
{
    Task<IEnumerable<TipoCentroResponseDto>> GetAllTipoCentroAsync();
    Task<PaginatedResultDto<TipoCentroResponseDto>> GetTipoCentroPaged(ListedPagedDto paginacion);
    Task<TipoCentroResponseDto> GetTipoCentroByIdAsync(int id);
    Task<ApiResponse<TipoCentroResponseDto>> CreateTipoCentroAsync(TipoCentroRegistroDto request);
    Task<ApiResponse<TipoCentroResponseDto>> UpdateTipoCentroAsync(int id, TipoCentroRegistroDto request);
    Task<ApiResponse<bool>> ToggleTipoCentroAsync(int id);
}
