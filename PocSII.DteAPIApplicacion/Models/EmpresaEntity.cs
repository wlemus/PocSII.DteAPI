using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class EmpresaEntity
{
    public Guid Id { get; set; }

    public string Rut { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string? Giro { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Direccion { get; set; }

    public string? Comuna { get; set; }

    public Guid? CiudadId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreadoPor { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }

    public bool Activo { get; set; }

    public virtual CiudadEntity? Ciudad { get; set; }

    public virtual ICollection<EmpresaActecoEntity> EmpresaActecos { get; set; } = new List<EmpresaActecoEntity>();

    public virtual ICollection<EmpresaTelefonoEntity> EmpresaTelefonos { get; set; } = new List<EmpresaTelefonoEntity>();

    public virtual ICollection<SucursalEntity> Sucursales { get; set; } = new List<SucursalEntity>();
}
