using System;

namespace Tutoring.Infrastructure.Dtos
{
    public class UserDto
    {
        public Guid Id { get;  set; }
        public string Email { get;  set; }
        public string FullName { get;  set; }
        public string Username { get;  set; }
        public string City { get; set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get;  set; }
    }
}
