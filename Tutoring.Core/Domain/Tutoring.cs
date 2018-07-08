using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutoring.Core.Domain
{
    public class Tutoring
    {
        private ISet<Participant> _participants = new HashSet<Participant>();

        public string Title { get; protected set; }
        public int Size { get; protected set; }
        public Field Field { get; protected set; }
        public Level Level { get; protected set; }
        public string Description { get; protected set; }
        public string City { get; protected set; }
        public IEnumerable<Participant> Participants
        {
          get  { return _participants; }
          set  { _participants = new HashSet<Participant>(value); }
        }

        public Tutoring(string title, int size, Field field, Level level, string description, string city)
        {
            Title = title;
            Field = field;
            Level = level;
            Description = description;
            City = city;
        }

        public void AddParticipant(Participant p)
        {
            var participant = GetParticipant(p);
            if (participant != null)
            {
                throw new InvalidOperationException($"Node already exists for passenger: '{participant.UserId}'.");
            }
            _participants.Add(participant);
        }

        private Participant GetParticipant(Participant participant)
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
