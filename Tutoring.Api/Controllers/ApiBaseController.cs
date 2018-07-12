using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
