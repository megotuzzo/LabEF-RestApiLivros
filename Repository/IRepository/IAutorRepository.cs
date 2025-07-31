namespace LaboratorioRestApi.Repository.IRepository;

public interface IAutorRepository
{
    Autor Add(Autor autor);
    bool Update(int id, Autor updatedAutor);
    bool Delete(int id);
    List<Autor> GetAll();
    Autor GetById(int id);
    List<Autor> GetAutoresByLastName(String lastName);

}