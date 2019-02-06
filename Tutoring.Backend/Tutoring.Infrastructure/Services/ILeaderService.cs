using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface ILeaderService : IService
    {
        Task<LeaderDto> GetAsync(Guid userId);
        Task<IEnumerable<LeaderDto>> BrowseAsync();
        Task CreateAsync(Guid userId);
        Task DeleteAsync(Guid userId);
    }
}
