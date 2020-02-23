using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airplane.Core.Domain;
using Airplane.Core.Repositories;

namespace Airplane.Infrastructure.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private static readonly ISet<Plane> _plane = new HashSet<Plane>
        {
            new Plane(Guid.NewGuid(), "rajaner", "wroclaw", "kluczbork", DateTime.UtcNow.AddHours(4), DateTime.UtcNow.AddHours(8)),
            new Plane(Guid.NewGuid(), "wizar", "opole", "byczyna", DateTime.UtcNow.AddHours(1), DateTime.UtcNow.AddHours(3)),
        };

        public async Task<Plane> GetAsync(Guid id)
            => await Task.FromResult(_plane.SingleOrDefault(x => x.Id == id));

        public async Task<Plane> GetAsync(string brandname)
             => await Task.FromResult(_plane.SingleOrDefault(x => x.Brandname.ToLowerInvariant() == brandname));
        public async Task<IEnumerable<Plane>> BrowseAsync(string name = "")
        {
            var plane = _plane.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                plane = plane.Where(x => x.Brandname
                                        .ToLowerInvariant()
                                        .Contains(name.ToLowerInvariant()));
            }
            return await Task.FromResult(plane);
        }

        public async Task AddAsync(Plane plane)
        {
            _plane.Add(plane);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Plane plane)
            => await Task.CompletedTask;

        public async Task DeleteAsync(Plane plane)
        {
            _plane.Remove(plane);
            await Task.CompletedTask;
        }

    }
}