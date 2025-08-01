using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository;

public class AutorRepository : GenericRepository<Autor>, IAutorRepository
{
    public AutorRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<List<Autor>> GetAutoresByLastNameAsync(String lastName)
    {
        return await _context.Autores.Where(a => a.UltimoNome.ToLower() == lastName.ToLower()).ToListAsync();
    }

    public async Task<AutorDTO?> GetByIdDTOAsync(int id)
    {
        return await _context.Autores
            .Where(autor => autor.Id == id)
            .Include(autor => autor.Livros)     // 1. Carrega a lista de livros associada
            .Select(autor => new AutorDTO       // 2. Transforma o resultado no DTO
            {
                Id = autor.Id,
                PrimeiroNome = autor.PrimeiroNome,
                UltimoNome = autor.UltimoNome,
                LivrosNomes = autor.Livros.Select(livro => livro.Titulo).ToList()
            })
            .FirstOrDefaultAsync(); // Retorna o DTO ou null se o autor não for encontrado
    }

    public async Task<List<AutorDTO>> GetAllDTOAsync()
    {
        return await _context.Autores
            .Include(autor => autor.Livros)     // 1. Carrega a lista de livros associada
            .Select(autor => new AutorDTO       // 2. Transforma o resultado no DTO
            {
                Id = autor.Id,
                PrimeiroNome = autor.PrimeiroNome,
                UltimoNome = autor.UltimoNome,
                LivrosNomes = autor.Livros.Select(livro => livro.Titulo).ToList()
            })
            .ToListAsync();
    }
}