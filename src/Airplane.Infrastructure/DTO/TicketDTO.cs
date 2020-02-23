using System;

namespace Airplane.Infrastructure.DTO
{
    public class TicketDTO
    {
        public Guid FlightId { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public Guid? UserId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurename { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public bool IsPurchased { get; set; }
    }
}