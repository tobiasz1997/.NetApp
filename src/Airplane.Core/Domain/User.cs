﻿using System;

namespace Airplane.Core.Domain
{
    public class User : Entity
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid id, string name, string surename, string email, string password)
        {
            Id = id;
            Name = name;
            Surname = surename;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }
    }
}