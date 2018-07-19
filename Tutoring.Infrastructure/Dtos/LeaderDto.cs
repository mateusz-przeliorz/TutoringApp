using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Dtos
{
    public class LeaderDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
