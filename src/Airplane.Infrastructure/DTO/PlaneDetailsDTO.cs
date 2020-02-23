using System.Collections.Generic;

namespace Airplane.Infrastructure.DTO
{
    public class PlaneDetailsDTO : PlaneDTO
    {
        public IEnumerable<TicketDTO> Tickets {get; set;}
    }
}