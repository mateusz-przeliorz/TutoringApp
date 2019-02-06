using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Commands
{
    public interface IAuthenticatedCommandBase : ICommand
    {
        Guid UserId { get; set; }
    }
}
