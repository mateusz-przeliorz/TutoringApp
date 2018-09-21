using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Leaders;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Api.Controllers
{
    public class LeaderController : ApiBaseController
    {
        private readonly ILeaderService _leaderService;

        public LeaderController(ICommandDispatcher commandDispatcher, ILeaderService leaderService) 
            : base(commandDispatcher)
        {
            _leaderService = leaderService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateLeader command)
        {
            await CommandDispatcher.DispatchAsync(command);
                
            return Created($"drivers/{command.UserId}", null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var leader = await _leaderService.GetAsync(id);
            if (leader == null)
            {
                return NotFound();
            }
            return Json(leader);
        }
    }
}
