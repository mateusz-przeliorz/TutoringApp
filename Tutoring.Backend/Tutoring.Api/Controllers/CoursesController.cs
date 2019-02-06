using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Courses;
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
        public async Task<IActionResult> GetAsync()
        {
            var courses = await _courseService.GetAllAsync();

            return Json(courses);
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetAsync(Guid courseId)
        {
            var course = await _courseService.GetAsync(courseId);

            return Json(course);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateCourse command)
        {
            await DispatchAsync(command);
            return Created($"api/courses/{command.Name}", new object());
        }
    }
}
