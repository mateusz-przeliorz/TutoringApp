using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Leader
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public IEnumerable<Tutoring> Tutorings { get; protected set; }
    }
}
