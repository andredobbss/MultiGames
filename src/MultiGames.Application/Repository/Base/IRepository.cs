using System.Linq.Expressions;

namespace MultiGames.Application.Repository.Base;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAllAsync();
    Task<IEnumerable<T>> GetDapper(string sql);
    Task<T> GetById(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
