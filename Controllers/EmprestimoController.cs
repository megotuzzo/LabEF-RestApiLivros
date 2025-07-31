using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoRepository _emprestimoRepository;

    public EmprestimoController(IEmprestimoRepository emprestimoRepository)
    {
        _emprestimoRepository = emprestimoRepository;
    }

    [HttpPost]
    public IActionResult Add(Emprestimo newEmprestimo)
    {
        if (newEmprestimo == null)
        {
            return BadRequest("Emprestimo cannot be null");
        }

        _emprestimoRepository.Add(newEmprestimo);
        return CreatedAtAction(nameof(Add), new { id = newEmprestimo.Id }, newEmprestimo);
    }

    [HttpPost]
    public IActionResult Update(int id, Emprestimo updatedEmprestimo)
    {
        if (updatedEmprestimo == null)
        {
            return BadRequest("Emprestimo cannot be null");
        }

        _emprestimoRepository.Update(id, updatedEmprestimo);
        return Ok();
    }

    [HttpGet] 
    public IActionResult GetActiveEmprestimo(int idLivro)
    {
        var emprestimo = _emprestimoRepository.GetActiveEmprestimo(idLivro);
        if (emprestimo == null)
        {
            return NotFound($"No active loan found for book with ID {idLivro}");
        }
        return Ok(emprestimo);
    }
}
