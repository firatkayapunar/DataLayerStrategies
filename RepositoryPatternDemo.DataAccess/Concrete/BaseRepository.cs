using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.DataAccess.Abstract;
using RepositoryPatternDemo.DataAccess.Context;

namespace RepositoryPatternDemo.DataAccess.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly MyAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MyAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
