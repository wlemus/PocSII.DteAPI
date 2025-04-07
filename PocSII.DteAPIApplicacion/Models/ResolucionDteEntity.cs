using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class ResolucionDteEntity
{
    public Guid Id { get; set; }

    public int Numero { get; set; }

    public DateOnly Fecha { get; set; }

    public Guid? SucursalId { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<RangoFolioEntity> RangoFolios { get; set; } = new List<RangoFolioEntity>();

    public virtual SucursalEntity? Sucursal { get; set; }
}
