using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Commands.Accounts
{
    public class LoginUser : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
