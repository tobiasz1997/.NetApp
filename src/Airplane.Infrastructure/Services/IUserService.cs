using System;
using System.Threading.Tasks;
using Airplane.Infrastructure.DTO;

namespace Airplane.Infrastructure.Services
{
    public interface IUserService
    {
        Task<AccountDTO> GetAccountAsync(Guid userId);
        Task RegisterAsync(Guid userId, string name, string surename, string email, string password, string role = "user");
        Task<TokenDTO> LoginAsync(string email, string password);
    }
}