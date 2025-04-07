using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class TipoDocumentoEntity
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<RangoFolioEntity> RangoFolios { get; set; } = new List<RangoFolioEntity>();
}
