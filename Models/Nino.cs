using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class Nino
{
    public int PkIdNino { get; set; }

    public int Niup { get; set; }

    public string TipoSangre { get; set; } = null!;

    public string CiudadNacimiento { get; set; } = null!;

    public int FkIdEps { get; set; }

    public int FkIdJardin { get; set; }

    public int FkIdUsuario { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<AvancesAcademico> AvancesAcademicos { get; set; } = new List<AvancesAcademico>();

    public virtual Ep FkIdEpsNavigation { get; set; } = null!;

    public virtual Jardine FkIdJardinNavigation { get; set; } = null!;

    public virtual Usuario FkIdUsuarioNavigation { get; set; } = null!;
}
