using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class Jardine
{
    public int PkIdJardin { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
