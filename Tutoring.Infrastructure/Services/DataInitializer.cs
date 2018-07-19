using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILeaderService _leaderService;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DataInitializer(IUserService userService, ILeaderService leaderService)
        {
            _userService = userService;
            _leaderService = leaderService;
        }

        public async Task SeedAsync()
        {
            var users = await _userService.BrowseAsync();
            if (users.Any())
            {
                Logger.Trace("Data was already initialized.");
                return;
            }

            Logger.Trace("Initializing data...");
            var tasks = new List<Task>();
            for (var i = 1; i <= 5; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId,$"user{i}@test.com", username, "secret", "Wroclaw", "user"));
                Logger.Trace($"Adding user with username: '{username}'.");
                tasks.Add(_leaderService.CreateAsync(userId));
                Logger.Trace($"Adding leader for: '{username}'.");
            }

            for (var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                Logger.Trace($"Adding admin with username: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId,$"admin{i}@test.com", username, "secret", "Wroclaw", "admin"));
            }
            await Task.WhenAll(tasks);
            Logger.Trace("Data was initialized.");
        }
    }
}
