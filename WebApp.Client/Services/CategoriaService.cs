using Shared;
using Shared.DTOs;
using System.Net.Http.Json;

namespace WebApp.Client.Services;

public class CategoriaService : ICategoriaService
{
    private readonly HttpClient _http;

    public CategoriaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<CategoriaDTO>> List()
    {
        var result = await _http.GetFromJsonAsync<ResponseAPI<List<CategoriaDTO>>>("api/categoria/list");

        if(result!.IsSuccess) 
            return result.Value!;
        else
            throw new Exception(result.Message);
    }

    public async Task<int> Save(CategoriaDTO categoria)
    {
        var result = await _http.PostAsJsonAsync("api/categoria/save", categoria);
        var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        if (response!.IsSuccess)
            return response.Value!;
        else
            throw new Exception(response.Message);
    }
}
