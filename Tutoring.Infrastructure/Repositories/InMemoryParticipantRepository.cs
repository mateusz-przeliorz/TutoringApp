using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InMemoryParticipantRepository : IParticipantRepository
    {
        private static ISet<Participant> _participants = new HashSet<Participant>();

        public async Task AddAsync(Participant participant)
        {
            _participants.Add(participant);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Participant>> GetAllAsync()
        {
            return await Task.FromResult(_participants);
        }

        public async Task<IEnumerable<Participant>> GetAllForCourseAsync(Guid courseId)
        {
            var participants = _participants.Where(c => c.Courses.Any(x => x.Id == courseId));

            return await Task.FromResult(participants);
        }

        public async Task<Participant> GetAsync(Guid userId)
        {
            return await Task.FromResult(_participants.SingleOrDefault(x => x.UserId == userId));
        }

        public async Task RemoveAsync(Participant participant)
        {
            _participants.Remove(participant);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Participant participant)
        {
            await Task.CompletedTask;
        }
    }
}
