using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class SucursalEntity {
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public string CodigoSiisucursal { get; set; } = null!;

    public string? NombreSucursal { get; set; }

    public string? Direccion { get; set; }

    public string? Comuna { get; set; }

    public Guid? CiudadId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool Activo { get; set; }

    public virtual EmpresaEntity Empresa { get; set; } = null!;

    public virtual ICollection<ResolucionDteEntity> ResolucionDtes { get; set; } = new List<ResolucionDteEntity>();
}
