namespace LaboratorioRestApi.Repository.IRepository;

public interface IAutorRepository : IGenericRepository<Autor>
{
    Task<List<Autor>> GetAutoresByLastNameAsync(string lastName);
}