using System.Threading.Tasks;
using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository;

public class LivroRepository : GenericRepository<Livro>, ILivroRepository
{
    public LivroRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<List<Livro>> GetLivroByAutorAsync(int idAutor)
    {
        return await _context.Livros.Where(l => l.AutorId == idAutor).ToListAsync();
    }
    
    public async Task<List<LivroDTO>> GetAllDTOAsync()
    {
        return await _context.Livros
            .Include(livro => livro.Autor) // 1. Use Include para trazer os dados do autor na consulta
            .Select(livro => new LivroDTO // 2. Use Select para transformar o resultado no DTO
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                AutorId = livro.AutorId,
                AutorNome = $"{livro.Autor.PrimeiroNome} {livro.Autor.UltimoNome}"
            })
            .ToListAsync();
    }

    public async Task<LivroDTO?> GetByIdDTOAsync(int id)
    {
        return await _context.Livros
            .Where(livro => livro.Id == id)
            .Include(livro => livro.Autor) // 1. Use Include para trazer os dados do autor na consulta
            .Select(livro => new LivroDTO // 2. Use Select para transformar o resultado no DTO
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                AutorId = livro.AutorId,
                AutorNome = $"{livro.Autor.PrimeiroNome} {livro.Autor.UltimoNome}"
            })
            .FirstOrDefaultAsync(); // Retorna o DTO ou null se o autor não for encontrado
    }
}