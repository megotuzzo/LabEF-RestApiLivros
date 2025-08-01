using System.Threading.Tasks;
using LaboratorioRestApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorRepository _autorRepository;

    public AutorController(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Autor newAutor)
    {
        if (newAutor == null)
        {
            return BadRequest("Autor cannot be null");
        }

        var autor = await _autorRepository.CreateAsync(newAutor);
        return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Autor updatedAutor)
    {
        if (id != updatedAutor.Id)
        {
            return BadRequest("ID mismatch");
        }

        var sucesso = await _autorRepository.UpdateAsync(id, updatedAutor);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _autorRepository.DeleteAsync(id);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _autorRepository.GetByIdDTOAsync(id);
        if (autor == null)
        {
            return NotFound();
        }
        return Ok(autor);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _autorRepository.GetAllDTOAsync();
        return Ok(autores);
    }


    [HttpGet("sobrenome/{lastName}")]
    public async Task<IActionResult> GetAutoresByLastName(string lastName)
    {
        var autores = await _autorRepository.GetAutoresByLastNameAsync(lastName);
        return Ok(autores);
    }
}