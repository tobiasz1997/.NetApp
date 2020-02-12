using System;

namespace Airplane.Core.Domain
{
    public class Ticket : Entity
    {
        public Guid FlightId {get; protected set;}

        public int Seating { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid? UserId { get; protected set; }
        public string PassengerName { get; protected set; }
        public string PassengerSurename { get; protected set; }
        public DateTime? PurchasedAt { get; protected set; }
        public bool IsPurchased => UserId.HasValue;


        protected Ticket()
        {
        }

        public Ticket(Plane plane, int seating, decimal price)
        {
            FlightId = plane.Id;
            Seating = seating;
            Price = price;
        }
    }
}