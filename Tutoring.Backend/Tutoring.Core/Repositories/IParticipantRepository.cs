using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface IParticipantRepository : IRepository
    {
        Task<Participant> GetAsync(Guid userId);
        Task<IEnumerable<Participant>> GetAllAsync();
        Task<IEnumerable<Participant>> GetAllForCourseAsync(Guid courseId);
        Task AddAsync(Participant participant);
        Task UpdateAsync(Participant participant);
        Task RemoveAsync(Participant participant);
    }
}
