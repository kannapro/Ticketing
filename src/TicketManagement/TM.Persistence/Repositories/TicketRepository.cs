using TM.Domain.Entities;
using TM.Domain.Enums;
using TM.Domain.Interfaces;
using TM.Persistence.Data;

namespace TM.Persistence.Repositories;

public class TicketRepository(ApplicationDbContext context) : Repository<Ticket>(context), ITicketRepository
{
    private readonly ApplicationDbContext _context = context;
    public void ExpireReservations()
    {
        var expiredTickets = _context.Tickets
            .Where(t => 
                t.ReservationStatus == ReservationStatus.Reserved && 
                t.ReservationExpiryTime < DateTime.UtcNow
            ).ToList();
        expiredTickets.ForEach(t=> {
            t.ReservationStatus = ReservationStatus.Available;
            t.ReservationExpiryTime = null;
            t.UserId=string.Empty;
            });
        _context.UpdateRange(expiredTickets);
    }
}
