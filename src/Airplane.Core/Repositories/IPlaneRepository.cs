using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airplane.Core.Domain;

namespace Airplane.Core.Repositories
{
    public interface IPlaneRepository
    {
         Task<Plane> GetAsync(Guid id);
         Task<Plane> GetAsync(string brandname); //unikalna nazwa
         Task<IEnumerable<Plane>> BrowseAsync(string name = "");
         Task AddAsync (Plane plane);
         Task UpdateAsync(Plane plane);
         Task Deleteasync(Plane plane);
    }
}