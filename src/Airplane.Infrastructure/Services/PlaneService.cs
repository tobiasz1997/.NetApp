using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Airplane.Core.Repositories;
using Airplane.Infrastructure.DTO;
using AutoMapper;

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
        public async Task<PlaneDTO> GetAsync(Guid id)
        {
            var plane = await _planeRepository.GetAsync(id);

            return _mapper.Map<PlaneDTO>(plane);
        }

        public async Task<PlaneDTO> GetAsync(string brandname)
        {
            var plane = await _planeRepository.GetAsync(brandname);

            return _mapper.Map<PlaneDTO>(plane);
        }

        public async Task<IEnumerable<PlaneDTO>> BrowseAsync(string brandname = null)
        {
            var planes = await _planeRepository.BrowseAsync(brandname);

            return _mapper.Map<IEnumerable<PlaneDTO>>(planes);
        }

        public async Task AddTicketsAsync(Guid planeId, int amount, decimal price)
        {
            throw new NotImplementedException();
        }


        public async Task CreateAsync(Guid id, string brandname, string flyingFrom, string flyingTo, DateTime startFlight, DateTime endFlight)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateAsync(Guid id, string brandname, string flyingFrom, string flyingTo)
        {
            throw new NotImplementedException();
        }
    }
}