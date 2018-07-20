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
        private readonly ICourseDetailsProvider _courseDetailsProvider;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper,
                                ICourseDetailsProvider courseDetailsProvider)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _courseDetailsProvider = courseDetailsProvider;
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

        public async Task CreateAsync(Guid courseId, string name, int size, string city, string description,
            string field, string level, string subject)
        {
            var course = await _courseRepository.GetAsync(courseId);
            if (course != null)
            {
                throw new Exception($"Course with course id: '{courseId}' already exists.");
            }
            var courseDetails = await _courseDetailsProvider.GetAsync(subject, field, level);
            course = new Course(courseDetails, name, size, city, description);

            await _courseRepository.AddAsync(course);
        }

        public async Task SetCourseDetailsAsync(Guid courseId, string field, string level, string subject)
        {
            var course = await _courseRepository.GetAsync(courseId);
            if (course == null)
            {
                throw new Exception($"Course with course id: '{courseId}' can not be found.");
            }

            var courseDetails = await _courseDetailsProvider.GetAsync(subject, field, level);
            course.SetCourseDetails(courseDetails);
        }
    }
}
