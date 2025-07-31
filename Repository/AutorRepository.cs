using LaboratorioRestApi.Repository.IRepository;

namespace LaboratorioRestApi.Repository;
public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;

    public AutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public Autor Add(Autor newAutor)
    {
        _context.Autores.Add(newAutor);
        _context.SaveChanges();

        return newAutor;
    }

    public bool Update(int id, Autor updatedAutor)
    {
        var existingAutor = _context.Autores.Find(id);
        if (existingAutor == null)
        {
            return false;
        }

        existingAutor.PrimeiroNome = updatedAutor.PrimeiroNome;
        existingAutor.UltimoNome = updatedAutor.UltimoNome;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var autor = _context.Autores.Find(id);
        if (autor is null)
        {
            return false;
        }

        _context.Autores.Remove(autor);
        _context.SaveChanges();

        return true;
    }

    public List<Autor> GetAll()
    {
        return _context.Autores.ToList();
    }

    public Autor GetById(int id)
    {
        var autor = _context.Autores.Find(id);
        return autor;
    }

    public List<Autor> GetAutoresByLastName(String lastName)
    {
        var lastNameFormat = lastName.ToLower();
        return _context.Autores.Where(a => a.UltimoNome == lastNameFormat).ToList();
    }
}