using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaboratorioRazor.Pages;

public class LivroModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public List<LivroDTO> Livros { get; set; } = new(); // Inicialize a lista

    public LivroModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("ApiClient");
        
        // Faz a chamada para o endpoint /api/livro da sua API
        var response = await httpClient.GetAsync("/livro");

        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            Livros = await JsonSerializer.DeserializeAsync<List<LivroDTO>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}