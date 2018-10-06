using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;

namespace Tutoring.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class ApiBaseController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        private Guid UserId => User?.Identity?.IsAuthenticated == true ?
                                 Guid.Parse(User.Identity.Name) :
                                 Guid.Empty;
        
        protected ApiBaseController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthenticatedCommandBase authenticatedCommandBase)
            {
                authenticatedCommandBase.UserId = UserId;
            }
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}
