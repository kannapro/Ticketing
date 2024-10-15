using TM.Domain.Entities;

namespace TM.Domain.Interfaces;

public interface IUnitOfWork
{
    IRepository<Ticket> tickets { get; }
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
}
