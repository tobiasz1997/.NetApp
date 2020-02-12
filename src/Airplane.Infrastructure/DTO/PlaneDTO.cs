using System;
using System.Collections.Generic;

namespace Airplane.Infrastructure.DTO
{
    public class PlaneDTO
    {
        public Guid Id { get; set;}
        public string BrandName { get;  set; }
        public string FlyingFrom { get;  set; }
        public string FlyingTo { get;  set; }
        public DateTime StartFlight { get;  set; }
        public DateTime EndFlight { get;  set; }
        public DateTime UpdateAt { get;  set; }
        public int TicketsCount { get;  set; }

    }
}