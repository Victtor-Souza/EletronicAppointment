using EletronicAppointment.Domain;
using Microsoft.EntityFrameworkCore;

namespace EletronicAppointment.Infrastructure.DataAccess;

public class CommonRepository<T> : ICommonRepository<T> where T : class
{
    protected readonly Context _context;

    public CommonRepository(Context context)
    {
            _context = context;
    }

    public virtual async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);    
    }

    public virtual Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.FromResult(true);
    }

    public virtual async Task<T> GetAsync(Guid id)
    {
         var entity = await _context.Set<T>().FindAsync(id);
         return entity;
    }

    public virtual Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.FromResult(true);
    }
}