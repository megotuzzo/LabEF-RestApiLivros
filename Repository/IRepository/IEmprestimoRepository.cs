public interface IEmprestimoRepository
{
    void Add(Emprestimo newEmprestimo);
    void Update(int id, Emprestimo updatedEmprestimo);
    Emprestimo GetActiveEmprestimo(int idLivro);
}