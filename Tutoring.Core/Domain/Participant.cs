using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Participant
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; set; }

        protected Participant()
        {
        }

        public Participant(Guid id, string username)
        {
            Id = Guid.NewGuid();
            UserId = id;
            Name = username;
        }
    }
}
