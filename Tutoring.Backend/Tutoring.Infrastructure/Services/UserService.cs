using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
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
        private readonly IEmailSender _emailSender;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter,
                                IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
            _emailSender = emailSender;
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task ChangeUserPasswordAsync(string email, string newPassword)
        {
            var user = await _userRepository.GetAsync(email);

            var salt = _encrypter.GetSalt(newPassword);
            var hash = _encrypter.GetHash(newPassword, salt);
            user.SetPassword(hash);
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

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            if(user.Password == hash)
            {
                return;
            }

            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string city, string role)
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
            user = new User(userId, email, username, hash, salt, city, role);
            await _userRepository.AddAsync(user);
        }

        public async Task SendEmailWithNewUserPasswordAsync(string email)
        {
            var user = await _userRepository.GetAsync(email); 

            if(user == null)
            {
                throw new Exception($"User with email: '{email}' can not be found.");
            }

            var newPassword = GenerateUserNewPassword();
            var message = $"Operacja generowania nowego hasła powiodła się sukcesem. Nowe hasło: '{newPassword}'.";
            var subject = "TutoringApp - Wygenerowano nowe hasło";

            await ChangeUserPasswordAsync(email, newPassword);
            await _emailSender.SendEmailAsync(email, subject, message);
        }

        public string GenerateUserNewPassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int length = 10;
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
