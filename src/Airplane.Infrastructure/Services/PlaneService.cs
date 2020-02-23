using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Airplane.Core.Repositories;
using Airplane.Infrastructure.DTO;
using AutoMapper;
using Airplane.Core.Domain;
using Airplane.Infrastructure.Extensions;

namespace Airplane.Infrastructure.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly IPlaneRepository _planeRepository;
        private readonly IMapper _mapper;


        public PlaneService(IPlaneRepository planeRepository,
                            IMapper mapper)
        {
            _planeRepository = planeRepository;
            _mapper = mapper;
        }
        public async Task<PlaneDetailsDTO> GetAsync(Guid id)
        {
            var plane = await _planeRepository.GetAsync(id);

            return _mapper.Map<PlaneDetailsDTO>(plane);
        }

        public async Task<PlaneDetailsDTO> GetAsync(string brandname)
        {
            var plane = await _planeRepository.GetAsync(brandname);

            return _mapper.Map<PlaneDetailsDTO>(plane);
        }

        public async Task<IEnumerable<PlaneDTO>> BrowseAsync(string brandname = null)
        {
            var planes = await _planeRepository.BrowseAsync(brandname);

            return _mapper.Map<IEnumerable<PlaneDTO>>(planes);
        }

        public async Task AddTicketsAsync(Guid planeId, int amount, decimal price)
        {
            var plane = await _planeRepository.GetAsync(planeId);
            if(plane == null) {
                throw new Exception($"Plane {planeId} is exist");
            }

            plane.AddTickets(amount, price);
            await _planeRepository.UpdateAsync(plane);
        }


        public async Task CreateAsync(Guid id, string brandname, string flyingFrom, string flyingTo, DateTime startFlight, DateTime endFlight)
        {
            var plane = await _planeRepository.GetAsync(brandname);

            if(plane != null)
            {
                throw new Exception($"Plane {brandname} is exist");
            }
            plane = new Plane(id, brandname, flyingFrom, flyingTo, startFlight, endFlight);
            await _planeRepository.AddAsync(plane);
        }

        public async Task DeleteAsync(Guid id)
        {
            var plane = await _planeRepository.GetOrFailAsync(id);
            await _planeRepository.DeleteAsync(plane);
        }


        public async Task UpdateAsync(Guid id, string brandname, string flyingFrom, string flyingTo)
        {
            var plane = await _planeRepository.GetAsync(brandname);
            if(plane != null)
            {
                throw new Exception($"Plane {brandname} is exist");
            }
            
            plane = await _planeRepository.GetOrFailAsync(id);
            plane.SetBrandname(brandname);
            plane.SetDeparturePlace(flyingFrom, flyingTo);
            await _planeRepository.UpdateAsync(plane);
        }
    }
}