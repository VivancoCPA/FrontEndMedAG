namespace MedicalCareR1.Shared.DTOs.Catalogos;

public class CatalogoField
{
    public string Property { get; set; } = default!;
    public string Label { get; set; } = default!;
    public string Type { get; set; } = "text"; // text, select, switch
    public bool Editable { get; set; } = true;
}
