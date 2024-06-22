using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class Asistencia
{
    public int PkIdAsistencia { get; set; }

    public DateOnly Fecha { get; set; }

    public string DescripcionEstado { get; set; } = null!;

    public int FkIdNino { get; set; }

    public virtual Nino FkIdNinoNavigation { get; set; } = null!;
}
