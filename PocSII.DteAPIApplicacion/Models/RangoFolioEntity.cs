using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class RangoFolioEntity
{
    public Guid Id { get; set; }

    public Guid ResolucionId { get; set; }

    public string TipoDocumentoCodigo { get; set; } = null!;

    public int FolioDesde { get; set; }

    public int FolioHasta { get; set; }

    public DateOnly FechaAutorizacion { get; set; }

    public bool Vigente { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool Activo { get; set; }

    public virtual ResolucionDteEntity Resolucion { get; set; } = null!;

    public virtual TipoDocumentoEntity TipoDocumentoCodigoNavigation { get; set; } = null!;
}
