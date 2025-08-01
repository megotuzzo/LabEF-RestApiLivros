using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository;
public class AutorRepository : GenericRepository<Autor>, IAutorRepository
{
    public AutorRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<List<Autor>> GetAutoresByLastNameAsync (String lastName)
    {
        return await _context.Autores.Where(a => a.UltimoNome.ToLower() == lastName.ToLower()).ToListAsync();
    }
}