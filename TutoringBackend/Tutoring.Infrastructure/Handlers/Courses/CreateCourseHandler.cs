using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Courses;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Infrastructure.Handlers.Courses
{
    public class CreateCourseHandler : ICommandHandler<CreateCourse>
    {
        private readonly ICourseService _courseService;

        public CreateCourseHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task HandleAsync(CreateCourse command)
        {
           await _courseService.CreateAsync(Guid.NewGuid(), command.Name, command.Size, command.City,
                                            command.Description, command.Field, command.Level, command.Subject);
        }
    }
}
