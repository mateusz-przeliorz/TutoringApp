using System;
using System.Collections.Generic;
using System.Text;
using Tutoring.Core.Domain;

namespace Tutoring.Infrastructure.Dtos
{
    public class CourseDto
    {
        private ISet<Participant> _participants = new HashSet<Participant>();
        public Guid Id { get; protected set; }
        public Details Details { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<Participant> Participants
        {
            get { return _participants; }
            set { _participants = new HashSet<Participant>(value); }
        }
    }
}
