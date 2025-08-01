using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaboratorioRazor.Pages;

public class EmprestimoModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public List<Emprestimo> Emprestimos { get; set; } = new(); // Inicialize a lista

    public EmprestimoModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("ApiClient");
        
        // Faz a chamada para o endpoint /api/emprestimo da sua API
        var response = await httpClient.GetAsync("/emprestimo");

        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            Emprestimos = await JsonSerializer.DeserializeAsync<List<Emprestimo>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}