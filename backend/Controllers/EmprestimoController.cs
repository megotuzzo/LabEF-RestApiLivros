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
    public async Task<IActionResult> Create (Emprestimo newEmprestimo)
    {
        if (newEmprestimo == null)
        {
            return BadRequest("Emprestimo cannot be null");
        }

        var emprestimo = await _emprestimoRepository.CreateAsync(newEmprestimo);
        return CreatedAtAction(nameof(GetById), new { id = emprestimo.Id }, emprestimo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Emprestimo updatedEmprestimo)
    {
        if (id != updatedEmprestimo.Id)
        {
            return BadRequest("ID mismatch");
        }

        var sucesso = await _emprestimoRepository.UpdateAsync(id, updatedEmprestimo);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
       var sucesso = await _emprestimoRepository.DeleteAsync(id);
        if (!sucesso)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var emprestimo = await _emprestimoRepository.GetByIdDTOAsync(id);
        if (emprestimo == null)
        {
            return NotFound();
        }
        return Ok(emprestimo);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emprestimos = await _emprestimoRepository.GetAllDTOAsync();
        return Ok(emprestimos);
    }

    [HttpGet("livro/{idLivro}")] 
    public async Task<IActionResult> GetActiveEmprestimo(int idLivro)
    {
        var emprestimo = await _emprestimoRepository.GetActiveEmprestimoAsync(idLivro);
        return Ok(emprestimo);
    }
}
