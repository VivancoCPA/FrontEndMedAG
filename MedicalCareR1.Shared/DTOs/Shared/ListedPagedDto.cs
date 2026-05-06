
namespace MedicalCareR1.Shared.DTOs.Shared;

public record ListedPagedDto
(
int Page = 1,
int PageSize = 10,
string? Search = null,
string? SortBy = "name",      // columna de ordenamiento (default: name)
bool SortDesc = false // true = DESC, false = ASC;
    );

