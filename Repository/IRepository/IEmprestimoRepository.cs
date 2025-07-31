namespace LaboratorioRestApi.Repository.IRepository;

public interface IEmprestimoRepository
{
    Emprestimo Add(Emprestimo newEmprestimo);
    bool Update(int id, Emprestimo updatedEmprestimo);
    bool Delete(int id);
    List<Emprestimo> GetAll();
    Emprestimo GetById(int id);
    Emprestimo GetActiveEmprestimo(int idLivro);
}