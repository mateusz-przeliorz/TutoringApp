using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Participant
    {
        private ISet<Course> _courses = new HashSet<Course>();
        public Guid UserId { get; protected set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IEnumerable<Course> Courses
        {
            get { return _courses; }
            set { _courses = new HashSet<Course>(value); }
        }

        protected Participant()
        {
        }

        public Participant(User user)
        {
            UserId = user.Id;
            Name = user.Username;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Participant Create(User user)
        {
            return new Participant(user);
        }
    }
}
