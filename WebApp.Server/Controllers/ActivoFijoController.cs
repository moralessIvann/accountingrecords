using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.DTOs;
using System.Net;
using WebApp.Server.DAL;
using WebApp.Server.Models;

namespace WebApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivoFijoController : ControllerBase
{
    private readonly RsiProjectContext _context;

    public ActivoFijoController(RsiProjectContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> List()
    {
        var listActivoFijoDTO = new List<ActivoFijoDTO>();
        var responseAPI = new ResponseAPI<List<ActivoFijoDTO>>();

        try
        {
            foreach (var item in await _context.ActivoFijos.Include(c => c.IdCategoriaNavigation).OrderByDescending(a => a.FechaCreacion).ToListAsync())
            {
                listActivoFijoDTO.Add(new ActivoFijoDTO
                {
                    IdActivoFijo = item.IdActivoFijo,
                    NombreActivoFijo = item.NombreActivoFijo,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    NumeroSerie = item.NumeroSerie,
                    ValorAdquisicion = item.ValorAdquisicion,
                    FechaCreacion = item.FechaCreacion,
                    CodigoRsi = item.CodigoRsi,
                    IdCategoria = item.IdCategoria,
                    Categoria = new CategoriaDTO()
                    {
                        IdCategoria = item.IdCategoriaNavigation.IdCategoria,
                        NombreCategoria = item.IdCategoriaNavigation.NombreCategoria
                    }
                });
            }

            responseAPI.statusCode = HttpStatusCode.OK;
            responseAPI.IsSuccess = true;
            responseAPI.Value = listActivoFijoDTO;

        }
        catch (Exception ex)
        {
            responseAPI.statusCode = HttpStatusCode.InternalServerError;
            responseAPI.IsSuccess = false;
            responseAPI.Message = ex.Message;
        }

        return Ok(responseAPI);
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> Save(ActivoFijoDTO activo)
    {
        var responseAPI = new ResponseAPI<int>();

        try
        {
            var activoFijo = new ActivoFijo
            {
                NombreActivoFijo = activo.NombreActivoFijo,
                Marca = activo.Marca,
                Modelo = activo.Modelo,
                NumeroSerie = activo.NumeroSerie,
                ValorAdquisicion = activo.ValorAdquisicion,
                FechaCreacion = activo.FechaCreacion,
                IdCategoria = activo.IdCategoria,
                CodigoRsi = activo.CodigoRsi,
            };

            // these lines creates RSI code
            string newCodigoRsi = GenerateCodigoRsi();
            activoFijo.CodigoRsi = newCodigoRsi;

            _context.ActivoFijos.Add(activoFijo);
            await _context.SaveChangesAsync();

            if (activoFijo.IdActivoFijo != 0)
            {
                responseAPI.statusCode = HttpStatusCode.OK;
                responseAPI.IsSuccess = true;
                responseAPI.Value = activoFijo.IdActivoFijo;
            }
            /*
            else
            {
                responseAPI.statusCode = HttpStatusCode.InternalServerError;
                responseAPI.IsSuccess = false;
                responseAPI.Message = "No guardado";
            }
            */
        }
        catch (Exception ex)
        {
            responseAPI.statusCode = HttpStatusCode.InternalServerError;
            responseAPI.IsSuccess = false;
            responseAPI.Message = ex.Message;
        }

        return Ok(responseAPI);
    }

    private string GenerateCodigoRsi()
    {
        Random random = new Random();
        string prefix = "RSI";
        string RSICode = prefix + random.Next(100000000, 999999999).ToString();

        while (_context.ActivoFijos.Any(a => a.CodigoRsi == RSICode))
        {
            RSICode = prefix + random.Next(100000000, 999999999).ToString();
        }

        return RSICode;
    }
}
