using System;
using System.Text.RegularExpressions;

namespace Tutoring.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string FullName { get; protected set; }
        public string Username { get; protected set; }
        public string City { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid userId, string email, string username,
            string password, string salt, string city, string role)
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password);
            Role = role;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
            City = city;
        }

        public void SetUsername(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }

            if (String.IsNullOrEmpty(username))
            {
                throw new Exception("Username is invalid.");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            } 

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is invalid.");
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }  

            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }

            if (password.Length > 100)
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }

            if (Password == password)
            {
                return;
            }

            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
