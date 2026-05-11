using MedicalCareR1.Client.Utilities;
using MedicalCareR1.Shared;
using MedicalCareR1.Shared.Contracts;
using MedicalCareR1.Shared.DTOs.Especialidades;
using MedicalCareR1.Shared.DTOs.Shared;
using MedicalCareR1.Shared.DTOs.TipoCentroMedicos;
using System.Net.Http.Json;

namespace MedicalCareR1.Client.Services;

public class TipoCentrroServicio(HttpClient _http) : ITipoCentroService
{
    public async Task<ApiResponse<TipoCentroResponseDto>> CreateTipoCentroAsync(TipoCentroRegistroDto request)
    {
        var response = await _http.PostAsJsonAsync("center-types", request);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<TipoCentroResponseDto>();
            return new ApiResponse<TipoCentroResponseDto>
            {
                Success = true,
                Data = data
            };
        }
        // ❌ leer error backend
        var error = await Helper.LeerErrorAsync(response);
        return new ApiResponse<TipoCentroResponseDto>
        {
            Success = false,
            ErrorMessage = error
        };
        //if (!response.IsSuccessStatusCode)
        //{
        //    // Leer errores de validación (FluentValidation)
        //    var error = await response.Content
        //    .ReadFromJsonAsync<ApiValidationError>();
        //    var mensajes = error?.Errors?
        //        .SelectMany(e => e.Value)
        //        .ToList() ?? ["Error de validación desconocido."];
        //    throw new ApplicationException(string.Join(" | ", mensajes));
        //}

        // response.EnsureSuccessStatusCode();

        //return await response.Content.ReadFromJsonAsync<TipoCentroResponseDto>();
    }
    //
    public async Task<ApiResponse<TipoCentroResponseDto>> UpdateTipoCentroAsync(int id, TipoCentroRegistroDto request)
    {
        var response = await _http.PutAsJsonAsync($"center-types/{id}", request);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<TipoCentroResponseDto>();
            return new ApiResponse<TipoCentroResponseDto>
            {
                Success = true,
                Data = data
            };
        }

        // ❌ error
        var error = await Helper.LeerErrorAsync(response);

        return new ApiResponse<TipoCentroResponseDto>
        {
            Success = false,
            ErrorMessage = error
        };
    }
    public Task<IEnumerable<TipoCentroResponseDto>> GetAllTipoCentroAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TipoCentroResponseDto> GetTipoCentroByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedResultDto<TipoCentroResponseDto>> GetTipoCentroPaged(ListedPagedDto paginacion)
    {
        var url = $"center-types/paged?page={paginacion.Page}&pageSize={paginacion.PageSize}";
        //Console.WriteLine(url);
        if (!string.IsNullOrWhiteSpace(paginacion.Search))
            url += $"&search={Uri.EscapeDataString(paginacion.Search)}";// Asegúrate de escapar el término de búsqueda para evitar problemas con caracteres especiales

        if (!string.IsNullOrWhiteSpace(paginacion.SortBy))
            url += $"&sortBy={paginacion.SortBy}&sortDesc={paginacion.SortDesc.ToString().ToLower()}";

        var response = await _http.GetAsync(url);
        if (response.IsSuccessStatusCode)
        { 
            var data = await response.Content.ReadFromJsonAsync<PaginatedResultDto<TipoCentroResponseDto>>();
            return data ?? new PaginatedResultDto<TipoCentroResponseDto>(
                Items: [],
                Page: paginacion.Page,
                PageSize: paginacion.PageSize,
                TotalCount: 0,
                Success:true,
                ErrorMessage:"");
        }
        // ❌ leer error backend
        var error = await Helper.LeerErrorAsync(response);
        return new PaginatedResultDto<TipoCentroResponseDto>(
            Items: [],
            TotalCount: 0,
            Page: 0,
            PageSize: 0,
            Success: false,
            ErrorMessage: error
        );

    }

    public async Task<ApiResponse<bool>> ToggleTipoCentroAsync(int id)
    {
        var response = await _http.PatchAsync($"center-types/{id}/toggle-status", content: null);
        if (response.IsSuccessStatusCode)
        {
            //var data = await response.Content.ReadFromJsonAsync<bool>();
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
    }

    
}
