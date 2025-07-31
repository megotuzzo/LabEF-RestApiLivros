public class AutorRepository : IAutorRepository
{
    private List<Autor> _listAutores;

    public AutorRepository()
    {
        _listAutores = new List<Autor>();
    }

    public void Add(Autor newAutor)
    {
        if (newAutor == null)
        {
            return;
        }

        _listAutores.Add(newAutor);
    }

    public void Update(int id, Autor updateAutor)
    {
        var autor = _listAutores.FirstOrDefault(a => a.Id == id);

        if (autor == null)
        {
            return;
        }

        _listAutores.Remove(autor);
        _listAutores.Add(updateAutor);
    }

    public List<Autor> GetAutoresByLastName(String lastName)
    {
        var lastNameformat = lastName.ToLower();
        return _listAutores.FindAll(a => a.UltimoNome == lastNameformat);
    }

}