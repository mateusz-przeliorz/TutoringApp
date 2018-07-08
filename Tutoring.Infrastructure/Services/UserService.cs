using System;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto GetByEmail(string email)
        {
            User user = _userRepository.GetByEmail(email);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                CreatedAt = user.CreatedAt,
                City = user.City
            };
        }

        public void Register(Guid userId, string email, string username, string password)
        {
            User user = _userRepository.GetByEmail(email);
            
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            user = _userRepository.GetByUsername(username);

            if (user != null)
            {
                throw new Exception($"User with username: '{username}' already exists.");
            }

            string salt = Guid.NewGuid().ToString("N");
            user = new User(userId, email, username, password, salt);
            _userRepository.Add(user);
        }
    }
}
