using System;
using System.Collections.Generic;
using System.Text;
using Tutoring.Core.Domain;

namespace Tutoring.Infrastructure.Dtos
{
    public class CourseDto
    {
        private ISet<Participant> _participants = new HashSet<Participant>();

        public Guid Id { get;  set; }
        public CourseDetails Details { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime UpdatedAt { get;  set; }
        public string Name { get;  set; }
        public int Size { get;  set; }
        public string City { get;  set; }
        public string Description { get;  set; }

        public IEnumerable<Participant> Participants
        {
            get { return _participants; }
            set { _participants = new HashSet<Participant>(value); }
        }
    }
}
