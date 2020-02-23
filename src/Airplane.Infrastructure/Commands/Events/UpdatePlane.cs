using System;

namespace Airplane.Infrastructure.Commands.Events
{
    public class UpdatePlane
    {
        public Guid PlaneId { get; set;}
        public string BrandName { get;  set; }
        public string FlyingFrom { get;  set; }
        public string FlyingTo { get;  set; }
    }
}