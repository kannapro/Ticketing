using TM.Domain.Entities;
using TM.Domain.Interfaces;
using TM.Persistence.Data;

namespace TM.Persistence;

public class UnitOfWork(ApplicationDbContext _context,IRepository<Ticket> _tickets): IUnitOfWork
{
    public IRepository<Ticket> tickets => _tickets;

    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
       return await _context.SaveChangesAsync(cancellationToken);
    }
}
