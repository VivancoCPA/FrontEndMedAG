using MedicalCareR1.Shared.DTOs.Aseguradoras;
using MedicalCareR1.Shared.DTOs.Shared;

namespace MedicalCareR1.Shared.Contracts;

public interface IAseguradoraService
{
    Task<IEnumerable<AseguradoraResponseDto>> GetAllAseguradoraAsync();

    Task<ApiResponse<bool>> ToggleAseguradoraAsync(int id);

}
