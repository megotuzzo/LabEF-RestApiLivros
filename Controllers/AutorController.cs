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
    public IActionResult Add(Autor newAutor)
    {
        if (newAutor == null)
        {
            return BadRequest("Autor cannot be null");
        }

        _autorRepository.Add(newAutor);
        return CreatedAtAction(nameof(GetById), new { id = newAutor.Id }, newAutor);
    }

    [HttpPost("{id}")]
    public IActionResult Update(int id, Autor updatedAutor)
    {
        if (updatedAutor == null)
        {
            return BadRequest("Autor cannot be null");
        }

        if (id != updatedAutor.Id)
        {
            return BadRequest("ID mismatch");
        }

        _autorRepository.Update(id, updatedAutor);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sucesso = _autorRepository.Delete(id);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var autor = _autorRepository.GetById(id);
        if (autor == null)
        {
            return NotFound($"Author with ID {id} not found");
        }
        return Ok(autor);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var autores = _autorRepository.GetAll();
        if (autores == null || !autores.Any())
        {
            return NotFound("No authors found");
        }
        return Ok(autores);
    }


    [HttpGet("sobrenome/{lastName}")]
    public IActionResult GetAutoresByLastName(string lastName)
    {
        var autores = _autorRepository.GetAutoresByLastName(lastName);
        if (autores == null || !autores.Any())
        {
            return NotFound($"No authors found with last name {lastName}");
        }
        return Ok(autores);
    }
}