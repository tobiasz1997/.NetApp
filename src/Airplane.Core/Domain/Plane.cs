using System;
using System.Collections.Generic;
using System.Linq;

namespace Airplane.Core.Domain
{
    public class Plane : Entity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();

        public string Brandname { get; protected set; }
        public string FlyingFrom { get; protected set; }
        public string FlyingTo { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartFlight { get; protected set; }
        public DateTime EndFlight { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchasedTickets => _tickets.Where(x => x.IsPurchased);
        public IEnumerable<Ticket> AvailableTickets => _tickets.Except(PurchasedTickets);


        protected Plane()
        {

        }

        public Plane(Guid id, string brandname, string flyingFrom, string flyingTo, DateTime startFlight, DateTime endFlight)
        {
            Id = id;
            SetBrandname(brandname);
            SetDeparturePlace(flyingFrom, flyingTo);
            StartFlight = startFlight;
            EndFlight = endFlight;
            CreatedAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }

        public void SetBrandname(string brandname)
        {
            if (string.IsNullOrWhiteSpace(brandname))
            {
                throw new Exception($"Plane with id {Id} can not be empty. ");
            }
            Brandname = brandname;
            UpdateAt = DateTime.UtcNow;
        }

        public void SetDeparturePlace(string flyingFrom, string flyingTo)
        {
            if (string.IsNullOrWhiteSpace(flyingFrom) & string.IsNullOrWhiteSpace(flyingTo))
            {
                throw new Exception($"Plane with id {Id} can not be empty departure places. ");
            }
            FlyingFrom = flyingFrom;
            FlyingTo = flyingTo;
            UpdateAt = DateTime.UtcNow;
        }

        public void AddTickets(int amount, decimal price)
        {

            var seating = _tickets.Count + 1;
            for (int i = 0; i < amount; i++)
            {
                _tickets.Add(new Ticket(this, 0, price));
                seating++;
            }
        }
    }
}