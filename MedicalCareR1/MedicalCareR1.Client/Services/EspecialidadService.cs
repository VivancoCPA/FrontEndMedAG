using MedicalCareR1.Client.Utilities;
using MedicalCareR1.Shared;
using MedicalCareR1.Shared.Contracts;
using MedicalCareR1.Shared.DTOs.CentrosMedicos;
using MedicalCareR1.Shared.DTOs.Especialidades;
using MedicalCareR1.Shared.DTOs.Shared;
using System.Net.Http.Json;

namespace MedicalCareR1.Client.Services;

public class EspecialidadService(HttpClient _http) : IEspecialidadService
{
    public async Task<EspecialidadResponseDto> CreateEspecialidadAsync(EspecialidadRegistroDto request)
    {
        var response = await _http.PostAsJsonAsync("specialties", request);

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

        return await response.Content.ReadFromJsonAsync<EspecialidadResponseDto>();
    }

    public Task<IEnumerable<EspecialidadResponseDto>> GetAllEspecialidadesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EspecialidadResponseDto> GetEspecialidadByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedResultDto<EspecialidadResponseDto>> GetEspecialidadPaged(ListedPagedDto paginacion)
    {
        var url = $"specialties/paged?page={paginacion.Page}&pageSize={paginacion.PageSize}";
        //Console.WriteLine(url);
        if (!string.IsNullOrWhiteSpace(paginacion.Search))
            url += $"&search={Uri.EscapeDataString(paginacion.Search)}";// Asegúrate de escapar el término de búsqueda para evitar problemas con caracteres especiales

        if (!string.IsNullOrWhiteSpace(paginacion.SortBy))
            url += $"&sortBy={paginacion.SortBy}&sortDesc={paginacion.SortDesc.ToString().ToLower()}";

        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();// Si la respuesta no es exitosa, lanzará una excepción aquí

        var resultado = await response.Content.ReadFromJsonAsync<PaginatedResultDto<EspecialidadResponseDto>>();

        return resultado ?? new PaginatedResultDto<EspecialidadResponseDto>(
                [],
                paginacion.Page,
                paginacion.PageSize,
                0);
    }

    public async Task<ApiResponse<bool>> ToggleEspecialidadAsync(int id)
    {
        var response = await _http.PatchAsync($"specialties/{id}/toggle-status", content: null);
        if (response.IsSuccessStatusCode)
        {
            return new ApiResponse<bool>
            {
                Success = true,
                Data = true
            };
        }

        // ❌ leer error backend
        var error = await Helper.LeerErrorAsync(response);

        return new ApiResponse<bool>
        {
            Success = false,
            ErrorMessage = error
        };

        //response.EnsureSuccessStatusCode();
    }
    public async Task<ApiResponse<EspecialidadResponseDto>> UpdateEspecialidadAsync(int id, EspecialidadRegistroDto request)
    {
        var response = await _http.PutAsJsonAsync($"specialties/{id}", request);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<EspecialidadResponseDto>();
            return new ApiResponse<EspecialidadResponseDto>
            {
                Success = true,
                Data = data
            };
        }

        // ❌ error
        var error = await Helper.LeerErrorAsync(response);

        return new ApiResponse<EspecialidadResponseDto>
        {
            Success = false,
            ErrorMessage = error
        };

        //response.EnsureSuccessStatusCode();

        //return await response.Content.ReadFromJsonAsync<EspecialidadResponseDto>();
    }
}
