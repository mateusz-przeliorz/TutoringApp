using AutoMapper;
using System;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto GetByEmail(string email)
        {
            User user = _userRepository.GetByEmail(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public void Register(Guid userId, string email, string username, string password, string city)
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
            user = new User(userId, email, username, password, salt, city);
            _userRepository.Add(user);
        }
    }
}
