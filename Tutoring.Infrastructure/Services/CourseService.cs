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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> GetAsync(Guid id)
        {
            Course course = await _courseRepository.GetAsync(id);
            return _mapper.Map<Course,CourseDto>(course);
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
        }

    }
}
