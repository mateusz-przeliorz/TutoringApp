using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutoring.Core.Domain
{
    public class Tutoring
    {
        private ISet<Participant> _participants = new HashSet<Participant>();
        public Guid Id { get; protected set; }
        public Details Details { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Participant> Participants
        {
          get  { return _participants; }
          set  { _participants = new HashSet<Participant>(value); }
        }

        protected Tutoring()
        {
        }

        public void SetDetails(Details details)
        {
            Details = details;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddParticipant(Participant p)
        {
            var participant = GetParticipant(p);
            if (participant != null)
            {
                throw new InvalidOperationException($"Participant already exists: '{participant.UserId}'.");
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
