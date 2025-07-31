using LaboratorioRestApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers;

[ApiController]
[Route("[controller]")]
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
        return CreatedAtAction(nameof(GetById), new { id = newEmprestimo.Id }, newEmprestimo);
    }

    [HttpPost("{id}")]
    public IActionResult Update(int id, Emprestimo updatedEmprestimo)
    {
        if (updatedEmprestimo == null)
        {
            return BadRequest("Emprestimo cannot be null");
        }
        if (id != updatedEmprestimo.Id)
        {
            return BadRequest("ID mismatch");
        }

        _emprestimoRepository.Update(id, updatedEmprestimo);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
       var sucesso = _emprestimoRepository.Delete(id);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var emprestimo = _emprestimoRepository.GetById(id);
        if (emprestimo == null)
        {
            return NotFound($"Emprestimo with ID {id} not found");
        }
        return Ok(emprestimo);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var emprestimos = _emprestimoRepository.GetAll();
        if (emprestimos == null || !emprestimos.Any())
        {
            return NotFound("No emprestimos found");
        }
        return Ok(emprestimos);
    }

    [HttpGet("livro/{idLivro}")] 
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
