namespace LaboratorioRestApi.Repository.IRepository;

public interface ILivroRepository
{
    Livro Add(Livro newLivro);
    bool Update(int id, Livro updatedLivro);
    bool Delete(int id);
    List<Livro> GetAll();
    Livro GetById(int id);
    List<Livro> GetLivroByAutor(int idAutor);
}