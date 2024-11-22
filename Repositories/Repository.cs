using Microsoft.EntityFrameworkCore;
using Taligado.Data;

namespace Taligado.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity) { _context.Add(entity); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(T entity) { _context.Update(entity); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
