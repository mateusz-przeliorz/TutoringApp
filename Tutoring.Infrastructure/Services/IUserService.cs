using System;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface IUserService
    {
        void Register(Guid userId, string email, string username, string password);
        UserDto GetByEmail(string email);
    }
}
