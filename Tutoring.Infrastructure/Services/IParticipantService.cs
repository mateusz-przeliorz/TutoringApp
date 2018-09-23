using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface IParticipantService : IService
    {
        Task<ParticipantDto> GetAsync(Guid userId);
        Task<IEnumerable<ParticipantDto>> BrowseAsync();
        Task CreateAsync(Guid userId);
        Task DeleteAsync(Guid userId);
    }
}
