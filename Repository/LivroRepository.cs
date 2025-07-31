using LaboratorioRestApi.Repository.IRepository;

namespace LaboratorioRestApi.Repository;

public class LivroRepository : ILivroRepository
{
    private readonly AppDbContext _context;

    public LivroRepository(AppDbContext context)
    {
        _context = context;
    }
    public Livro Add(Livro newLivro)
    {
        _context.Livros.Add(newLivro);
        _context.SaveChanges();

        return newLivro;
    }

    public bool Delete(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return false;
        }
        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return true;
    }

    public bool Update(int id, Livro updatedLivro)
    {
        var existingLivro = _context.Livros.Find(id);
        if (existingLivro == null)
        {
            return false;
        }
        existingLivro.Titulo = updatedLivro.Titulo;
        existingLivro.AutorId = updatedLivro.AutorId;

        _context.SaveChanges();
        return true;
    }

    public List<Livro> GetAll()
    {
        return _context.Livros.ToList();
    }

    public Livro GetById(int id)
    {
        return _context.Livros.Find(id);
    }

    public List<Livro> GetLivroByAutor(int idAutor)
    {
        return _context.Livros.Where(l => l.AutorId == idAutor).ToList();
    }
}