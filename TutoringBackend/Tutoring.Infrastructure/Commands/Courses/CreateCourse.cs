using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Commands.Courses
{
    public class CreateCourse : AuthenticatedCommandBase
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Field { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
    }
}
