using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface ILeaderRepository
    {
        Task<Leader> GetAsync(Guid userId);
        Task<IEnumerable<Leader>> GetAllAsync();
        Task AddAsync(Leader leader);
        Task UpdateAsync(Leader leader);
    }
}
