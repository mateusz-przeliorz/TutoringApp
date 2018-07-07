using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Tutoring
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public int Size { get; protected set; }
        public Field Field { get; protected set; }
        public Level Level { get; protected set; }
        public string Description { get; protected set; }
        public string City { get; protected set; }
        public IEnumerable<Participant> Participants { get; protected set; }
    }
}
