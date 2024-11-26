using System.Linq.Expressions;

namespace DomainModel.Repository
{
    public interface IRepositoryBase<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetQueryable();
        T? GetById(long id);
        Task<T?> GetByIdAsync(long id);
        void Update(T entity);
        void Delete(T entity);
    }
}
