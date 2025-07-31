
public class LivroRepository : ILivroRepository
{
    private List<Livro> _listLivros;

    public LivroRepository() {
        _listLivros = new List<Livro>();
    }
    public void Add(Livro newLivro)
    {
        if (newLivro == null)
        {
            return;
        }

        _listLivros.Add(newLivro);
    }

    public List<Livro> GetAllLivros()
    {
        return _listLivros;
    }

    public List<Livro> GetLivroByAutor(int idAutor)
    {
        return _listLivros.Where(l => l.AutorId == idAutor).ToList();
    }
}