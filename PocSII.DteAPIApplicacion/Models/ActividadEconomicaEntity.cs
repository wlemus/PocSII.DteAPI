using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class ActividadEconomicaEntity
{
    public Guid Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Categoria { get; set; }

    public virtual ICollection<EmpresaActecoEntity> EmpresaActecos { get; set; } = new List<EmpresaActecoEntity>();
}
