using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutoring.Core.Domain
{
    public class Course
    {
        private ISet<Participant> _participants = new HashSet<Participant>();
        public Guid Id { get; protected set; }
        public CourseDetails Details { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public string Name { get; protected set; }
        public int Size { get; protected set; }
        public string City { get; protected set; }
        public string Description { get; protected set; }

        public IEnumerable<Participant> Participants
        {
          get  { return _participants; }
          set  { _participants = new HashSet<Participant>(value); }
        }
        
        public Course(CourseDetails details, string name, int size, string city, string description)
        {
            SetCourseDetails(details);
            SetName(name);
            SetSize(size);
            SetCity(city);
            SetDescription(description);
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please provide valid data.");
            }
            if (Name == name)
            {
                return;
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetSize(int size)
        {
            if (size < 0)
            {
                throw new Exception("Seats must be greater than 0.");
            }

            if (Size == size)
            {
                return;
            }
            Size = size;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new Exception("Please provide valid city.");
            }
            if (City == city)
            {
                return;
            }
            City = city;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Please provide valid description.");
            }
            if (description.Length > 400)
            {
                throw new Exception("Description length can not be greater than 400 marks.");
            }
            if (Description == description)
            {
                return;
            }
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetCourseDetails(CourseDetails details)
        {
            if(details != null)
            {
                Details = details;
                UpdatedAt = DateTime.UtcNow;
                return;
            }
            throw new Exception("Details can not be empty");
        }

        public void AddParticipant(Participant p)
        {
            var participant = GetParticipant(p);
            if (participant != null)
            {
                throw new InvalidOperationException($"Participant already exists: '{participant.UserId}'.");
            }
            _participants.Add(p);
        }

        public Participant GetParticipant(Participant participant)
        {
            return _participants.SingleOrDefault(x => x.UserId == participant.UserId);
        }

        public void RemoveParticipant(Participant p)
        {
            var participant = GetParticipant(p);
            if (participant == null)
            {
                return;
            }
            _participants.Remove(participant);
        }
    }
}
