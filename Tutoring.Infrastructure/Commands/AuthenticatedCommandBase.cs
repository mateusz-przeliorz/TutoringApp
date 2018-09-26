using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Commands
{
    public class AuthenticatedCommandBase : IAuthenticatedCommandBase
    {
        public Guid UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
