using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Accounts;
using Tutoring.Infrastructure.Extensions;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _memoryCache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler,
            IMemoryCache memoryCache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }

        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            if(user == null)
            {
                throw new Exception($"User with user email: '{command.Email}' can not be found.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _memoryCache.SetJwt(command.TokenId, jwt);
        }
    }
}
