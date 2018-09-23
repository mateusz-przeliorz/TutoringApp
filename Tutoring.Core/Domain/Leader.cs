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
        public Guid UserId { get; protected set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        protected Leader()
        {
        }

        public Leader(User user)
        {
            UserId = user.Id;
            Name = user.Username;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
