namespace LaboratorioRestApi.Repository.IRepository;

public interface IEmprestimoRepository : IGenericRepository<Emprestimo>
{
    Task<Emprestimo?> GetActiveEmprestimoAsync (int idLivro);
}