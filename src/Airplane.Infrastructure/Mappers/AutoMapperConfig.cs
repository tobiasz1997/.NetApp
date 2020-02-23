using System.Linq;
using Airplane.Core.Domain;
using Airplane.Infrastructure.DTO;
using AutoMapper;

namespace Airplane.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
             => new MapperConfiguration(cfg => {
                 cfg.CreateMap<Plane, PlaneDTO>()
                    .ForMember(x => x.TicketsCount, m => m.MapFrom(p => p.Tickets.Count()));
                cfg.CreateMap<Plane, PlaneDetailsDTO>();
                cfg.CreateMap<Ticket, TicketDTO>();
             }).CreateMapper();
    }
}