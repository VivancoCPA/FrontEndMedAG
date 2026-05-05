namespace MedicalCareR1.Client.Utilities;
public record ApiValidationError(
    string? Title,
    int? Status,
    Dictionary<string, string[]>? Errors
);
