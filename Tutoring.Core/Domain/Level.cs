using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Level
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
