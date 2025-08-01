using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository;

public class EmprestimoRepository : GenericRepository<Emprestimo>, IEmprestimoRepository
{
    public EmprestimoRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<Emprestimo?> GetActiveEmprestimoAsync(int idLivro)
    {
        return await _context.Emprestimos.Where(e => e.LivroId == idLivro && !e.Entregue).FirstOrDefaultAsync();
    }

    public async Task<List<EmprestimoDTO>> GetAllDTOAsync()
    {
        return await _context.Emprestimos
            .Include(emprestimo => emprestimo.Livro) // 1. Carrega o objeto Livro associado
            .Select(emprestimo => new EmprestimoDTO // 2. Transforma no DTO
            {
                Id = emprestimo.Id,
                DataRetirada = emprestimo.DataRetirada,
                DataDevolucao = emprestimo.DataDevolucao,
                Entregue = emprestimo.Entregue,
                LivroId = emprestimo.LivroId,
                // 3. Pega o título do objeto Livro que foi incluído
                LivroNome = emprestimo.Livro!.Titulo
            })
            .ToListAsync();
    }

    public async Task<EmprestimoDTO?> GetByIdDTOAsync(int id)
    {
        return await _context.Emprestimos
            .Where(emprestimo => emprestimo.Id == id)
            .Include(emprestimo => emprestimo.Livro) // 1. Carrega o objeto Livro associado
            .Select(emprestimo => new EmprestimoDTO // 2. Transforma no DTO
            {
                Id = emprestimo.Id,
                DataRetirada = emprestimo.DataRetirada,
                DataDevolucao = emprestimo.DataDevolucao,
                Entregue = emprestimo.Entregue,
                LivroId = emprestimo.LivroId,
                // 3. Pega o título do objeto Livro que foi incluído
                LivroNome = emprestimo.Livro!.Titulo
            })
            .FirstOrDefaultAsync(); // Retorna o DTO ou null se o autor não for encontrado
    }
}