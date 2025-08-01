using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Repository.IRepository;

public interface IGenericRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
}