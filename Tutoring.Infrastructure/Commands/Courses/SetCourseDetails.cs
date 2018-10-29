using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Commands.Courses
{
    public class SetCourseDetails : AuthenticatedCommandBase
    {
        public string Field { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
    }
}
