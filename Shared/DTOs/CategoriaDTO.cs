using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs;

public class CategoriaDTO
{
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "El campo {0} esta vacio.")]
    public string NombreCategoria { get; set; } = null!;
}
