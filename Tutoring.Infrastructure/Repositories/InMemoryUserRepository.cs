using System;
using System.Collections.Generic;
using System.Linq;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users;

        public InMemoryUserRepository()
        {
            _users = new HashSet<User>();
        }
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()); 
        }

        public User GetByUsername(string username)
        {
            return _users.SingleOrDefault(x => x.Username == username.ToLowerInvariant());
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            User user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}
