
using MedicalCareR1.Client.Utilities;
using MedicalCareR1.Shared.Contracts;
using MedicalCareR1.Shared.DTOs.CentrosMedicos;
using MedicalCareR1.Shared.DTOs.Shared;
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

    public async Task<IEnumerable<MedicalCenterResponseDto?>> GetAllCentros(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedResultDto<MedicalCenterResponseDto>> GetCentrosPaged(ListedPagedDto paginacion, CancellationToken ct)
    {
        
        var url = $"medical-centers/paged?page={paginacion.Page}&pageSize={paginacion.PageSize}";
        Console.WriteLine(url);
        if (!string.IsNullOrWhiteSpace(paginacion.Search))
            url += $"&search={Uri.EscapeDataString(paginacion.Search)}";// Asegúrate de escapar el término de búsqueda para evitar problemas con caracteres especiales

        if (!string.IsNullOrWhiteSpace(paginacion.SortBy))
            url += $"&sortBy={paginacion.SortBy}&sortDesc={paginacion.SortDesc.ToString().ToLower()}";

        var response = await _http.GetAsync(url, ct);
        response.EnsureSuccessStatusCode();// Si la respuesta no es exitosa, lanzará una excepción aquí

        var resultado = await response.Content.ReadFromJsonAsync<PaginatedResultDto<MedicalCenterResponseDto>>
            (cancellationToken: ct);

        return resultado ?? new PaginatedResultDto<MedicalCenterResponseDto>(
                [],
                paginacion.Page,
                paginacion.PageSize,
                0);
    }

    public async Task ToggleStatusAsync(Guid id, CancellationToken ct)
    {
        var response = await _http.PatchAsync($"medical-centers/{id}/toggle-status", content: null);
        response.EnsureSuccessStatusCode();
    }

    public async Task<MedicalCenterResponseDto?> UpdateCentro(Guid id, MedicalCenterResponseDto medicalCenterResponseDto, CancellationToken ct)
    {
        var response = await _http.PutAsJsonAsync($"medical-centers/{id}", medicalCenterResponseDto, ct);
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

        return await response.Content.ReadFromJsonAsync<MedicalCenterResponseDto>(cancellationToken: ct);
    }
}
