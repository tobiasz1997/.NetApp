using System;

namespace Airplane.Infrastructure.DTO
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}