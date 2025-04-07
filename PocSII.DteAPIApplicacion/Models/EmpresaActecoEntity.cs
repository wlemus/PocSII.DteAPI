using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class EmpresaActecoEntity
{
    public int Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid ActecoId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool Activo { get; set; }

    public virtual ActividadEconomicaEntity Acteco { get; set; } = null!;

    public virtual EmpresaEntity Empresa { get; set; } = null!;
}
