using System;
using System.Collections.Generic;

namespace PocSII.DteAPIApplicacion.Models;

public partial class PaisEntity {
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Iso { get; set; } = null!;

    public virtual ICollection<CiudadEntity> Ciudades { get; set; } = new List<CiudadEntity>();
}
