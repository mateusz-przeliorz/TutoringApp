using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public class LeaderService : ILeaderService
    {
        private readonly ILeaderRepository _leaderRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public LeaderService(ILeaderRepository leaderRepository, IMapper mapper, IUserRepository userRepository)
        {
            _leaderRepository = leaderRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<LeaderDto>> BrowseAsync()
        {
            var leaders = await _leaderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Leader>, IEnumerable<LeaderDto>>(leaders);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with user id: '{userId}' can not be found.");
            }

            var leader = await _leaderRepository.GetAsync(userId);
            if(leader != null)
            {
                throw new Exception($"Leader with user id: '{userId}' already exists.");
            }

            leader = new Leader(user);
            await _leaderRepository.AddAsync(leader);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var leader = await _leaderRepository.GetAsync(userId);
            await _leaderRepository.RemoveAsync(leader);
        }

        public async Task<LeaderDto> GetAsync(Guid userId)
        {
            var leader = await _leaderRepository.GetAsync(userId);
            if(leader == null)
            {
                throw new Exception($"Leader with user id: '{userId}' can not be found.");
            }
            return _mapper.Map<Leader, LeaderDto>(leader);
        }
    }
}
