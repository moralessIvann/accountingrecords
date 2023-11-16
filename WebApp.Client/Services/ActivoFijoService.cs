using Shared;
using Shared.DTOs;
using System;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace WebApp.Client.Services;

public class ActivoFijoService : IActivoFijoService
{
    private readonly HttpClient _http;

    public ActivoFijoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ActivoFijoDTO>> List()
    {
        var result = await _http.GetFromJsonAsync<ResponseAPI<List<ActivoFijoDTO>>>("api/activofijo/list");

        if (result!.IsSuccess)
            return result.Value!;
        else
            throw new Exception(result.Message);
    }

    public async Task<int> Save(ActivoFijoDTO activoFijo)
    {
        var result = await _http.PostAsJsonAsync("api/activofijo/save", activoFijo);
        var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        if (response!.IsSuccess)
            return response.Value!;
        else
            throw new Exception(response.Message);
    }
}
