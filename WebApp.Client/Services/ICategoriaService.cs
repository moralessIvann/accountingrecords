using Shared.DTOs;

namespace WebApp.Client.Services;

public interface ICategoriaService
{
    Task<List<CategoriaDTO>> List();

    Task<int> Save(CategoriaDTO categoria);
}
