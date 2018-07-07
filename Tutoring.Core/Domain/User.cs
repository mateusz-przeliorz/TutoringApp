using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string FullName { get; protected set; }
        public int Age { get; protected set; }
        public string Username { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public User(string email, string username, string password, string salt, int age)
        {
            Id = Guid.NewGuid();
            Email = email;
            Username = username;
            Password = password;
            Salt = salt;
            Age = age;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
