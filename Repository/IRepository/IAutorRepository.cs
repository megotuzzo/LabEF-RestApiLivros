public interface IAutorRepository
{
    List<Autor> GetAutoresByLastName(String lastName);
    void Add(Autor autor);
    void Update(int id, Autor updatedAutor);

}