using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Users;

namespace Tutoring.Api.Controllers
{
    public class AccountsController : ApiBaseController
    {

        public AccountsController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody]ChangeUserPassword command)
        {
            try
            {
                await CommandDispatcher.DispatchAsync(command);
                return Created($"api/accounts/{command.Email}", new object());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}
