using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Api.Controllers
{
    public class ParticipantController : ApiBaseController
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(ICommandDispatcher commandDispatcher, IParticipantService participantService)
            : base(commandDispatcher)
        {
            _participantService = participantService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var participants = await _participantService.BrowseAsync();
            if (participants == null)
            {
                return NotFound();
            }
            return Json(participants);
        } 
    }
}
