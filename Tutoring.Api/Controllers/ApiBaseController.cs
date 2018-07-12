using Microsoft.AspNetCore.Mvc;
using Tutoring.Infrastructure.Commands;

namespace Tutoring.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected ApiBaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}
