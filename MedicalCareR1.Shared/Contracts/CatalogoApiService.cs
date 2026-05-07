// Client/Services/CatalogoApiService.cs
using System.Dynamic;
using System.Net.Http.Json;
using MedicalCareR1.Shared.Contracts;

namespace MedicalCareR1.Client.Services;

public class CatalogoApiService : ICatalogoService
{
    private readonly HttpClient _http;
    public CatalogoApiService(HttpClient http)
    {
        _http = http;
        Console.WriteLine($"=== CatalogoApiService BaseAddress: {_http.BaseAddress}");
    }
    public async Task<List<Dictionary<string, object?>>> GetAllAsync(string endpoint)
    {
        try
        {
            var result = await _http
                .GetFromJsonAsync<List<Dictionary<string, object?>>>(endpoint);
            return result ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"=== Error GetAllAsync [{endpoint}]: {ex.Message}");
            return new();
        }
    }

    public async Task<bool> CreateAsync(string endpoint, Dictionary<string, object?> data)
    {
        var response = await _http.PostAsJsonAsync(endpoint, data);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(string endpoint, Guid id, Dictionary<string, object?> data)
    {
        var response = await _http.PutAsJsonAsync($"{endpoint}/{id}", data);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string endpoint, Guid id)
    {
        var response = await _http.DeleteAsync($"{endpoint}/{id}");
        return response.IsSuccessStatusCode;
    }

    public Task<List<ExpandoObject>> GetAll(string endpoint)
    {
        throw new NotImplementedException();
    }

    public Task Save(string endpoint, object item)
    {
        throw new NotImplementedException();
    }

    public Task Deactivate(string endpoint, object item)
    {
        throw new NotImplementedException();
    }
}