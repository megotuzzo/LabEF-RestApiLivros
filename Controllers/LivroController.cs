using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroRepository _livroRepository;

    public LivroController(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;

    }

    [HttpGet]
    public IActionResult GetAllLivros()
    {
        var livros = _livroRepository.GetAllLivros();
        return Ok(livros);
    }

    [HttpPost]
    public IActionResult Add(Livro newLivro)
    {
        if (newLivro == null)
        {
            return BadRequest("Livro cannot be null");
        }

        _livroRepository.Add(newLivro);
        return CreatedAtAction(nameof(Add), new { id = newLivro.Id }, newLivro);
    }

    [HttpGet("/autor/{idAutor}")]
    public IActionResult GetLivroByAutor(int idAutor)
    {
        var livros = _livroRepository.GetLivroByAutor(idAutor);
        if (livros == null || !livros.Any())
        {
            return NotFound($"No books found for author with ID {idAutor}");
        }
        return Ok(livros);
    }
}