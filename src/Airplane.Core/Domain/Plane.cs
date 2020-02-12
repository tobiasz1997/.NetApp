using System;
using System.Collections.Generic;

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


        protected Plane()
        {
            
        }

        public Plane(Guid id, string brandname, string flyingFrom, string flyingTo, DateTime startFlight, DateTime endFlight)
        {
            Id = id;
            Brandname = brandname;
            FlyingFrom = flyingFrom;
            FlyingTo = flyingTo;
            StartFlight = startFlight;
            EndFlight = endFlight;
            CreatedAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }

        public void AddTickets(int amount, decimal price) {

            var seating = _tickets.Count + 1;
            for(int i=0; i<amount; i++) {
                _tickets.Add(new Ticket(this, 0, price));
                seating ++;
            }
        }
    }
}