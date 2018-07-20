using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Api.Controllers
{
    public class CoursesController : ApiBaseController
    {
        private readonly ICourseService _courseService;
        private readonly ICourseDetailsProvider _courseDetailsProvider;

        public CoursesController(ICommandDispatcher commandDispatcher, ICourseService courseService,
            ICourseDetailsProvider courseDetailsProvider) 
                    : base(commandDispatcher)
        {
            _courseService = courseService;
            _courseDetailsProvider = courseDetailsProvider;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _courseDetailsProvider.BrowseAsync();

            return Json(users);
        }
    }
}
