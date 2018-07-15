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
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
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

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);

            if(user.Password == hash)
            {
                return;
            }

            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(string email, string username, string password, string city, string role)
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

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(email, username, hash, salt, city, role);
            await _userRepository.AddAsync(user);
        }
    }
}
