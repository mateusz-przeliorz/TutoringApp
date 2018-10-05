using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(Guid userId, string email, string username, string password, string city, string role);
        Task LoginAsync(string email, string password);
        Task ChangeUserPasswordAsync(string email, string newPassword);
        Task SendEmailWithNewUserPasswordAsync(Guid userId);
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> BrowseAsync();
        string GenerateUserNewPassword();
    }
}
