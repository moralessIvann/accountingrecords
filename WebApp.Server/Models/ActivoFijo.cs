using System;
using System.Collections.Generic;

namespace WebApp.Server.Models;

public partial class ActivoFijo
{
    public int IdActivoFijo { get; set; }

    public string NombreActivoFijo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string NumeroSerie { get; set; } = null!;

    public decimal ValorAdquisicion { get; set; }

    public string? CodigoRsi { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int IdCategoria { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
}
