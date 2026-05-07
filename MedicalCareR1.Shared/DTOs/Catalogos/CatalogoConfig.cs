namespace MedicalCareR1.Shared.DTOs.Catalogos;
public class CatalogoConfig
{
    public string CodeTable { get; set; } = default!;
    public string Nombre { get; set; } = default!;
    public string Endpoint { get; set; } = default!;
    
    //public List<CatalogoField> Fields { get; set; } = new();
}

