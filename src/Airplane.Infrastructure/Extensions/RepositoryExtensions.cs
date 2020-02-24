using System;
using System.Threading.Tasks;
using Airplane.Core.Domain;
using Airplane.Core.Repositories;

namespace Airplane.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Plane> GetOrFailAsync(this IPlaneRepository repository, Guid id) {
            var plane = await repository.GetAsync(id);

            if(plane == null)
            {
                throw new Exception($"Plane with id: {id} is not exist");
            }

            return plane;
        }
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid id) {
            var user = await repository.GetAsync(id);

            if(user == null)
            {
                throw new Exception($"User with id: {id} is not exist");
            }

            return user;
        }
    }
}