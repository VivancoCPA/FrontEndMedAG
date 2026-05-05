
using MedicalCareR1.Client.Utilities;
using MedicalCareR1.Shared.Contracts;
using MedicalCareR1.Shared.DTOs.CentrosMedicos;
using System.Net.Http.Json;

namespace MedicalCareR1.Client.Services;

public class MedicalCenterServicio(HttpClient _http) : IMedicalCenter
{
    public async Task<MedicalCenterResponseDto?> CreateCentro(MedicalCenterRegistroDto medicalCenterRegistroDto, CancellationToken ct)
    {
        var response = await _http.PostAsJsonAsync("medical-centers", medicalCenterRegistroDto, ct);

        if (!response.IsSuccessStatusCode)
        {
            // Leer errores de validación (FluentValidation)
            var error = await response.Content
            .ReadFromJsonAsync<ApiValidationError>();
            var mensajes = error?.Errors?
                .SelectMany(e => e.Value)
                .ToList() ?? ["Error de validación desconocido."];
            throw new ApplicationException(string.Join(" | ", mensajes));
        }

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<MedicalCenterResponseDto>();
    }

    public Task DeleteAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task ToggleStatusAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
