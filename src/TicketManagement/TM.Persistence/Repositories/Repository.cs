using Microsoft.EntityFrameworkCore;
using TM.Domain.Exceptions;
using TM.Domain.Interfaces;
using TM.Persistence.Data;

namespace TM.Persistence.Repositories;

public class Repository<T>(ApplicationDbContext _context) : IRepository<T> where T : class
{
    readonly DbSet<T> _dbSet = _context.Set<T>();

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var existingEntity= await GetAsync(id,cancellationToken) ?? throw new DataNotFoundException($"Ticket with ID {id} notfound");
        _dbSet.Remove(existingEntity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsQueryable().Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }

    public async Task<T?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> UpdateAsync(string id,T entity, CancellationToken cancellationToken = default)
    {
        T _ = await GetAsync(id, cancellationToken) ?? throw new DataNotFoundException($"Ticket with ID {id} notfound");
        _dbSet.Update(entity);
        return entity;
    }
}
