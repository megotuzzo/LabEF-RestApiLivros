using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorRepository _autorRepository;

    public AutorController(IAutorRepository _autorRepository)
    {
        _autorRepository = _autorRepository;
    }

    [HttpPost]
    public IActionResult Add(Autor newAutor)
    {
        if (newAutor == null)
        {
            return BadRequest("Livro cannot be null");
        }

        _autorRepository.Add(newAutor);
        return CreatedAtAction(nameof(Add), new { id = newAutor.Id }, newAutor);
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

    [HttpGet("/{lastName}")]
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