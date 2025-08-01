using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaboratorioRazor.Pages;

public class AutorModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public List<Autor> Autores { get; set; } = new(); // Inicialize a lista

    public AutorModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("ApiClient");
        
        // Faz a chamada para o endpoint /api/autor da sua API
        var response = await httpClient.GetAsync("/autor");

        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            Autores = await JsonSerializer.DeserializeAsync<List<Autor>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}