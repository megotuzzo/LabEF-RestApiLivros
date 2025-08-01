namespace LaboratorioRestApi.Repository.IRepository;

public interface ILivroRepository : IGenericRepository<Livro>
{
    Task<List<Livro>> GetLivroByAutorAsync(int idAutor);
}