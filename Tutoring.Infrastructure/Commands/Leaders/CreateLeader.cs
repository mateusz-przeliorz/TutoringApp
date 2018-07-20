using System;

namespace Tutoring.Infrastructure.Commands.Leaders
{
    public class CreateLeader : ICommand
    {
        public Guid UserId { get; set; }
    }
}
