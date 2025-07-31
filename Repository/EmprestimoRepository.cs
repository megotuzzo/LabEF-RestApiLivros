public class EmprestimoRepository : IEmprestimoRepository
{
    private List<Emprestimo> _listEmprestimos;
    public EmprestimoRepository() {
        _listEmprestimos = new List<Emprestimo>();
    }
    public void Add(Emprestimo newEmprestimo)
    {
        if (newEmprestimo == null)
        {
            return;
        }

        _listEmprestimos.Add(newEmprestimo);
    }

    public Emprestimo GetActiveEmprestimo(int idLivro)
    {
        var emprestimo = _listEmprestimos.Where(e => e.LivroId == idLivro && e.Entregue == false).FirstOrDefault();
        return emprestimo;
    }

    public void Update(int id, Emprestimo updatedEmprestimo)
    {
        var emprestimo = _listEmprestimos.FirstOrDefault(e => e.Id == id);

        if (emprestimo == null)
        {
            return;
        }

        _listEmprestimos.Remove(emprestimo);
        _listEmprestimos.Add(updatedEmprestimo);
    }
}