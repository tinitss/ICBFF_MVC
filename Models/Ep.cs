using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class Ep
{
    public int PkIdEps { get; set; }

    public int Nit { get; set; }

    public string Nombre { get; set; } = null!;

    public string CentroMedico { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Telefono { get; set; }

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
