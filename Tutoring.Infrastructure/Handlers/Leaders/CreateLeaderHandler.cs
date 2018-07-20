using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Leaders;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Infrastructure.Handlers.Leaders
{
    public class CreateLeaderHandler : ICommandHandler<CreateLeader>
    {
        private readonly ILeaderService _leaderService;

        public CreateLeaderHandler(ILeaderService leaderService)
        {
            _leaderService = leaderService;
        }

        public async Task HandleAsync(CreateLeader command)
        {
            await _leaderService.CreateAsync(command.UserId);
        }
    }
}
