using System;
using Airplane.Infrastructure.DTO;

namespace Airplane.Infrastructure.Services
{
    public interface IJWTHandler
    {
         JwtDTO CreateToken(Guid userId, string role);
    }
}