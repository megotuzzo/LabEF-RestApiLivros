using System.Threading.Tasks;
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
    public async Task<IActionResult> Create(Livro newLivro)
    {
        if (newLivro == null)
        {
            return BadRequest("Livro cannot be null");
        }

        var livro = await _livroRepository.CreateAsync(newLivro);
        return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update (int id, Livro updatedLivro)
    {
        if (id != updatedLivro.Id)
        {
            return BadRequest("ID mismatch");
        }

        var sucesso = await _livroRepository.UpdateAsync(id, updatedLivro);
        if (!sucesso)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _livroRepository.DeleteAsync(id);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var livro = await _livroRepository.GetByIdAsync(id);
        if (livro == null)
        {
            return NotFound();
        }
        return Ok(livro);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var livros = await _livroRepository.GetAllAsync();
        return Ok(livros);
    }

    [HttpGet("autor/{idAutor}")]
    public async Task<IActionResult> GetLivroByAutor(int idAutor)
    {
        var livros = await _livroRepository.GetLivroByAutorAsync(idAutor);
        return Ok(livros);
    }
}