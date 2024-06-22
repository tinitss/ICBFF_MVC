using System;
using System.Collections.Generic;

namespace ICBF_3.Models;

public partial class AvancesAcademico
{
    public int PkIdAvance { get; set; }

    public DateOnly FechaNota { get; set; }

    public string Descripcion { get; set; } = null!;

    public string AnoEscolar { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public string Notas { get; set; } = null!;

    public int FkIdNino { get; set; }

    public virtual Nino FkIdNinoNavigation { get; set; } = null!;
}
