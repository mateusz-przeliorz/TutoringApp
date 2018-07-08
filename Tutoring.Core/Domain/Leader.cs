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
        private ISet<Tutoring> _tutorings = new HashSet<Tutoring>();

        public Guid UserId { get; protected set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IEnumerable<Tutoring> Tutorings
        {
            get { return _tutorings; }
            set { _tutorings = new HashSet<Tutoring>(value); }
        }

        protected Leader()
        {
        }

        public Leader(User user)
        {
            UserId = user.Id;
            Name = user.Username;
        }
        public void AddTutoring(string title, int size, string field, string level, string description, string city)
        {
            var tutoring = Tutorings.SingleOrDefault(x => x.Details.Title == title);
            if (tutoring != null)
            {
                throw new Exception($"Tutoring with title: '{title}' already exists.");
            }

            tutoring.SetDetails(Details.Create(title, size, field, level, description, city));

            _tutorings.Add(tutoring);
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteTutoring(string title)
        {
            var tutoring = Tutorings.SingleOrDefault(x => x.Details.Title == title);
            if (tutoring == null)
            {
                throw new Exception($"Tutoring named: '{title}' for driver: '{Name}' was not found.");
            }
            _tutorings.Remove(tutoring);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
