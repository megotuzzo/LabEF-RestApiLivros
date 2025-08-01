using System.Threading.Tasks;
using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository;

public class LivroRepository : GenericRepository<Livro>, ILivroRepository
{

    public LivroRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<List<Livro>> GetLivroByAutorAsync (int idAutor)
    {
        return await _context.Livros.Where(l => l.AutorId == idAutor).ToListAsync();
    }
}