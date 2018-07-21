using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Users;
using Tutoring.Infrastructure.Services;
using Tutoring.Infrastructure.Settings;

namespace Tutoring.Api.Controllers
{
    public class UsersController : ApiBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
             : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.BrowseAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Json(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"api/users/{command.Email}", new object());
        }
    }
}
