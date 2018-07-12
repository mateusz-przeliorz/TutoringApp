using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("email2@email.com","user1","qwe123","Wroclaw"),
            new User("email3@email.com","user2","qwe123","Wroclaw"),
            new User("email4@email.com","user3","qwe123","Wroclaw")
        };
       
        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));
        }

        public async Task<User> GetByNameAsync(string username)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Username == username.ToLowerInvariant()));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            var changedUser = await GetAsync(user.Id);
            changedUser = user;
            await Task.CompletedTask;
        }
       
    }
}
