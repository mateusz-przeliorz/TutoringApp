using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InMemoryLeaderRepository : ILeaderRepository
    {
        private static ISet<Leader> _leaders = new HashSet<Leader>();

        public async Task AddAsync(Leader driver)
        {
            _leaders.Add(driver);
            await Task.CompletedTask;
        }

        public async Task<Leader> GetAsync(Guid userId)
        {   
           return await Task.FromResult(_leaders.SingleOrDefault(x => x.UserId == userId));
        }

        public async Task<IEnumerable<Leader>> GetAllAsync()
        {
            return await Task.FromResult(_leaders);
        }

        public async Task UpdateAsync(Leader driver)
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Leader leader)
        {
            _leaders.Remove(leader);
            await Task.CompletedTask;
        }
    }
}
