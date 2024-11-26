using System.Linq.Expressions;
using DomainModel.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.Repository
{
    public class RepositoryBase<T>(AppDbContext appDbContext) : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet = appDbContext.Set<T>();

        public void Add(T entity) => _dbSet.Add(entity);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void AddRange(IEnumerable<T> entities) => _dbSet.AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);

        public IQueryable<T> FindAll() => _dbSet.AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _dbSet.AsNoTracking().Where(expression);

        public IQueryable<T> GetQueryable() => _dbSet;

        public T? GetById(long id) => _dbSet.Find(id);

        public async Task<T?> GetByIdAsync(long id) => await _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}
