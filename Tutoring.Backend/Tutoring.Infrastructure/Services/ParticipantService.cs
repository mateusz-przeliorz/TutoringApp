using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ParticipantService(IParticipantRepository participantRepository, IMapper mapper, IUserRepository userRepository)
        {
            _participantRepository = participantRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ParticipantDto>> BrowseAsync()
        {
            var participants = await _participantRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Participant>, IEnumerable<ParticipantDto>>(participants);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with user id: '{userId}' can not be found.");
            }

            var participant = await _participantRepository.GetAsync(userId);
            if (participant != null)
            {
                throw new Exception($"Leader with user id: '{userId}' already exists.");
            }

            participant = new Participant(user);
            await _participantRepository.AddAsync(participant);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var participant = await _participantRepository.GetAsync(userId);
            await _participantRepository.RemoveAsync(participant);
        }

        public async Task<ParticipantDto> GetAsync(Guid userId)
        {
            var participant = await _participantRepository.GetAsync(userId);
            return _mapper.Map<Participant, ParticipantDto>(participant);
        }
    }
}
