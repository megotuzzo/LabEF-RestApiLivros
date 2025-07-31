public interface ILivroRepository
{
    void Add(Livro newLivro);
    List<Livro> GetAllLivros();
    List<Livro> GetLivroByAutor(int idAutor);
}