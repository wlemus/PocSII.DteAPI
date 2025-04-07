using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class CiudadEntity
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public Guid PaisId { get; set; }

    public virtual ICollection<EmpresaEntity> Empresas { get; set; } = new List<EmpresaEntity>();

    public virtual PaisEntity Pais { get; set; } = null!;
}
