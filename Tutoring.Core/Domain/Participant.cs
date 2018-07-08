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

        public Participant(User user)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            Name = user.Username;
        }
    }
}
