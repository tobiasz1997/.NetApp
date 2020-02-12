using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airplane.Infrastructure.DTO;

namespace Airplane.Infrastructure.Services
{
    public interface IPlaneService
    {
        Task<PlaneDTO> GetAsync(Guid id);
        Task<PlaneDTO> GetAsync(string brandname);
        Task<IEnumerable<PlaneDTO>> BrowseAsync(string brandname = null);
        Task CreateAsync(Guid id, string brandname, string flyingFrom,
                           string flyingTo, DateTime startFlight, DateTime endFlight);
        Task AddTicketsAsync(Guid planeId, int amount, decimal price);
        Task UpdateAsync(Guid id, string brandname, string flyingFrom,
                            string flyingTo);
        Task DeleteAsync(Guid id);
    }
}