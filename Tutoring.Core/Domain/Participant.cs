using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Participant
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
    }
}
