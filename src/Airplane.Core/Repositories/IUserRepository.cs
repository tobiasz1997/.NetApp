using System;
using System.Threading.Tasks;
using Airplane.Core.Domain;

namespace Airplane.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email); //unikalna nazwa
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}