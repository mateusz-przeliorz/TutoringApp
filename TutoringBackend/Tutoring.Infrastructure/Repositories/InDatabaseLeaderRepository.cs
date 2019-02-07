using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InDatabaseLeaderRepository : ILeaderRepository
    {
        public Task<Leader> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Leader>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Leader leader)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Leader leader)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Leader leader)
        {
            throw new NotImplementedException();
        }
    }
}
