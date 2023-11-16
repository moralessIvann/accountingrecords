using Shared.DTOs;

namespace WebApp.Client.Services;

public interface IActivoFijoService
{
    Task<List<ActivoFijoDTO>> List();

    Task<int> Save(ActivoFijoDTO activoFijo);
}
