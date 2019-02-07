using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InDatabaseParticipantRepository : IParticipantRepository
    {
        public Task<Participant> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participant>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participant>> GetAllForCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Participant participant)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Participant participant)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Participant participant)
        {
            throw new NotImplementedException();
        }
    }
}
