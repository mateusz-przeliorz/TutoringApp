﻿using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(Guid userId, string email, string username, string password, string city);
        Task<UserDto> GetAsync(string email);
    }
}
