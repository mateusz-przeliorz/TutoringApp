using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<User> GetByNameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
