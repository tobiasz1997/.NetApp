using System;

namespace Airplane.Infrastructure.Commands.Events
{
    public class CreatePlane
    {
        public Guid PlaneId { get; set;}
        public string BrandName { get;  set; }
        public string FlyingFrom { get;  set; }
        public string FlyingTo { get;  set; }
        public DateTime StartFlight { get;  set; }
        public DateTime EndFlight { get;  set; }
        public int Tickets { get;  set; }
        public decimal Price { get;  set; }
    }
}