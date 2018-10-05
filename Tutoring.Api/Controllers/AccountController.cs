using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Users;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Api.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IUserService _userService;

        public AccountController(ICommandDispatcher commandDispatcher, IUserService userService) 
                    : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
                await DispatchAsync(command);
                return Created($"api/account/{command.Email}", null);
        }

        [HttpGet]
        [Route("GenerateNewPassword")]
        public async Task<IActionResult> Get()
        {
            await _userService.SendEmailWithNewUserPasswordAsync(UserId);
            return Ok();
        }
    }
}
