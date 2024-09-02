using Dapper;
using Microsoft.EntityFrameworkCore;
using MultiGames.Application.Repository.Base;
using MultiGames.Infra.DataBase.Context;
using System.Linq.Expressions;

namespace MultiGames.Infra.Repository.Base;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MultiGamesContext _context;


    public Repository(MultiGamesContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAllAsync()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<T> GetById(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
    }

    public void Add(T entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.Set<T>().Remove(entity);
    }

    public Task<IEnumerable<T>> GetDapper(string sql)
    {
        // obten a conexão com o contexto do EF
        var conn = _context.Database.GetDbConnection();
      
        //utiliza o dapper com a conexão obtida
        var query = conn.QueryAsync<T>(sql);
      
        return query;
    }
}
