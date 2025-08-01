using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository;

public class EmprestimoRepository : GenericRepository<Emprestimo>, IEmprestimoRepository
{
    public EmprestimoRepository(AppDbContext context) : base(context)
    {
       
    }

    public async Task<Emprestimo?> GetActiveEmprestimoAsync (int idLivro)
    {
        return await _context.Emprestimos.Where(e => e.LivroId == idLivro && !e.Entregue).FirstOrDefaultAsync();
    }
}