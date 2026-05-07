using System.ComponentModel.DataAnnotations;

namespace MedicalCareR1.Shared.Enums;
public enum CodeTable
{
    [Display(Name = "Especialidades")]
    ESPECIALIDAD,
    [Display(Name = "Aseguradoras")]
    ASEGURADORA,
    [Display(Name = "TipoCentroMedico")]
    TIPO_CENTRO,
}
