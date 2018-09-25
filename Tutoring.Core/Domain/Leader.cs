using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Leader
    {
        private ISet<Course> _tutorings = new HashSet<Course>();
        public Guid UserId { get; protected set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        protected Leader()
        {
        }

        public IEnumerable<Course> Tutorings
        {
            get { return _tutorings; }
            set { _tutorings = new HashSet<Course>(value); }
        }

        public Leader(User user)
        {
            UserId = user.Id;
            Name = user.Username;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddTutoring(Course course)
        {
            var tutoring = Tutorings.SingleOrDefault(x => x.Id == course.Id);
            if (tutoring != null)
            {
                throw new Exception($"Tutoring with id: '{course.Id}' already exists.");
            }

            _tutorings.Add(course);
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteTutoring(Course course)
        {
            var tutoring = Tutorings.SingleOrDefault(x => x.Id == course.Id);
            if (tutoring == null)
            {
                throw new Exception($"Tutoring named: '{course.Name}' for leader: '{Name}' was not found.");
            }

            _tutorings.Remove(tutoring);
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
