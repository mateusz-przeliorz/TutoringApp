﻿using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(string email, string username, string password, string city);
        Task ChangeUserPasswordAsync(string email, string newPassword);
        Task<UserDto> GetAsync(string email);
    }
}
