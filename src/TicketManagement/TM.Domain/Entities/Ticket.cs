using System.ComponentModel.DataAnnotations;
using TM.Domain.Enums;

namespace TM.Domain.Entities
{
    public class Ticket
    {
        public Ticket() => Amount = NumberOfSeats * Price;
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public required string EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public required string EventName { get; set; }
        public required int NumberOfSeats { get; set; }
        public required string SeatNumbers { get; set; }
        public required decimal Price { get; set; }
        public decimal Amount { get; set; }
        public TicketStatus Status { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public DateTime? ReservationExpiryTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public required byte[] RowVersion { get; set; }

    }
}
