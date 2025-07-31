using LaboratorioRestApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroRepository _livroRepository;

    public LivroController(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;

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

    [HttpPost("{id}")]
    public IActionResult Update(int id, Livro updatedLivro)
    {
        if (updatedLivro == null)
        {
            return BadRequest("Livro cannot be null");
        }

        if (id != updatedLivro.Id)
        {
            return BadRequest("ID mismatch");
        }
        _livroRepository.Update(id, updatedLivro);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sucesso = _livroRepository.Delete(id);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var livro = _livroRepository.GetById(id);
        if (livro == null)
        {
            return NotFound($"Livro with ID {id} not found");
        }
        return Ok(livro);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var livros = _livroRepository.GetAll();
        return Ok(livros);
    }

    [HttpGet("autor/{idAutor}")]
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