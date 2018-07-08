using System;
using System.Collections.Generic;
using System.Text;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid id);
        User GetByEmail(string email);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Remove(Guid id);
        void Update(User user);
    }
}
