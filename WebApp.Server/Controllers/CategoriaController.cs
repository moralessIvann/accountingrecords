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
public class CategoriaController : ControllerBase
{
    private readonly RsiProjectContext _context;

    public CategoriaController(RsiProjectContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> List()
    {
        var listCategoriaDTO = new List<CategoriaDTO>();
        var responseAPI = new ResponseAPI<List<CategoriaDTO>>();

        try
        {
            foreach (var item in await _context.Categoria.ToListAsync())
            {
                listCategoriaDTO.Add(new CategoriaDTO
                {
                    IdCategoria = item.IdCategoria,
                    NombreCategoria = item.NombreCategoria,
                });
            }

            responseAPI.statusCode = HttpStatusCode.OK;
            responseAPI.IsSuccess = true;
            responseAPI.Value = listCategoriaDTO;

        }catch (Exception ex)
        {
            responseAPI.statusCode = HttpStatusCode.InternalServerError;
            responseAPI.IsSuccess = false;
            responseAPI.Message = ex.Message;
        }

        return Ok(responseAPI);
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> Save(CategoriaDTO categoria)
    {
        var responseAPI = new ResponseAPI<int>();

        try
        {
            var categoriaModel = new Categoria
            {
                NombreCategoria = categoria.NombreCategoria,
            };

            _context.Categoria.Add(categoriaModel);
            await _context.SaveChangesAsync();

            if (categoriaModel.IdCategoria != 0)
            {
                responseAPI.statusCode = HttpStatusCode.OK;
                responseAPI.IsSuccess = true;
                responseAPI.Value = categoriaModel.IdCategoria;
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
}
