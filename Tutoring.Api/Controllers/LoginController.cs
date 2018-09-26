using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Accounts;
using Tutoring.Infrastructure.Extensions;

namespace Tutoring.Api.Controllers
{
    public class LoginController : ApiBaseController
    {
        private readonly IMemoryCache _memoryCache;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _memoryCache = memoryCache;
        }
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginUser command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
            var jwt = _memoryCache.GetJwt(command.TokenId);
            return Json(jwt);
        }
    }
}
