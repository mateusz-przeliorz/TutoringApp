using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : AuthenticatedCommandBase
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
