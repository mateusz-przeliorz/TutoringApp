using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Users;
using Tutoring.Infrastructure.Services;

namespace Tutoring.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {

        private readonly IUserService _userService;

        public ChangeUserPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(ChangeUserPassword command)
        {
            await _userService.ChangeUserPasswordAsync(command.Email, command.NewPassword);
        }
    }
}
