using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class TipoDoc
{
    public int PkIdTipoDoc { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
