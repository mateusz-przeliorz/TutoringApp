﻿using System.Threading.Tasks;
using Xunit;
using Moq;
using Tutoring.Core.Repositories;
using Tutoring.Infrastructure.Services;
using AutoMapper;
using System;
using Tutoring.Core.Domain;

namespace Tutoring.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@email.com", "user", "secret","Wroclaw");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        //[Fact]
        //public async Task when_calling_get_async_and_user_exists()
        //{
        //    var userRepositoryMock = new Mock<IUserRepository>();
        //    var mapperMock = new Mock<IMapper>();

        //    var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
        //    await userService.GetAsync("user1@email.com");

        //    var user = new User("user1@email.com");

        //    userRepositoryMock
        //    .Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
        //}

        //[Fact]
        //public async Task when_calling_get_async_and_user_does_not_exists()
        //{
        //    var userRepositoryMock = new Mock<IUserRepository>();
        //    var mapperMock = new Mock<IMapper>();

        //    var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
        //    await userService.GetAsync("user@email.com");

        //    userRepositoryMock
        //    .Setup(x => x.GetAsync("user@email.com"))
        //    .ReturnsAsync(() => null);
        //}
    }
}