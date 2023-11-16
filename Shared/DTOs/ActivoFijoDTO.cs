using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs;

public class ActivoFijoDTO
{
    public int IdActivoFijo { get; set; }

    [Required(ErrorMessage = "El campo {0} esta vacio.")]
    public string NombreActivoFijo { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} esta vacio.")]
    public string Marca { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} esta vacio.")]
    public string Modelo { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} esta vacio.")]
    public string NumeroSerie { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} esta vacio.")]
    public decimal ValorAdquisicion { get; set; }

    public string? CodigoRsi { get; set; }

    public DateTime FechaCreacion { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El campo {0} esta vacio.")]
    public int IdCategoria { get; set; }

    public CategoriaDTO? Categoria { get; set; }
}
