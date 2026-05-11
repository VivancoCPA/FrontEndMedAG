using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace MedicalCareR1.Shared.DTOs.Aseguradoras;

public class AseguradoraRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PersonInCharge { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime createdAt { get; set; } 
}
