using AklniResturant.Data;
using AklniResturant.Interfaces;
using AklniResturant.Models;
using Microsoft.EntityFrameworkCore;

namespace AklniResturant.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext { get; set; }

        private DbSet<T> _dbSet { get; set; }

        public Repository(ApplicationDbContext db)
        {
            _dbContext = db;
            _dbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, Query<T> op)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in op.GetIncludes())
            {
                query = query.Include(include);
            }

            if (op.HasWhere)
            {
                query = query.Where(op.Where);
            }
            if (op.HasOrderBy)
            {
                query = query.OrderBy(op.OrderBy);
            }

            var key = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKeyName = key?.Name;

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
             _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           T entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
