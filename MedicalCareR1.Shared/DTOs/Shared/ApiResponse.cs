namespace MedicalCareR1.Shared.DTOs.Shared;

public class ApiResponse<T> 
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    Dictionary<string, string[]>? Errors = null; // Para errores de validación (400)

}
