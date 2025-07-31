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

    [HttpPost]
    public IActionResult Update(int id, Autor updateAutor)
    {
        if (updateAutor == null)
        {
            return BadRequest("Autor cannot be null");
        }

        _autorRepository.Update(id, updateAutor);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var autor = _autorRepository.GetById(id);
        if (autor == null)
        {
            return NotFound($"Author with ID {id} not found");
        }

        _autorRepository.Delete(id);
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


    [HttpGet("{lastName}")]
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