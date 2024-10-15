using TM.Domain.Entities;

namespace TM.Domain.Interfaces;

public interface ITicketRepository:IRepository<Ticket>
{
    void ExpireReservations();
}
