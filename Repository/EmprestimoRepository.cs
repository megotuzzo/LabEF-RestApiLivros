using LaboratorioRestApi.Repository.IRepository;

namespace LaboratorioRestApi.Repository;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly AppDbContext _context;
    public EmprestimoRepository(AppDbContext context) {
       _context = context;
    }
    public Emprestimo Add(Emprestimo newEmprestimo)
    {
        _context.Emprestimos.Add(newEmprestimo);
        _context.SaveChanges();

        return newEmprestimo;
    }

    public bool Update(int id, Emprestimo updatedEmprestimo)
    {
        var existingEmprestimo = _context.Emprestimos.Find(id);
        if (existingEmprestimo == null)
        {
            return false;
        }

        existingEmprestimo.DataDevolucao = updatedEmprestimo.DataDevolucao;
        existingEmprestimo.DataRetirada = updatedEmprestimo.DataRetirada;
        existingEmprestimo.Entregue = updatedEmprestimo.Entregue;

        _context.SaveChanges();

        return true;
    }
    public bool Delete(int id)
    {
        var emprestimo = _context.Emprestimos.Find(id);
        if (emprestimo == null)
        {
            return false;
        }

        _context.Emprestimos.Remove(emprestimo);
        _context.SaveChanges();

        return true;
    }

    public List<Emprestimo> GetAll()
    {
        return _context.Emprestimos.ToList();
    }

    public Emprestimo GetById(int id)
    {
        return _context.Emprestimos.Find(id);
    }

    public Emprestimo GetActiveEmprestimo(int idLivro)
    {
        var emprestimo = _context.Emprestimos.Where(e => e.LivroId == idLivro && e.Entregue == false).FirstOrDefault();
        return emprestimo;
    }
}