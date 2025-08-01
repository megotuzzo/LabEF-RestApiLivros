namespace LaboratorioRestApi.Repository.IRepository;

public interface IEmprestimoRepository : IGenericRepository<Emprestimo>
{
    Task<Emprestimo?> GetActiveEmprestimoAsync(int idLivro);

    Task<EmprestimoDTO?> GetByIdDTOAsync(int id);
    Task<List<EmprestimoDTO>> GetAllDTOAsync();
}