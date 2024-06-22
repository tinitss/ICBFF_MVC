using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class Usuario
{
    public int PkIdUsuario { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int FkIdRol { get; set; }

    public int FkIdTipoDoc { get; set; }

    public virtual Role FkIdRolNavigation { get; set; } = null!;

    public virtual TipoDoc FkIdTipoDocNavigation { get; set; } = null!;

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
