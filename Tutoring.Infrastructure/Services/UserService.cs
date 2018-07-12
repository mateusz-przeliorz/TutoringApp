using AutoMapper;
using System;
using System.Threading.Tasks;
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

        public async Task ChangeUserPasswordAsync(string email, string newPassword)
        {
            var user = await _userRepository.GetAsync(email);
            user.SetPassword(newPassword);
            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string username, string password, string city)
        {
            var user = await _userRepository.GetAsync(email);
            
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            user = await _userRepository.GetByNameAsync(username);

            if (user != null)
            {
                throw new Exception($"User with username: '{username}' already exists.");
            }

            string salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, city);
            await _userRepository.AddAsync(user);
        }
    }
}
