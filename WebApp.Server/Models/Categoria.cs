using System;
using System.Collections.Generic;

namespace WebApp.Server.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<ActivoFijo> ActivoFijos { get; set; } = new List<ActivoFijo>();
}
